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
        public frmTipoviClanarine()
        {
            InitializeComponent();
        }
        private async void LoadTipoveClanarina()
        {
            var result = await _apiService.Get<List<Model.TipClanarine>>(null);
            dgvTipoviClanarina.DataSource = result;
        }

        private void frmTipoviClanarine_Load(object sender, EventArgs e)
        {
            LoadTipoveClanarina();
        }

        private async void btnNoviTipClanarine_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
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
                    LoadTipoveClanarina();
                    Clear();
                }
            }
        }

        private void dgvTipoviClanarina_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TipClanarineId = Int32.Parse(dgvTipoviClanarina.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            txtNaziv.Text = dgvTipoviClanarina.Rows[e.RowIndex].Cells["Naziv"].Value.ToString();
            txtCijena.Text = dgvTipoviClanarina.Rows[e.RowIndex].Cells["Cijena"].Value.ToString();
            txtTrajanje.Text = dgvTipoviClanarina.Rows[e.RowIndex].Cells["Trajanje"].Value.ToString();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
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
                        LoadTipoveClanarina();
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Niste odabrali Tip Clanarine za izmjenu");
                }
            }
        }

        private async void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
                errorProvider1.SetError(txtNaziv, Resources.Validation_Required);
            else if (txtNaziv.Text.Length > 25)
                errorProvider1.SetError(txtNaziv, "Maksimalna dozvoljena duzina je 25 karaktera!");
            else
                errorProvider1.SetError(txtNaziv, null);
            TipClanarineSearchRequest request = new TipClanarineSearchRequest
            {
                Naziv = txtNaziv.Text
            };
            List<Model.TipClanarine> list = await _apiService.Get<List<TipClanarine>>(request);
            if(list.Count>0 && TipClanarineId == null)
            {
                errorProvider1.SetError(txtNaziv, "Naziv vec postoji!");
            }
            else if(list.Count>0 && TipClanarineId!= null)
            {
                if(list[0].Id != TipClanarineId)
                {
                    errorProvider1.SetError(txtNaziv, "Naziv vec postoji!");
                }
            }

        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text))
                errorProvider1.SetError(txtCijena, Resources.Validation_Required);
            else if (!Regex.Match(txtCijena.Text, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
                errorProvider1.SetError(txtCijena, "Dozvoljeni su samo brojevi sa . !");
            else if (double.Parse(txtCijena.Text) < 0 || double.Parse(txtCijena.Text) > double.MaxValue)
                errorProvider1.SetError(txtCijena, "Dozvoljeni su samo pozitivni brojevi");
            else
                errorProvider1.SetError(txtCijena, null);
        }

        private void txtTrajanje_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrajanje.Text))
                errorProvider1.SetError(txtTrajanje, Resources.Validation_Required);
            else if (!Regex.Match(txtTrajanje.Text, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
                errorProvider1.SetError(txtTrajanje, "Dozvoljeni su samo brojevi!");
        }

        private void Clear()
        {
            TipClanarineId = null;
            txtNaziv.Text = "";
            txtCijena.Text = "";
            txtTrajanje.Text = "";
        }
    }
}
