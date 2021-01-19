using Flurl.Http;
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

namespace WinUI.PrisutnostClana
{
    public partial class frmPrisutnostClana : Form
    {
        private readonly APIService _service = new APIService("PrisutnostClana");
        private readonly APIService _korisnikService = new APIService("Korisnik");
        private readonly APIService _clanarinaService = new APIService("Clanarina");
        public frmPrisutnostClana()
        {
            InitializeComponent();
        }

        private async Task LoadPrisutne()
        {
            var prisutnostClana = await _service.Get<List<Model.PrisutnostClana>>(null);
            dgvPrisutnost.AutoGenerateColumns = false;
            dgvPrisutnost.DataSource = prisutnostClana;
            foreach (DataGridViewRow row in dgvPrisutnost.Rows)
            {
                if (row.Cells["Aktivan"].Value.ToString() == "True")
                {
                    row.DefaultCellStyle.BackColor = Color.ForestGreen;
                }
                else if(row.Cells["Aktivan"].Value.ToString() == "False")
                {
                    row.DefaultCellStyle.BackColor = Color.Red; 
                }
            }
        }

        private async void frmPrisutnostClana_Load(object sender, EventArgs e)
        {
            await LoadPrisutne();
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            Model.Korisnik korisnik = new Model.Korisnik();
            KorisniciSearchRequest korisniciSearchRequest = new KorisniciSearchRequest
            {
                BrojKartice = txtBrojKartice.Text
            };
            List<Model.Korisnik> korisnici = await _korisnikService.Get<List<Model.Korisnik>>(korisniciSearchRequest);
            if(korisnici.Count == 1)
            {
                korisnik = korisnici[0];
            }
            if (korisnik == null)
            {
                MessageBox.Show("Korisnik sa unesenom karticom ne postoji!");
                return;
            }
            ClanarinaSearchRequest clanarinaSearchRequest = new ClanarinaSearchRequest
            {
                KorisnikId = korisnik.Id
            };

            Model.PrisutnostClana prisutnostClana;
            PrisutnostClanaSearchRequest request = new PrisutnostClanaSearchRequest
            {
                BrojKartice = txtBrojKartice.Text
            };
            List<Model.PrisutnostClana> result = await _service.Get<List<Model.PrisutnostClana>>(request);
            if (result.Count == 0)
            {
                PrisutnostClanaInsertRequest insertRequest = new PrisutnostClanaInsertRequest
                {
                    Date = DateTime.Today,
                    KorisnikId = korisnik.Id,
                    VrijemeDolaska = DateTime.Now.TimeOfDay
                };
                
                prisutnostClana = await _service.Insert<Model.PrisutnostClana>(insertRequest);
                if (prisutnostClana != null)
                {
                    MessageBox.Show("Uspjesno dodan clan na listu prisutnih!");
                }
            }
            else
            {
                prisutnostClana = new Model.PrisutnostClana
                {
                    Id = result[0].Id,
                    KorisnikId = result[0].KorisnikId,
                    VrijemeDolaska = result[0].VrijemeDolaska,
                    VrijemeOdlaska = DateTime.Now.TimeOfDay
                };
                Model.PrisutnostClana entity;
                entity = await _service.Update<Model.PrisutnostClana>(result[0].Id, prisutnostClana);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste uklonili clana sa liste prisutnih!");
                }
            }
            await LoadPrisutne();
        }
    }
}
