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

        public frmVjezba()
        {
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

        private async void button1_Click(object sender, EventArgs e)
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
                    else MessageBox.Show("Potreno je upload GIF!");
                }

                Model.Vjezba entity = null;
                entity = await _service.Insert<Model.Vjezba>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste dodali vjezbu!");
                }
            }
        }

        private async Task LoadMisici()
        {
            List<Model.Misic> misici = await _misicService.Get<List<Model.Misic>>(null);
            misici.ForEach(x =>
            {
                clbMisici.Items.Add(x.Naziv);
                cmbMisic.Items.Add(x.Naziv);
            });

        }

        private async void frmVjezba_Load(object sender, EventArgs e)
        {
            await LoadMisici();
            await LoadVjezbe();

        }
        private async Task LoadVjezbe()
        {
            VjezbaSearchRequest request = new VjezbaSearchRequest();
            if (cmbMisic.SelectedItem != null)
            {
                request.Misic = cmbMisic.SelectedItem.ToString();
            }
            else
            {
                request = null;
            }
            List<Model.Vjezba> vjezbe = await _service.Get<List<Model.Vjezba>>(request);
            dgvVjezbe.AutoGenerateColumns = false;
            dgvVjezbe.DataSource = vjezbe;
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            VjezbaSearchRequest request = new VjezbaSearchRequest
            {
                Misic = cmbMisic.SelectedItem.ToString()
            };
            List<Model.Vjezba> vjezbe = await _service.Get<List<Model.Vjezba>>(request);
            dgvVjezbe.AutoGenerateColumns = false;
            dgvVjezbe.DataSource = vjezbe;
        }

        private async void dgvVjezbe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int vjezbaId = Int32.Parse(dgvVjezbe.Rows[e.RowIndex].Cells["id"].Value.ToString());
            var result = await _service.GetById<Model.Vjezba>(vjezbaId);
            txtNaziv.Text = result.Naziv;
            txtOpis.Text = result.Opis;
            _vjezbaId = result.Id;
            byte[] slika = (byte[])dgvVjezbe.Rows[e.RowIndex].Cells["Gif"].Value;
            var image = byteArrayToImage(slika);
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            for (int i = 0; i < clbMisici.Items.Count; i++)
            {
                clbMisici.SetItemChecked(i, false);
                result.Misici.ForEach(m =>
                {
                    if (m == clbMisici.Items[i].ToString())
                        clbMisici.SetItemChecked(i, true);
                });
            }
        }
        private Image byteArrayToImage(byte[] byteArray)
        {
            Image image;
            MemoryStream ms = new MemoryStream(byteArray);
            image = Image.FromStream(ms);
            return image;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (_vjezbaId == null)
            {
                MessageBox.Show("Nije odabarana vjezba za izmjenu!");
                return;
            }
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
                    else MessageBox.Show("Potreno je upload GIF!");
                }
                foreach (var x in clbMisici.CheckedItems)
                {
                    vjezba.Misici.Add(x.ToString());
                }
                Model.Vjezba entity = null;
                entity = await _service.Update<Model.Vjezba>(_vjezbaId ?? default, vjezba);
            }
        }

        private async void txtNaziv_Validation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_Required);
            }
            else { errorProvider1.SetError(txtNaziv, null); }
            VjezbaSearchRequest request = new VjezbaSearchRequest
            {
                Naziv = txtNaziv.Text
            };
            List<Model.Vjezba> vjezbe = await _service.Get<List<Model.Vjezba>>(request);
            if (vjezbe.Count > 0 && _vjezbaId == null)
            {
                errorProvider1.SetError(txtNaziv, "Naziv vec postoji!");
            }
            else if (vjezbe.Count > 0 && _vjezbaId != null)
            {
                if (vjezbe[0].Id != _vjezbaId)
                {
                    errorProvider1.SetError(txtNaziv, "Naziv vec postoji!");
                }
            }
            else { errorProvider1.SetError(txtNaziv, null); }


        }

        private void txtOpis_Validation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Properties.Resources.Validation_Required);
            }
            else if (txtOpis.Text.Length > 1000)
            {
                errorProvider1.SetError(txtOpis, "Opis ne moze biti duzi od 100 karaktera!");
            }
            else
                errorProvider1.SetError(txtOpis, null);

        }

        private void clbMisici_Validation(object sender, CancelEventArgs e)
        {
            if (clbMisici.CheckedItems.Count == 0)
            {
                errorProvider1.SetError(clbMisici, Properties.Resources.Validation_Required);
            }
            else
                errorProvider1.SetError(clbMisici, null);

        }

        private void Gif_validation(object sender, CancelEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                errorProvider1.SetError(pictureBox1, Properties.Resources.Validation_Required);
            }
            else
                errorProvider1.SetError(pictureBox1, null);

        }
    }
}
