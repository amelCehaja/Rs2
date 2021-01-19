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
    public partial class frmPlanDetails : Form
    {
        private int _planId;
        private int _danId;
        private string _naziv;
        private readonly APIService _danService = new APIService("Dan");
        private readonly APIService _vjezbaService = new APIService("Vjezba");
        private readonly APIService _setVjezbaService = new APIService("SetVjezba");
        private readonly APIService _danSetService = new APIService("DanSet");
        public frmPlanDetails(Model.PlanIProgram planIProgram)
        {
            _planId = planIProgram.Id;
            _naziv = planIProgram.Naziv;
            InitializeComponent();
        }
        private async Task LoadDani()
        {
            DanSearchRequest request = new DanSearchRequest
            {
                PlanIProgramId = _planId
            };
            List<Model.Dan> dani = await _danService.Get<List<Model.Dan>>(request);
            dani.OrderBy(x => x.RedniBroj);
            dani.ForEach(x =>
            {
                x.Naziv = x.RedniBroj.ToString() + ". Dan";
            });
            dgvDani.AutoGenerateColumns = false;
            dgvDani.DataSource = dani;
        }
        private async Task LoadVjezbe()
        {
            List<Model.Vjezba> vjezbe = await _vjezbaService.Get<List<Model.Vjezba>>(null);
            cmbVjezbe.DisplayMember = "Naziv";
            cmbVjezbe.ValueMember = "Id";
            cmbVjezbe.DataSource = vjezbe;
            cmbVjezbe.SelectedIndex = 0;
        }
        private async Task LoadRedniBrojevi(int danId)
        {
            DanSetSearchRequest request = new DanSetSearchRequest
            {
                DanId = danId
            };
            List<Model.DanSet> danSetovi = await _danSetService.Get<List<Model.DanSet>>(request);
            danSetovi.OrderBy(x => x.RedniBroj);
            Model.DanSet danSet = new Model.DanSet
            {
                RedniBroj = danSetovi.Count() + 1
            };
            danSetovi.Add(danSet);
            cmbRedniBroj.DisplayMember = "RedniBroj";
            cmbRedniBroj.ValueMember = "RedniBroj";
            cmbRedniBroj.DataSource = danSetovi;
            cmbRedniBroj.SelectedIndex = danSetovi.Count()-1;
        }
        private async Task LoadSetovi()
        {
            DanSetSearchRequest request = new DanSetSearchRequest
            {
                DanId = _danId
            };
            List<Model.DanSet> result = await _danSetService.Get<List<Model.DanSet>>(request);
            dgvVjezbe.AutoGenerateColumns = false;
            dgvVjezbe.DataSource = result;
        }
        private async void frmPlanDetails_Load(object sender, EventArgs e)
        {
            planIProgramNaziv.Text = _naziv;
            await LoadDani();
            await LoadVjezbe();
        }
        private async void btnDodajDan_Click(object sender, EventArgs e)
        {
            DanInsertRequest request = new DanInsertRequest
            {
                PlanIProgramId = _planId
            };
            Model.Dan entity = null;
            entity = await _danService.Insert<Model.Dan>(request);
            if(entity != null)
            {
                MessageBox.Show("Uspjesno ste dodali dan!");
                await LoadDani();
                
            }
        }
        private async void dgvDani_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grbDan.Text = dgvDani.Rows[e.RowIndex].Cells["Dan"].Value.ToString();
            _danId = Int32.Parse(dgvDani.Rows[e.RowIndex].Cells["DanId"].Value.ToString());
            await LoadRedniBrojevi(_danId);
            await LoadSetovi();
        }
        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            DanSetInsertRequest request = new DanSetInsertRequest
            {
                DanId = _danId,
                VjezbaId = (int)cmbVjezbe.SelectedValue,
                RedniBroj = (int)cmbRedniBroj.SelectedValue
            };
            Model.DanSet entity = null;
            entity = await _danSetService.Insert<Model.DanSet>(request);
            if(entity != null)
            {
                MessageBox.Show("Uspjesno ste dodali!");
                await LoadRedniBrojevi(_danId);
                await LoadSetovi();
            }
        }

        private async void dgvVjezbe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                Model.DanSet danSet = new Model.DanSet
                {
                    Id = Int32.Parse(dgvVjezbe.Rows[e.RowIndex].Cells["Id"].Value.ToString()),
                    Vjezba = dgvVjezbe.Rows[e.RowIndex].Cells["Vjezba"].Value.ToString(),
                    RedniBroj = Int32.Parse(dgvVjezbe.Rows[e.RowIndex].Cells["RedniBroj"].Value.ToString())
                };
                frmVjezbaSet frm = new frmVjezbaSet(danSet);
                frm.Show();
            }
            else if (e.ColumnIndex == 4)
            {
                int _id = Int32.Parse(dgvVjezbe.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                await _danSetService.Delete<Model.DanSet>(_id);
                SetVjezbaSearchRequest request = new SetVjezbaSearchRequest
                {
                    DanSetId = _id
                };
                List<Model.SetVjezba> entity = await _setVjezbaService.Get<List<Model.SetVjezba>>(request);
                foreach(var x in entity)
                {
                    await _setVjezbaService.Delete<Model.SetVjezba>(x.Id);
                }
                await LoadSetovi();
            }
        }
    }
}
