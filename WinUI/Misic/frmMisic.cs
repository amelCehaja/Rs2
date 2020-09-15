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
        private int? MisicId;
        public frmMisic()
        {
            InitializeComponent();
        }

        private async Task LoadMisici()
        {
            List<Model.Misic> result = await _service.Get<List<Model.Misic>>(null);
            dgvMisici.AutoGenerateColumns = false;
            dgvMisici.DataSource = result;
        }

        private async void Misic_Load(object sender, EventArgs e)
        {
            await LoadMisici();
        }

        private async void btnNovi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
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
                    await LoadMisici();
                    Clear();
                }
            }
        }

        private async void btnIzmjeni_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (MisicId == null)
                {
                    MessageBox.Show("Niste odabrali misic za izmjenu!");
                    return;
                }
                Model.Misic request = new Model.Misic
                {
                    Id = MisicId ?? default,
                    Naziv = txtNaziv.Text
                };
                Model.Misic entity = null;
                entity = await _service.Update<Model.Misic>(MisicId ?? default, request);
                if (entity != null)
                {
                    MessageBox.Show("Uspjesno ste izmjenili misic!");
                    await LoadMisici();
                    Clear();
                }
            }
        }

        private void Clear()
        {
            txtNaziv.Text = "";
            MisicId = null;
        }

        private void dgvMisici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MisicId = Int32.Parse(dgvMisici.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            txtNaziv.Text = dgvMisici.Rows[e.RowIndex].Cells["Naziv"].Value.ToString();
        }
        private async void txtNaziv_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, Resources.Validation_Required);
            }
            else
            {
                MisicSearchRequest request = new MisicSearchRequest
                {
                    Naziv = txtNaziv.Text
                };
                var list = await _service.Get<List<Model.Misic>>(request);
                if (list.Count > 0 && MisicId == null)
                {
                    errorProvider1.SetError(txtNaziv, "Naziv postoji u bazi!");
                }
                else if (list.Count > 0 && MisicId != null)
                {
                    if (list[0].Id != MisicId)
                    {
                        errorProvider1.SetError(txtNaziv, "Naziv postoji u bazi!");
                    }
                }
            }
        }
    }
}
