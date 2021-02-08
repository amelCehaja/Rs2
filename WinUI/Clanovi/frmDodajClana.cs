using Model;
using Model.Requests;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Clanarina;
using WinUI.Properties;

namespace WinUI.Clanovi
{
    public partial class frmDodajClana : Form
    {
        APIService _service = new APIService("Korisnik");
        VideoCapture capture;
        Mat frame;
        Bitmap image;
        int? ClanID = null;
        private Thread camera;
        bool isCameraRunning = false;
        public frmDodajClana(int? ClanId)
        {
            ClanID = ClanId;
            InitializeComponent();
            
        }
        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }
        private void CaptureCameraCallback()
        {
            frame = new Mat();
            capture = new VideoCapture(0);
            capture.Open(0);

            if (capture.IsOpened())
            {
                while (isCameraRunning)
                {

                    capture.Read(frame);
                    image = BitmapConverter.ToBitmap(frame);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = image;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("Start"))
            {
                CaptureCamera();
                btnStart.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                btnStart.Text = "Start";
                isCameraRunning = false;
            }
        }

        private void btnUslikaj_Click(object sender, EventArgs e)
        {
            if (isCameraRunning && pictureBox1.Image != null)
            {
               
                    // Take snapshot of the current image generate by OpenCV in the Picture Box
                    Bitmap snapshot = new Bitmap(pictureBox1.Image);
                    pictureBox1.Image = snapshot;
                    btnStart.Text = "Start";
                    isCameraRunning = false;
               
            }
            else
            {
                MessageBox.Show("Cannot take picture if the camera isn't capturing image!", "Camera error!", MessageBoxButtons.OK);
            }
        }

        private async void SpremiNovogClana()
        {
            if (ValidateChildren())
            {
                var request = new KorisnikInsertRequest
                {
                    BrojKartice = txtBrojKartice.Text,
                    DatumRodenja = dtpDatumRodenja.Value.Date,
                    Email = txtEmail.Text,
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Spol = cmbSpol.SelectedItem.ToString(),
                    Telefon = txtTelefon.Text,
                    Uloga = "Clan",
                    Username = "tempUsername",
                    Password = "tempPassword"
                };
                using (MemoryStream ms = new MemoryStream())
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                        request.Slika = ms.ToArray();
                    }
                    else { MessageBox.Show("Potrebno je uslikati!", "", MessageBoxButtons.OK);
                        return;
                    }
                }
                Korisnik entity = null;
                entity = await _service.Insert<Korisnik>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    this.Close();
                }
            }
        }

        private async void frmDodajClana_Load(object sender, EventArgs e)
        {
            cmbSpol.Items.Add("M");
            cmbSpol.Items.Add("Ž");
            cmbSpol.SelectedIndex = 0;
               
            if(ClanID != null)
            {
                KorisniciSearchRequest request = new KorisniciSearchRequest
                {
                    Id = ClanID
                };
                var korisnici = await _service.Get<List<Korisnik>>(request);
                Korisnik korisnik = korisnici[0];
                txtIme.Text = korisnik.Ime;
                txtPrezime.Text = korisnik.Prezime;
                txtEmail.Text = korisnik.Email;
                txtBrojKartice.Text = korisnik.BrojKartice;
                txtTelefon.Text = korisnik.Telefon;
                cmbSpol.SelectedItem = korisnik.Spol;
                if(korisnik.DatumRodenja != null)
                    dtpDatumRodenja.Value = korisnik.DatumRodenja.Value;
                byte[] slika = korisnik.Slika;
                if (slika.Length > 0)
                    pictureBox1.Image = byteArrayToImage(slika);
            }
        }

        private Image byteArrayToImage(byte[] byteArray)
        {
            Image image;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var _emailExists = await EmailExixsts();
            var _karticaExists = await KarticaExists();

            if (ValidateChildren() && _emailExists == false && _karticaExists == false)
            {
                if (ClanID != null)
                {
                    UpdateClan();
                }
                else if(ClanID == null)
                {
                    SpremiNovogClana();
                }
            }
        }

        private async void UpdateClan()
        {
            var request = new KorisnikUpdateRequest
            {
                BrojKartice = txtBrojKartice.Text,
                DatumRodenja = dtpDatumRodenja.Value.Date,
                Email = txtEmail.Text,
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                Spol = cmbSpol.SelectedItem.ToString(),
                Telefon = txtTelefon.Text
            };
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                        request.Slika = ms.ToArray();
                    }
                    else
                    {
                        MessageBox.Show("Potrebno je uslikati!", "", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch
            {

            }

            int id = ClanID ?? default(int);
            var korisnik = await _service.Update<Korisnik>(id, request);
            if (korisnik != null)
            {
                MessageBox.Show("Uspjesno ste spremili izmjene!");
                this.Close();
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (!Regex.Match(txtIme.Text, @"^[a-zA-ZČčĆćŽžĐđŠš ]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtIme, "Dozvoljena su samo slova!");
                e.Cancel = true;
            }
            else if (txtIme.Text.Length > 50)
            {
                errorProvider1.SetError(txtIme, "Maksimalna dozvoljena duzina je 50 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider1.SetError(txtPrezime, Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (!Regex.Match(txtPrezime.Text, @"^[a-zA-ZČčĆćŽžĐđŠš ]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtPrezime, "Dozvoljena su samo slova!");
                e.Cancel = true;
            }
            else if (txtPrezime.Text.Length > 50)
            {
                errorProvider1.SetError(txtPrezime, "Maksimalna dozvoljena duzina je 50 karaktera!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPrezime, null);
            }
        }

        private void cmbSpol_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSpol.SelectedItem.ToString()))
            {               
                errorProvider1.SetError(cmbSpol, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cmbSpol, null);
            }
        }

        private async Task<bool> EmailExixsts()
        {
            KorisniciSearchRequest request = new KorisniciSearchRequest
            {
                Email = txtEmail.Text
            };
            List<Model.Korisnik> korisnik = await _service.Get<List<Model.Korisnik>>(request);
            if (ClanID == null && korisnik.Count > 0)
            {
                return true;
            }
            else if (ClanID != null && korisnik.Count > 0)
            {
                if (korisnik[0].Id != ClanID)
                {
                    return true;
                }
            }
            return false;
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.ToString()))
            {
                errorProvider1.SetError(txtEmail, Resources.Validation_Required);
                e.Cancel = true;
            }
            if (!Regex.Match(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtEmail, "Neispravan format Email-a!");
                e.Cancel = true;
            }
            else if (txtEmail.Text != null)
            {
                var _emailExists = await EmailExixsts();
                if (_emailExists)
                {
                    errorProvider1.SetError(txtEmail, "Email postoji!");
                    e.Cancel = true;
                }
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {       
            if (!string.IsNullOrWhiteSpace(txtTelefon.Text) && !Regex.Match(txtTelefon.Text, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtTelefon, "Dozvoljeni su samo brojevi!");
                e.Cancel = true;
            }
        }

        private async Task<bool> KarticaExists()
        {
            KorisniciSearchRequest request = new KorisniciSearchRequest
            {
                BrojKartice = txtBrojKartice.Text
            };
            List<Model.Korisnik> korisnik = await _service.Get<List<Model.Korisnik>>(request);
            if (ClanID == null && korisnik.Count > 0)
            {
                return true;
            }
            else if (ClanID != null && korisnik.Count > 0)
            {
                if (korisnik[0].Id != ClanID)
                {
                    return true;
                }
            }
            return false;
        }

        private async void txtBrojKartice_Validating(object sender, CancelEventArgs e)
        {
            if (txtBrojKartice.Text.Length != 8 || !Regex.Match(txtBrojKartice.Text, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtBrojKartice, "Broj kartice mora biti 8 brojeva!");
                e.Cancel = true;
            }
            else
            {
                var _karticaExists = await KarticaExists();
                if(_karticaExists) {
                    errorProvider1.SetError(txtBrojKartice, "Broj kartice vec postoji!");
                    e.Cancel = true;
                }
            }
        }
        private void Clear()
        {
            ClanID = null;
            txtIme.Text = "";
            txtPrezime.Text = "";
            dtpDatumRodenja.Value = DateTime.Today;
            cmbSpol.SelectedIndex = 0;
            txtEmail.Text = "";
            txtTelefon.Text = "";
            txtBrojKartice.Text = "";
        }

        private void frmDodajClana_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListaClanova frm = new frmListaClanova();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "JPG files (*.jpg) | *.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
    }
}
