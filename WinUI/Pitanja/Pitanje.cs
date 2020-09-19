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

namespace WinUI.Pitanja
{
    public partial class Pitanje : Form
    {
        private int planId;
        private int? nadkomentarId;
        private readonly APIService _komentarService = new APIService("Komentar");
        public Pitanje(Model.Komentar pitanje)
        {
            InitializeComponent();
            txtPlan.Text = pitanje.Plan;
            txtPitanje.Text = pitanje.Opis;
            txtKorisnik.Text = pitanje.ImePrezime;
            txtDatum.Text = pitanje.DatumString;
            planId = pitanje.PlanId;
            nadkomentarId = pitanje.Id;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Pitanje_Load(object sender, EventArgs e)
        {

        }

        private async void btnOdgovori_Click(object sender, EventArgs e)
        {
            KomentarInsertRequest request = new KomentarInsertRequest
            {
                Datum = DateTime.Today,
                Opis = txtOdgovor.Text,
                KorisnikId = APIService.UserId,
                PlanId = planId,
                NadkomentarId = nadkomentarId
                
            };
            await _komentarService.Insert<Model.Komentar>(request);
            MessageBox.Show("Uspjesno ste odgovorili na pitanje", "", MessageBoxButtons.OK);
            this.Hide();
            PitanjaList frm = new PitanjaList();
            frm.Show();
        }
    }
}
