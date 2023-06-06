using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry.EstructuraDatos.Clase2
{
    public partial class frmEstructura : Form
    {
        public frmEstructura()
        {
            InitializeComponent();
        }

        private void datosProgramadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatosProgramador frmDatosProgramador = new frmDatosProgramador();
            frmDatosProgramador.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void colaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstructuraDinamicaLineal frmEstructuraDinamicaLineal = new frmEstructuraDinamicaLineal();
            frmEstructuraDinamicaLineal.ShowDialog();
        }

        private void pilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPila frmPila = new frmPila();
            frmPila.ShowDialog();
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaSimple frmListaSimple = new frmListaSimple();
            frmListaSimple.ShowDialog();
        }

        private void dobleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaDoblementeEnlazada frmListaDoblementeEnlazada = new frmListaDoblementeEnlazada();
            frmListaDoblementeEnlazada.ShowDialog();
        }

        private void arbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArbolBinario frmArbol = new frmArbolBinario();
                frmArbol.ShowDialog();
        }

        private void arbolToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmArbolBinario frmArbol = new frmArbolBinario();
            frmArbol.ShowDialog();
        }

        private void baseDeDatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBaseDeDatos frmBase = new frmBaseDeDatos();
            frmBase.ShowDialog();
        }

        private void consultasEnBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultasBD frmConsul = new frmConsultasBD();
            frmConsul.ShowDialog();
        }

        private void repasoDeOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaPorOperaciones frmConsultas = new frmConsultaPorOperaciones();
            frmConsultas.ShowDialog();
        }
    }
}
