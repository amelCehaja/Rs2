using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI.TipoviClanarine
{
    public partial class frmListaTipovaClanarine : Form
    {
        private readonly APIService _apiService = new APIService("tipClanarine");
        public frmListaTipovaClanarine()
        {
            InitializeComponent();
        }

        private async void LoadTipoveClanarina()
        {
            var result = await _apiService.Get<List<Model.TipClanarine>>(null);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
        }

        private void frmListaTipovaClanarine_Load(object sender, EventArgs e)
        {
            LoadTipoveClanarina();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                int _id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmTipoviClanarine frmTipoviClanarine = new frmTipoviClanarine(_id);
                frmTipoviClanarine.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTipoviClanarine frmTipoviClanarine = new frmTipoviClanarine(null);
            frmTipoviClanarine.Show();
            this.Close();
        }
    }
}
