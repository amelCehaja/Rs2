using Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace WinUI.Vjezba
{
    public partial class frmVjezba : Form
    {
        private readonly APIService _service = new APIService("Vjezba");
        private readonly APIService _misicService = new APIService("Misic");
        private int? _vjezbaId;

        public frmVjezba(int? VjezbaId)
        {
            _vjezbaId = VjezbaId;
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "Gif Files(*.gif) | *.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private async void Novi()
        {
            if (ValidateChildren())
            {
                VjezbaInsertRequest request = new VjezbaInsertRequest
                {
                    Naziv = txtNaziv.Text,
                    Opis = txtOpis.Text,
                    Misici = new List<string>()
                };
                foreach (var x in clbMisici.CheckedItems)
                {
                    request.Misici.Add(x.ToString());
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(ms, ImageFormat.Gif);
                        request.Gif = ms.ToArray();
                    }
                    else
                    {
                        MessageBox.Show("Potreno je upload GIF!");
                        return;
                    }
                }

                Model.Vjezba entity = null;
                entity = await _service.Insert<Model.Vjezba>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste dodali vjezbu!");
                    this.Close();
                }
            }
        }

        private async Task LoadMisici()
        {
            List<Model.Misic> misici = await _misicService.Get<List<Model.Misic>>(null);
            misici.ForEach(x =>
            {
                clbMisici.Items.Add(x.Naziv);
            });

        }

        private async void frmVjezba_Load(object sender, EventArgs e)
        {
            await LoadMisici();
            if (_vjezbaId != null)
            {
                Model.Vjezba vjezba = await _service.GetById<Model.Vjezba>(_vjezbaId);
                txtNaziv.Text = vjezba.Naziv;
                txtOpis.Text = vjezba.Opis;
                byte[] slika = vjezba.Gif;
                var image = byteArrayToImage(slika);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                for (int i = 0; i < clbMisici.Items.Count; i++)
                {
                    clbMisici.SetItemChecked(i, false);
                    vjezba.Misici.ForEach(m =>
                    {
                        if (m == clbMisici.Items[i].ToString())
                            clbMisici.SetItemChecked(i, true);
                    });
                }
            }
            
        }
       
        private Image byteArrayToImage(byte[] byteArray)
        {
            Image image;
            MemoryStream ms = new MemoryStream(byteArray);
            image = Image.FromStream(ms);
            return image;
        }

        private async void Izmjena()
        {
            if (ValidateChildren())
            {
                VjezbaInsertRequest vjezba = new VjezbaInsertRequest
                {
                    Naziv = txtNaziv.Text,
                    Opis = txtOpis.Text,
                    Misici = new List<string>()
                };
                using (MemoryStream ms = new MemoryStream())
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(ms, ImageFormat.Gif);
                        vjezba.Gif = ms.ToArray();
                    }
                    else
                    {
                        MessageBox.Show("Potreno je upload GIF!");
                        return;
                    }
                }
                foreach (var x in clbMisici.CheckedItems)
                {
                    vjezba.Misici.Add(x.ToString());
                }
                Model.Vjezba entity = null;
                entity = await _service.Update<Model.Vjezba>(_vjezbaId ?? default, vjezba);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste izmjenili vjezbu!");
                    this.Close();
                }
            }
        }

        private async Task<bool> NazivExists()
        {
            VjezbaSearchRequest request = new VjezbaSearchRequest
            {
                Naziv = txtNaziv.Text
            };
            List<Model.Vjezba> vjezbe = await _service.Get<List<Model.Vjezba>>(request);
            if (vjezbe.Count > 0 && _vjezbaId == null)
            {
                return true;
            }
            else if (vjezbe.Count > 0 && _vjezbaId != null)
            {
                if (vjezbe[0].Id != _vjezbaId)
                {
                    return true;
                }
            }
            return false;
        }

        private async void txtNaziv_Validation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (!string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                var exists = await NazivExists();
                if(exists == true)
                {
                    errorProvider1.SetError(txtNaziv, "Naziv postoji!");
                    e.Cancel = true;
                }
            }
            else 
                errorProvider1.SetError(txtNaziv, null); 
        }

        private void txtOpis_Validation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (txtOpis.Text.Length > 1000)
            {
                errorProvider1.SetError(txtOpis, "Opis ne moze biti duzi od 1000 karaktera!");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtOpis, null);

        }

        private void clbMisici_Validation(object sender, CancelEventArgs e)
        {
            if (clbMisici.CheckedItems.Count == 0)
            {
                errorProvider1.SetError(clbMisici, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(clbMisici, null);

        }

        private void Gif_validation(object sender, CancelEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                errorProvider1.SetError(pictureBox1, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(pictureBox1, null);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var exists = await NazivExists();
            if (exists == false)
            {
                if (_vjezbaId == null)
                    Novi();
                else
                    Izmjena();
            }
        }

        private void frmVjezba_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListaVjezbi frm = new frmListaVjezbi();
            frm.Show();
        }
    }
}
