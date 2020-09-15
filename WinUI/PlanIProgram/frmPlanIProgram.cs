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

namespace WinUI.PlanIProgram
{
    public partial class frmPlanIProgram : Form
    {
        private readonly APIService _kategorijaService = new APIService("PlanKategorija");
        private readonly APIService _service = new APIService("PlanIProgram");

        public frmPlanIProgram()
        {
            InitializeComponent();
        }

        private async void PlanIProgram_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
            await LoadPlanove();
        }

        private async Task LoadKategorije()
        {
            List<Model.PlanKategorija> kategorije = await _kategorijaService.Get<List<Model.PlanKategorija>>(null);
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "Id";
            cmbKategorija.DataSource = kategorije;
        }
        private async Task LoadPlanove()
        {
            List<Model.PlanIProgram> result = new List<Model.PlanIProgram>();
            if (txtSearchNaziv.Text != null)
            {
                PlanIProgramSearchRequest request = new PlanIProgramSearchRequest
                {
                    Naziv = txtSearchNaziv.Text
                };
                result = await _service.Get<List<Model.PlanIProgram>>(request);
            }
            else
                result = await _service.Get<List<Model.PlanIProgram>>(null);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
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
                    await LoadPlanove();
                }
            }
        }

        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            await LoadPlanove();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                Model.PlanIProgram planIProgram = new Model.PlanIProgram
                {
                    Id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString()),
                    Naziv = dataGridView1.Rows[e.RowIndex].Cells["Naziv"].Value.ToString()
                };
                frmPlanDetails frm = new frmPlanDetails(planIProgram);
                frm.Show();
            }
        }

        private async void txtNaziv_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Properties.Resources.Validation_Required);
            }
            else
            {
                errorProvider1.SetError(txtNaziv,null);
            }
            PlanIProgramSearchRequest request = new PlanIProgramSearchRequest
            {
                Naziv = txtNaziv.Text
            };
            List<Model.PlanIProgram> planovi = await _service.Get<List<Model.PlanIProgram>>(request);
            if(planovi.Count > 0)
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txt_Cijena_Validate(object sender, CancelEventArgs e)
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

        private void txtOpis_Validate(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, Resources.Validation_Required);
            }
            else errorProvider1.SetError(txtOpis, null);
        }
    }
}
