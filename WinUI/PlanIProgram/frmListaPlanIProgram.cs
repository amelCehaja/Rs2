using Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI.PlanIProgram
{
    public partial class frmListaPlanIProgram : Form
    {
        private readonly APIService _kategorijaService = new APIService("PlanKategorija");
        private readonly APIService _service = new APIService("PlanIProgram");
        public frmListaPlanIProgram()
        {
            InitializeComponent();
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

        private async void frmListaPlanIProgram_Load(object sender, EventArgs e)
        {
            await LoadPlanove();

        }
        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            await LoadPlanove();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                Model.PlanIProgram planIProgram = new Model.PlanIProgram
                {
                    Id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString()),
                    Naziv = dataGridView1.Rows[e.RowIndex].Cells["Naziv"].Value.ToString()
                };
                frmPlanDetails frmPlanDetails = new frmPlanDetails(planIProgram);
                frmPlanDetails.Show();
            }
            else if(e.ColumnIndex == 5)
            {
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmPlanIProgram frmPlanIProgram = new frmPlanIProgram(id);
                frmPlanIProgram.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPlanIProgram frmPlanIProgram = new frmPlanIProgram(null);
            frmPlanIProgram.Show();
        }
    }
}
