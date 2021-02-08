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
using WinUI.Izvjestaji;
using WinUI.Misic;
using WinUI.Pitanja;
using WinUI.PlanIProgram;
using WinUI.PrisutnostClana;
using WinUI.TipoviClanarine;
using WinUI.Vjezba;

namespace WinUI
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnTipoviClanarine_Click(object sender, EventArgs e)
        {
            frmListaTipovaClanarine frm = new frmListaTipovaClanarine();
            frm.Show();
        }

        private void btnNoviClan_Click(object sender, EventArgs e)
        {
            frmListaClanova frm = new frmListaClanova();
            frm.Show();
        }

        private void btnPrisutnost_Click(object sender, EventArgs e)
        {
            frmPrisutnostClana frm = new frmPrisutnostClana();
            frm.Show();
        }

        private void btnMisici_Click(object sender, EventArgs e)
        {
            frmListaMisica frm = new frmListaMisica();
            frm.Show();
        }

        private void btnVjezba_Click(object sender, EventArgs e)
        {
            frmListaVjezbi frm = new frmListaVjezbi();
            frm.Show();
        }

        private void btnPlanIProgram_Click(object sender, EventArgs e)
        {
            frmListaPlanIProgram frm = new frmListaPlanIProgram();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IzvjestajPlanovi frm = new IzvjestajPlanovi();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmIzvjestajClanovi frm = new frmIzvjestajClanovi();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PitanjaList frm = new PitanjaList();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmListaKategorijaPiP frm = new frmListaKategorijaPiP();
            frm.Show();
        }
    }
}
