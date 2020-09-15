using Model;
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
            List<Model.PlanIProgram> planList = 
            List<Model.KorisnikPlan> korisnikPlanList = await _korisnikPlanService.Get<List<KorisnikPlan>>(null);
            List<Model.IzvjestajPlanIProgram> izvjestajPlanIProgramList = new List<IzvjestajPlanIProgram>();
            foreach(var x in korisnikPlanList)
            {
                if(x.DatumVrijemeKupovine.Date > dateTimePicker1.Value && x.DatumVrijemeKupovine.Date < dateTimePicker2.Value)
                {

                }
            }
        }
    }
}
