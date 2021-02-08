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

namespace WinUI.Vjezba
{
    public partial class frmListaVjezbi : Form
    {

        private readonly APIService _service = new APIService("Vjezba");
        private readonly APIService _misicService = new APIService("Misic");
        public frmListaVjezbi()
        {
            InitializeComponent();
        }

        private async void frmListaVjezbi_Load(object sender, EventArgs e)
        {
            await LoadMisici();
            await LoadVjezbe();
        }
        private async Task LoadMisici()
        {
            List<Model.Misic> misici = await _misicService.Get<List<Model.Misic>>(null);
            misici.ForEach(x =>
            {
                cmbMisic.Items.Add(x.Naziv);
            });

        }
        private async Task LoadVjezbe()
        {
            VjezbaSearchRequest request = new VjezbaSearchRequest();
            if (cmbMisic.SelectedItem != null)
            {
                request.Misic = cmbMisic.SelectedItem.ToString();
            }
            else
            {
                request = null;
            }
            List<Model.Vjezba> vjezbe = await _service.Get<List<Model.Vjezba>>(request);
            dgvVjezbe.AutoGenerateColumns = false;
            dgvVjezbe.DataSource = vjezbe;
        }
        private async void btnPretraga_Click(object sender, EventArgs e)
        {
            if (cmbMisic.SelectedItem == null)
                return;
            VjezbaSearchRequest request = new VjezbaSearchRequest
            {
                Misic = cmbMisic.SelectedItem.ToString()
            };
            List<Model.Vjezba> vjezbe = await _service.Get<List<Model.Vjezba>>(request);
            dgvVjezbe.AutoGenerateColumns = false;
            dgvVjezbe.DataSource = vjezbe;
        }

        private void dgvVjezbe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                int id = Int32.Parse(dgvVjezbe.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmVjezba frm = new frmVjezba(id);
                frm.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVjezba frm = new frmVjezba(null);
            frm.Show();
            this.Close();
        }

    }
}
