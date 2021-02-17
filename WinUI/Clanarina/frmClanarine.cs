
using Flurl.Http;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI.Clanarina
{
    public partial class frmClanarine : Form
    {
        private readonly APIService _service = new APIService("Clanarina");
        private readonly APIService _tipClanarineService = new APIService("TipClanarine");
        private int _clanId;
        public frmClanarine(int ClanId)
        {
            InitializeComponent();
            _clanId = ClanId;
        }

        public async Task LoadTipoviClanarine()
        {
            var result = await _tipClanarineService.Get<List<Model.TipClanarine>>(null);
            cmbTipClanarine.DisplayMember = "Naziv";
            cmbTipClanarine.ValueMember = "Id";
            cmbTipClanarine.DataSource = result;
            cmbTipClanarine.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task LoadClanarine()
        {
            ClanarinaSearchRequest request = new ClanarinaSearchRequest
            {
                KorisnikId = _clanId
            };
            var clanarine = await _service.Get<List<Model.Clanarina>>(request);
            dgvClanarine.AutoGenerateColumns = false;
            dgvClanarine.DataSource = clanarine;
        }

        private async void frmClanarine_Load(object sender, EventArgs e)
        {
            await LoadClanarine();
            await LoadTipoviClanarine();
        }

        private async void cmbTipClanarine_SelectedIndexChanged(object sender, EventArgs e)
        {
            await AutoDate();
        }

        private async Task AutoDate()
        {
            var index = cmbTipClanarine.SelectedValue;
            Model.TipClanarine tipClanarine = await _tipClanarineService.GetById<Model.TipClanarine>(index);
            DateTime datumDodavanja = dtpDatumDodavanja.Value;
            dtpDatumIsteka.Value = datumDodavanja.AddDays(tipClanarine.Trajanje);
        }

        private async void dtpDatumDodavanja_ValueChanged(object sender, EventArgs e)
        {
            await AutoDate();
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            ClanarinaInsertRequest request = new ClanarinaInsertRequest();
            request.KorisnikId = _clanId;
            request.DatumDodavanja = dtpDatumDodavanja.Value;
            request.DatumIsteka = dtpDatumIsteka.Value;
            request.TipClanarineId = (int)cmbTipClanarine.SelectedValue;
            Model.TipClanarine tipClanarine = await _tipClanarineService.GetById<Model.TipClanarine>(request.TipClanarineId);
            request.Cijena = tipClanarine.Cijena;

            Model.Clanarina entity = null;
            entity = await _service.Insert<Model.Clanarina>(request);
            if(tipClanarine != null)
            {
                MessageBox.Show("Uspjesno ste dodali clanarinu!");
                await LoadClanarine();
            }
        }

        private async void dgvClanarine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                int clanarinaId = Int32.Parse(dgvClanarine.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                await _service.Delete<Model.Clanarina>(clanarinaId);
                await LoadClanarine();
            }
        }
    }
}
