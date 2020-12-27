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

        public frmDodajKategoriju()
        {
            InitializeComponent();
        }

        private async void frmDodajKategoriju_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
        }
        private async Task LoadKategorije()
        {
            List<Model.PlanKategorija> kategorije = await _service.Get<List<Model.PlanKategorija>>(null);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = kategorije;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _kategorijaId = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Naziv"].Value.ToString();
        }

        private async void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, Resources.Validation_Required);
            }
            else
            {
                PlanKategorijaSearchRequest request = new PlanKategorijaSearchRequest
                {
                    Naziv = textBox1.Text
                };
                var list = await _service.Get<List<Model.PlanKategorija>>(request);
                if (list.Count > 0 && _kategorijaId == null)
                {
                    errorProvider1.SetError(textBox1, "Naziv postoji u bazi!");
                }
                else if (list.Count > 0 && _kategorijaId != null)
                {
                    if (list[0].Id != _kategorijaId)
                    {
                        errorProvider1.SetError(textBox1, "Naziv postoji u bazi!");
                    }
                }
            }
        }

        private void Clear()
        {
            textBox1.Text = "";
            _kategorijaId = null;
        }

        private async void button1_Click(object sender, EventArgs e)
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
                    await LoadKategorije();
                    Clear();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
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
                    await LoadKategorije();
                    Clear();
                }
            }
        }
    }
}
