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
    public partial class frmListaKategorijaPiP : Form
    {
        private readonly APIService _service = new APIService("PlanKategorija");

        public frmListaKategorijaPiP()
        {
            InitializeComponent();
        }
        private async Task LoadKategorije()
        {
            List<Model.PlanKategorija> kategorije = await _service.Get<List<Model.PlanKategorija>>(null);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = kategorije;
        }

        private async void frmListaKategorijaPiP_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmDodajKategoriju frmDodaj = new frmDodajKategoriju(id);
                frmDodaj.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDodajKategoriju frmDodaj = new frmDodajKategoriju(null);
            frmDodaj.Show();
            this.Close();
        }
    }
}
