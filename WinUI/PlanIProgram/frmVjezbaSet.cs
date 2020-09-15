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
    public partial class frmVjezbaSet : Form
    {
        private int _id;
        private string _vjezba;
        private int _redniBroj;
        private readonly APIService _setVjezbaService = new APIService("SetVjezba");
        public frmVjezbaSet(Model.DanSet danSet)
        {
            InitializeComponent();
            _id = danSet.Id;
            _vjezba = danSet.Vjezba;
            _redniBroj = danSet.RedniBroj;
        }

        private async    void frmVjezbaSet_Load(object sender, EventArgs e)
        {
            txtDan.Text = _redniBroj.ToString() + ". Dan";
            txtVjezba.Text = _vjezba;
            await LoadSetVjezbe();
        }
        private async Task LoadSetVjezbe()
        {
            SetVjezbaSearchRequest request = new SetVjezbaSearchRequest
            {
                DanSetId = _id
            };
            List<Model.SetVjezba> entity = await _setVjezbaService.Get<List<Model.SetVjezba>>(request);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = entity;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                SetVjezbaInsertRequest request = new SetVjezbaInsertRequest
                {
                    DanSetId = _id,
                    TrajanjeOdmora = Int32.Parse(txtTrajanjeOdmora.Text),
                    BrojPonavljanja = Int32.Parse(txtBrojPonavljanja.Text)
                };
                Model.SetVjezba entity = null;
                entity = await _setVjezbaService.Insert<Model.SetVjezba>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno dodano!");
                    await LoadSetVjezbe();
                }
            }
        }

        private void txtBrojPonavljanja_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojPonavljanja.Text))
                errorProvider1.SetError(txtBrojPonavljanja, Resources.Validation_Required);
            else if (!Regex.Match(txtBrojPonavljanja.Text, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
                errorProvider1.SetError(txtBrojPonavljanja, "Dozvoljeni su samo brojevi!");
        }

        private void txtDuzinaOdmora_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrajanjeOdmora.Text))
                errorProvider1.SetError(txtTrajanjeOdmora, Resources.Validation_Required);
            else if (!Regex.Match(txtTrajanjeOdmora.Text, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
                errorProvider1.SetError(txtTrajanjeOdmora, "Dozvoljeni su samo brojevi!");
        }
    }
}
