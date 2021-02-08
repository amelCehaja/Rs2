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

namespace WinUI.Misic
{
    public partial class frmMisic : Form
    {
        private readonly APIService _service = new APIService("Misic");
        private int? _misicId;
        public frmMisic(int? MisicId)
        {
            _misicId = MisicId;
            InitializeComponent();
        }     

        private async void Misic_Load(object sender, EventArgs e)
        {
            if(_misicId != null)
            {
                var _misic = await _service.GetById<Model.Misic>(_misicId);
                txtNaziv.Text = _misic.Naziv;
            }
        }

        private async void Novi()
        {
            if (ValidateChildren())
            {
                var _misicExists = await MisicExists(true);
                if (_misicExists == false)
                {
                    MisicInsertRequest request = new MisicInsertRequest
                    {
                        Naziv = txtNaziv.Text
                    };
                    Model.Misic entity = null;
                    entity = await _service.Insert<Model.Misic>(request);
                    if (entity != null)
                    {
                        MessageBox.Show("Uspjesno ste dodali misic!");
                        this.Close();
                    }
                }
            }
        }

        private async Task<bool> MisicExists(bool New)
        {
            int? misicId = null;
            if(New == false)
            {
                misicId = _misicId;
            }
            if (!String.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MisicSearchRequest request = new MisicSearchRequest
                {
                    Naziv = txtNaziv.Text
                };
                var list = await _service.Get<List<Model.Misic>>(request);
                if (list.Count > 0 && misicId == null)
                {
                    errorProvider1.SetError(txtNaziv, "Misic vec postoji!");
                    return true;
                }
                else if (list.Count > 0 && _misicId != null)
                {
                    if (list[0].Id != misicId)
                    {
                        errorProvider1.SetError(txtNaziv, "Misic vec postoji!");
                        return true;
                    }
                }
            }
            errorProvider1.SetError(txtNaziv, null);
            return false;
        }

        private async void Izmjeni()
        {
            var _misicExists = await MisicExists(false);
            if (ValidateChildren() && _misicExists == false)
            {
                if (_misicId == null)
                {
                    MessageBox.Show("Niste odabrali misic za izmjenu!");
                    return;
                }
                Model.Misic request = new Model.Misic
                {
                    Id = _misicId ?? default,
                    Naziv = txtNaziv.Text
                };
                Model.Misic entity = null;
                entity = await _service.Update<Model.Misic>(_misicId ?? default, request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste izmjenili misic!");
                    this.Close();
                }
            }
        }

        private void Clear()
        {
            txtNaziv.Text = "";
            _misicId = null;
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Naziv ne moze biti prazan!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            if (_misicId == null)
                Novi();
            else
                Izmjeni();
        }

        private void frmMisic_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListaMisica frmListaMisica = new frmListaMisica();
            frmListaMisica.Show();
        }
    }
}
