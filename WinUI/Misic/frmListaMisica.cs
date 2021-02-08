using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI.Misic
{
    public partial class frmListaMisica : Form
    {
        private readonly APIService _service = new APIService("Misic");

        public frmListaMisica()
        {
            InitializeComponent();
        }
        private async Task LoadMisici()
        {
            List<Model.Misic> result = await _service.Get<List<Model.Misic>>(null);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
        }

        private async void frmListaMisica_Load(object sender, EventArgs e)
        {
            await LoadMisici();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                int _id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmMisic frmMisic = new frmMisic(_id);
                frmMisic.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMisic frmMisic = new frmMisic(null);
            frmMisic.Show();
            this.Close();
        }
    }
}
