using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Properties;

namespace WinUI.TipoviClanarine
{
    public partial class frmTipoviClanarine : Form
    {
        private readonly APIService _apiService = new APIService("tipClanarine");
        private int? TipClanarineId;
        public frmTipoviClanarine(int? _tipClanarine)
        {
            TipClanarineId = _tipClanarine;
            InitializeComponent();
        }

        private async void frmTipoviClanarine_Load(object sender, EventArgs e)
        {
           if(TipClanarineId != null)
            {
                var tipClanarine = await _apiService.GetById<TipClanarine>(TipClanarineId);
                txtNaziv.Text = tipClanarine.Naziv;
                txtCijena.Text = tipClanarine.Cijena.ToString();
                txtTrajanje.Text = tipClanarine.Trajanje.ToString();
            }
        }

        private async void Novi()
        {
            if (this.ValidateChildren())
            {
                TipClanarineInsertRequest request = new TipClanarineInsertRequest
                {
                    Naziv = txtNaziv.Text,
                    Trajanje = Int32.Parse(txtTrajanje.Text),
                    Cijena = Double.Parse(txtCijena.Text)
                };

                TipClanarine entity = null;
                entity = await _apiService.Insert<TipClanarine>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste dodali tip clanarine!");
                    this.Close();
                }
            }
        }

        private async void Izmjeni()
        {
            if (ValidateChildren())
            {
                if (TipClanarineId != null)
                {
                    TipClanarineInsertRequest request = new TipClanarineInsertRequest
                    {
                        Naziv = txtNaziv.Text,
                        Cijena = Double.Parse(txtCijena.Text),
                        Trajanje = Int32.Parse(txtTrajanje.Text)
                    };
                    TipClanarine tipClanarine = null;
                    tipClanarine = await _apiService.Update<TipClanarine>(TipClanarineId ?? default(int), request);
                    if (tipClanarine != null)
                    {
                        MessageBox.Show("Uspjesno ste izmjenili tip clanarine!");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Niste odabrali Tip Clanarine za izmjenu");
                }
            }
        }

        private async Task<bool> NazivExists()
        {
            TipClanarineSearchRequest request = new TipClanarineSearchRequest
            {
                Naziv = txtNaziv.Text
            };
            List<Model.TipClanarine> list = await _apiService.Get<List<TipClanarine>>(request);
            if (list.Count > 0 && TipClanarineId == null)
            {
                return true;
            }
            else if (list.Count > 0 && TipClanarineId != null)
            {
                if (list[0].Id != TipClanarineId)
                {
                    return true;
                }
            }
            return false;
        }

        private async void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (txtNaziv.Text.Length > 25)
            {
                errorProvider1.SetError(txtNaziv, "Maksimalna dozvoljena duzina je 25 karaktera!");
                e.Cancel = true;
            }
            else if(!string.IsNullOrWhiteSpace(txtNaziv.Text) && txtNaziv.Text.Length <= 25)
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

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
            {
                errorProvider1.SetError(txtCijena, Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (!Regex.Match(txtCijena.Text, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtCijena, "Dozvoljeni su samo brojevi sa . !");
                e.Cancel = true;
            }
            else if (double.Parse(txtCijena.Text) < 0 || double.Parse(txtCijena.Text) > double.MaxValue)
            {
                errorProvider1.SetError(txtCijena, "Dozvoljeni su samo pozitivni brojevi");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtCijena, null);
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrajanje.Text))
            {
                errorProvider1.SetError(txtTrajanje, Resources.Validation_Required);
                e.Cancel = true;
            }
            else if (!Regex.Match(txtTrajanje.Text, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
            {
                errorProvider1.SetError(txtTrajanje, "Dozvoljeni su samo brojevi!");
                e.Cancel = true;
            }
            else if (txtTrajanje.Text.Length > Int32.MaxValue.ToString().Length)
            {
                errorProvider1.SetError(txtTrajanje, "Uneseni broj je prevelik!");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtTrajanje, null);
        }

        private void Clear()
        {
            TipClanarineId = null;
            txtNaziv.Text = "";
            txtCijena.Text = "";
            txtTrajanje.Text = "";
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var exists = await NazivExists();
            if (exists == false)
            {
                if (TipClanarineId == null)
                    Novi();
                else
                    Izmjeni();
            }
        }

        private void frmTipoviClanarine_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListaTipovaClanarine frmListaTipovaClanarine = new frmListaTipovaClanarine();
            frmListaTipovaClanarine.Show();
        }
    }
}
