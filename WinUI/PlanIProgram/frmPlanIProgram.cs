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
using System.Windows.Controls;
using System.Windows.Forms;
using WinUI.Properties;

namespace WinUI.PlanIProgram
{
    public partial class frmPlanIProgram : Form
    {
        private readonly APIService _kategorijaService = new APIService("PlanKategorija");
        private readonly APIService _service = new APIService("PlanIProgram");
        private int? _PlanId;

        public frmPlanIProgram(int? id)
        {
            _PlanId = id;
            InitializeComponent();
        }

        private async void PlanIProgram_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
            if(_PlanId != null)
            {
                Model.PlanIProgram plan = await _service.GetById<Model.PlanIProgram>(_PlanId);
                txtNaziv.Text = plan.Naziv;
                txtCijena.Text = plan.Cijena.ToString();
                txtOpis.Text = plan.Opis;
                for(int i = 0; i < cmbKategorija.Items.Count; i++)
                {
                    Model.PlanKategorija item = (Model.PlanKategorija)cmbKategorija.Items[i];
                    if(item.Naziv == plan.Kategorija)
                    {
                        cmbKategorija.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private async Task LoadKategorije()
        {
            List<Model.PlanKategorija> kategorije = await _kategorijaService.Get<List<Model.PlanKategorija>>(null);
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "Id";
            cmbKategorija.DataSource = kategorije;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            bool exists = await NazivExists();
            if(exists == false)
            {
                if (_PlanId == null)
                    await Novi();
                else
                    await Izmjena();
            }
        }

        private async Task Novi()
        {
            if (ValidateChildren())
            {
                PlanIProgramInsertRequest request = new PlanIProgramInsertRequest
                {
                    Naziv = txtNaziv.Text,
                    Cijena = double.Parse(txtCijena.Text),
                    Opis = txtOpis.Text,
                    KategorijaId = (int)cmbKategorija.SelectedValue
                };
                Model.PlanIProgram entity = null;
                entity = await _service.Insert<Model.PlanIProgram>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste dodali plan i program!");
                    this.Close();
                }
            }
        }
        private async Task Izmjena()
        {
            if (ValidateChildren())
            {
                PlanIProgramUpdateRequest request = new PlanIProgramUpdateRequest
                {
                    Id = _PlanId ?? default,
                    Naziv = txtNaziv.Text,
                    Cijena = double.Parse(txtCijena.Text),
                    Opis = txtOpis.Text,
                    KategorijaId = (int)cmbKategorija.SelectedValue
                };
                Model.PlanIProgram entity = null;
                entity = await _service.Update<Model.PlanIProgram>(request.Id,request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste izmjenili plan i program!");
                    this.Close();
                }
            }
        }
        private async Task<bool> NazivExists()
        {
            PlanIProgramSearchRequest request = new PlanIProgramSearchRequest
            {
                Naziv = txtNaziv.Text
            };
            List<Model.PlanIProgram> planovi = await _service.Get<List<Model.PlanIProgram>>(request);
            if (planovi.Count > 0 && _PlanId == null)
                return true;
            if(planovi.Count > 0 && _PlanId != null)
            {
                if (planovi[0].Id != _PlanId)
                    return true;
            }
            return false;
        }

        private async void txtNaziv_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_Required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv,null);
            }
            if (!string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                bool exists = await NazivExists();
                if (exists == true)
                {
                    errorProvider1.SetError(txtNaziv, "Naziv postoji!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtNaziv, null);

                }
            }
            
            
        }

        private void txt_Cijena_Validate(object sender, CancelEventArgs e)
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

        private void txtOpis_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Resources.Validation_Required);
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtOpis, null);
        }

        private void frmPlanIProgram_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListaPlanIProgram frm = new frmListaPlanIProgram();
            frm.Show();
        }
    }
}
