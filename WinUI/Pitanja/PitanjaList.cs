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
    public partial class PitanjaList : Form
    {
        private readonly APIService _komentarService = new APIService("Komentar");
        private readonly APIService _planService = new APIService("PlanIProgram");
        public PitanjaList()
        {
            InitializeComponent();
        }

        private async void PitanjaList_Load(object sender, EventArgs e)
        {
            List<Model.Komentar> pitanja = await _komentarService.Get<List<Model.Komentar>>(null);
            foreach(var x in pitanja)
            {
                x.DatumString = x.Datum.ToString("dd.MM.yyyy");
                var _plan = await _planService.GetById<Model.PlanIProgram>(x.PlanId);
                x.Plan = _plan.Naziv;
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = pitanja;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3)
            {
                Model.Komentar pitanje = new Model.Komentar
                {
                    DatumString = dataGridView1.Rows[e.RowIndex].Cells["DatumString"].Value.ToString(),
                    ImePrezime = dataGridView1.Rows[e.RowIndex].Cells["ImePrezime"].Value.ToString(),
                    Opis = dataGridView1.Rows[e.RowIndex].Cells["Opis"].Value.ToString(),
                    Plan = dataGridView1.Rows[e.RowIndex].Cells["PlanIProgram"].Value.ToString(),
                    Id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value,
                    PlanId = (int)dataGridView1.Rows[e.RowIndex].Cells["PlanId"].Value
                };
                Pitanje frm = new Pitanje(pitanje);
                frm.Show();
                this.Close();
            };
        }
    }
}
