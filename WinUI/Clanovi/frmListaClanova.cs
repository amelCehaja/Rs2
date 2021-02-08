using Model;
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
using WinUI.Clanarina;

namespace WinUI.Clanovi
{
    public partial class frmListaClanova : Form
    {
        APIService _service = new APIService("Korisnik");

        public frmListaClanova()
        {
            InitializeComponent();
        }
        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            LoadClanovi();
        }
        private async void LoadClanovi()
        {
            var search = new KorisniciSearchRequest()
            {
                Ime = txtSearchIme.Text,
                Prezime = txtSearchPrezime.Text
            };
            var result = await _service.Get<List<Korisnik>>(search);

            dgvClanovi.AutoGenerateColumns = false;
            dgvClanovi.DataSource = result;
        }

        private void frmListaClanova_Load(object sender, EventArgs e)
        {
            LoadClanovi();
        }

        private void dgvClanovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                int ClanID = Int32.Parse(dgvClanovi.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmDodajClana _frmDodajClana = new frmDodajClana(ClanID);
                _frmDodajClana.Show();
                this.Close();
            }
            else if(e.ColumnIndex == 7)
            {
                int ClanID = Int32.Parse(dgvClanovi.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                frmClanarine _frmClanarine = new frmClanarine(ClanID);
                _frmClanarine.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDodajClana _frmDodajClana = new frmDodajClana(null);
            _frmDodajClana.Show();
            this.Close();
        }
      
    }
}
