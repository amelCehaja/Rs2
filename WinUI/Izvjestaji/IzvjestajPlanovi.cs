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

namespace WinUI.Izvjestaji
{
    public partial class IzvjestajPlanovi : Form
    {
        private readonly APIService _korisnikPlanService = new APIService("korisnikPlan");
        private readonly APIService _planService = new APIService("PlanIProgram");

        public IzvjestajPlanovi()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            double _ukupnaZarada = 0;
            List<Model.PlanIProgram> planList = await _planService.Get<List<Model.PlanIProgram>>(null);
            List<Model.IzvjestajPlanIProgram> izvjestajPlanIProgramList = new List<IzvjestajPlanIProgram>();
            foreach (var x in planList)
            {
                double _zarada = 0;
                int _brojProdanih = 0;
                KorisnikPlanSearchRequest request = new KorisnikPlanSearchRequest { PlanId = x.Id };
                List<Model.KorisnikPlan> korisnikPlanList = await _korisnikPlanService.Get<List<KorisnikPlan>>(request);
                foreach (var y in korisnikPlanList)
                {
                    if (y.DatumVrijemeKupovine.Date > dateTimePicker1.Value && y.DatumVrijemeKupovine.Date < dateTimePicker2.Value)
                    {
                        _ukupnaZarada += x.Cijena;
                        _zarada += x.Cijena;
                        _brojProdanih ++;
                    }
                }
                if(_brojProdanih > 0)
                {
                    Model.IzvjestajPlanIProgram izvjestajPlan = new IzvjestajPlanIProgram
                    {
                        Naziv = x.Naziv,
                        UkupnaZarada = _zarada,
                        BrojProdanih = _brojProdanih
                    };
                    izvjestajPlanIProgramList.Add(izvjestajPlan);
                }
            }
            label4.Text = _ukupnaZarada.ToString() + " KM";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = izvjestajPlanIProgramList;
        }

        private void IzvjestajPlanovi_Load(object sender, EventArgs e)
        {

        }
    }
}
