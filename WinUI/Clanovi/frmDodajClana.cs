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
        public frmDodajClana()
        {
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
            if (isCameraRunning)
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

        private async void btnSpremi_Click(object sender, EventArgs e)
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
                LoadClanovi();
                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                    Clear();
                }
            }
        }

        private void frmDodajClana_Load(object sender, EventArgs e)
        {
            cmbSpol.Items.Add("M");
            cmbSpol.Items.Add("Ž");
            cmbSpol.SelectedIndex = 0;
            LoadClanovi();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            LoadClanovi();
        }
        private async void LoadClanovi()
        {
            var search = new KorisniciSearchRequest()
            {
                Ime = txtSearchIme.Text,
                Prezime = txtSearchPrezime.Text
            };
            var result = await _service.Get<List<Korisnik>>(search);

            dgvClanovi.AutoGenerateColumns = false;
            dgvClanovi.DataSource = result;
        }

        private void dgvClanovi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClanID = Convert.ToInt32(dgvClanovi.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            txtIme.Text = dgvClanovi.Rows[e.RowIndex].Cells["Ime"].Value.ToString();
            txtPrezime.Text = dgvClanovi.Rows[e.RowIndex].Cells["Prezime"].Value.ToString();
            txtEmail.Text = dgvClanovi.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtBrojKartice.Text = dgvClanovi.Rows[e.RowIndex].Cells["BrojKartice"].Value.ToString();
            if (dgvClanovi.Rows[e.RowIndex].Cells["Telefon"].Value != null)
            {
                txtTelefon.Text = dgvClanovi.Rows[e.RowIndex].Cells["Telefon"].Value.ToString();
            }
            else txtTelefon.Text = "";
            cmbSpol.SelectedItem = dgvClanovi.Rows[e.RowIndex].Cells["Spol"].Value.ToString();
            if (dgvClanovi.Rows[e.RowIndex].Cells["DatumRodenja"].Value != null)
                dtpDatumRodenja.Value = (DateTime)dgvClanovi.Rows[e.RowIndex].Cells["DatumRodenja"].Value;
            byte[] slika = (byte[])dgvClanovi.Rows[e.RowIndex].Cells["Slika"].Value;
            if (slika.Length > 0)
                pictureBox1.Image = byteArrayToImage(slika);
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
            if (ValidateChildren())
            {
                if (ClanID != null)
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
                    catch { }
                    
                    int id = ClanID ?? default(int);
                    var korisnik = await _service.Update<Korisnik>(id, request);
                    if (korisnik != null)
                    {
                        LoadClanovi();
                        MessageBox.Show("Uspjesno ste spremili izmjene!");
                        Clear();
                    }
                }
            }
        }

        private void dgvClanovi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                int ClanID = Int32.Parse(dgvClanovi.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmClanarine frm = new frmClanarine(ClanID);
                frm.Show();
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider1.SetError(txtIme, Resources.Validation_Required);
            }
            else if (!Regex.Match(txtIme.Text, @"^[a-zA-ZČčĆćŽžĐđŠš ]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtIme, "Dozvoljena su samo slova!");
            }
            else if (txtIme.Text.Length > 50)
            {
                errorProvider1.SetError(txtIme, "Maksimalna dozvoljena duzina je 50 karaktera!");
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
            }
            else if (!Regex.Match(txtPrezime.Text, @"^[a-zA-ZČčĆćŽžĐđŠš ]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtPrezime, "Dozvoljena su samo slova!");
            }
            else if (txtPrezime.Text.Length > 50)
            {
                errorProvider1.SetError(txtPrezime, "Maksimalna dozvoljena duzina je 50 karaktera!");
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
                e.Cancel = true;
                errorProvider1.SetError(cmbSpol, Properties.Resources.Validation_Required);
            }
            else
            {
                errorProvider1.SetError(cmbSpol, null);
            }
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.ToString()))
            {
                errorProvider1.SetError(txtEmail, Resources.Validation_Required);
            }
            if(!Regex.Match(txtEmail.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase).Success)
                errorProvider1.SetError(txtEmail, "Neispravan format Email-a!");
            else if (txtEmail.Text != null)
            {
                KorisniciSearchRequest request = new KorisniciSearchRequest
                {
                    Email = txtEmail.Text
                };
                List<Model.Korisnik> korisnik = await _service.Get<List<Model.Korisnik>>(request);
                if (ClanID == null && korisnik.Count > 0)
                {
                    errorProvider1.SetError(txtEmail, "Email je vec registrovan u bazi!");
                }
                else if (ClanID != null && korisnik.Count > 0)
                {
                    if (korisnik[0].Id != ClanID)
                    {
                        errorProvider1.SetError(txtEmail, "Email je vec registrovan u bazi!");
                    }
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
            }
        }

        private async void txtBrojKartice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojKartice.Text))
            {
                errorProvider1.SetError(txtBrojKartice, Resources.Validation_Required);
            }
            else if (txtBrojKartice != null)
            {
                KorisniciSearchRequest request = new KorisniciSearchRequest
                {
                    BrojKartice = txtBrojKartice.Text
                };
                List<Model.Korisnik> korisnik = await _service.Get<List<Model.Korisnik>>(request);
                if (ClanID == null && korisnik.Count > 0)
                {
                    errorProvider1.SetError(txtBrojKartice, "Broj kartice je vec registrovan u bazi!");
                }
                else if (ClanID != null && korisnik.Count>0)
                {
                    if (korisnik[0].Id != ClanID)
                    {
                        errorProvider1.SetError(txtBrojKartice, "Broj kartice je vec registrovan u bazi!");
                    }
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
    }
}
