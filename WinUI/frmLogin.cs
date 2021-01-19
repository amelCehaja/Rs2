using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Clanovi;

namespace WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("clanarina");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                List<Model.Korisnik> korisnici = await _service.Get<List<Model.Korisnik>>(null);
                APIService.UserId = korisnici.Where(x => x.Username == APIService.Username).Select(x => x.Id).SingleOrDefault();
                await _service.Get<dynamic>(null);
                this.Hide();
                frmMenu frm = new frmMenu(); 
                frm.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Niste authentificirani");
            }
        }
    }
}
