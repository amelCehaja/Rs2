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
using WinUI.Properties;

namespace WinUI.PlanIProgram
{
    public partial class frmDodajKategoriju : Form
    {
        private readonly APIService _service = new APIService("PlanKategorija");
        private int? _kategorijaId;

        public frmDodajKategoriju(int? id)
        {
            _kategorijaId = id;
            InitializeComponent();
        }

        private async void frmDodajKategoriju_Load(object sender, EventArgs e)
        {
           if(_kategorijaId != null)
            {
                Model.PlanKategorija kategorija = await _service.GetById<Model.PlanKategorija>(_kategorijaId);
                textBox1.Text = kategorija.Naziv;
            }
        }

        private async Task<bool> NazivExists()
        {
            PlanKategorijaSearchRequest request = new PlanKategorijaSearchRequest
            {
                Naziv = textBox1.Text
            };
            var list = await _service.Get<List<Model.PlanKategorija>>(request);
            if (list.Count > 0 && _kategorijaId == null)
            {
                return true;
            }
            else if (list.Count > 0 && _kategorijaId != null)
            {
                if (list[0].Id != _kategorijaId)
                {
                    return true;
                }
            }
            return false;
        }
        
        private async void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, Resources.Validation_Required);
                e.Cancel = true;
            }
            else if(!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                bool exists = await NazivExists();
                if(exists == true)
                {
                    errorProvider1.SetError(textBox1, "Naziv postoji!");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(textBox1, null);
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            _kategorijaId = null;
        }

        private async Task Novi()
        {
            if (ValidateChildren())
            {
                PlanKategorijaInsertRequest request = new PlanKategorijaInsertRequest
                {
                    Naziv = textBox1.Text
                };
                Model.PlanKategorija entity = null;
                entity = await _service.Insert<Model.PlanKategorija>(request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste dodali misic!");
                    this.Close();
                }
            }
        }

        private async Task Izmjena()
        {
            if (ValidateChildren())
            {
                if (_kategorijaId == null)
                {
                    MessageBox.Show("Niste odabrali kategoriju za izmjenu!");
                    return;
                }
                Model.PlanKategorija request = new Model.PlanKategorija
                {
                    Id = _kategorijaId ?? default,
                    Naziv = textBox1.Text
                };
                Model.PlanKategorija entity = null;
                entity = await _service.Update<Model.PlanKategorija>(_kategorijaId ?? default, request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste izmjenili kategoriju!");
                    this.Close();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool exists = await NazivExists();
            if(exists == false)
            {
                if (_kategorijaId == null)
                    await Novi();
                else
                    await Izmjena();
            }
        }

        private void frmDodajKategoriju_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListaKategorijaPiP frm = new frmListaKategorijaPiP();
            frm.Show();
        }
    }
}
