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
using WinUI.Misic;
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
            frmTipoviClanarine frm = new frmTipoviClanarine();
            frm.Show();
        }

        private void btnNoviClan_Click(object sender, EventArgs e)
        {
            frmDodajClana frm = new frmDodajClana();
            frm.Show();
        }

        private void btnPrisutnost_Click(object sender, EventArgs e)
        {
            frmPrisutnostClana frm = new frmPrisutnostClana();
            frm.Show();
        }

        private void btnMisici_Click(object sender, EventArgs e)
        {
            frmMisic frm = new frmMisic();
            frm.Show();
        }

        private void btnVjezba_Click(object sender, EventArgs e)
        {
            frmVjezba frm = new frmVjezba();
            frm.Show();
        }

        private void btnPlanIProgram_Click(object sender, EventArgs e)
        {
            frmPlanIProgram frm = new frmPlanIProgram();
            frm.Show();
        }
    }
}
