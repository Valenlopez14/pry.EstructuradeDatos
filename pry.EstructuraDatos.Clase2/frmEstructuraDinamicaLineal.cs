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
    public partial class frmEstructuraDinamicaLineal : Form
    {
        public frmEstructuraDinamicaLineal()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmEstructuraDinamicaLineal_Load(object sender, EventArgs e)
        {

        }

        clsCola FilaDePersonas = new clsCola();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsNodo objNodo = new clsNodo();
            objNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
            objNodo.Nombre = txtNombre.Text;
            objNodo.Tramite = txtTramite.Text;


            FilaDePersonas.Agregar(objNodo);
            FilaDePersonas.Recorrer(dgvGrilla);
            FilaDePersonas.Recorrer(ListBoxLista);
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTramite.Text = "";        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (FilaDePersonas.Primero != null)
            {
               txtCodigoEliminar.Text = FilaDePersonas.Primero.Codigo.ToString();
               txtNombreEliminar.Text = FilaDePersonas.Primero.Nombre;
               txtTramiteEliminar.Text = FilaDePersonas.Primero.Tramite;
                FilaDePersonas.Eliminar();
                FilaDePersonas.Recorrer(dgvGrilla);
                FilaDePersonas.Recorrer(ListBoxLista);
            }
            else
            {
                txtCodigoEliminar.Text = "";
                txtNombreEliminar.Text = "";
                txtTramiteEliminar.Text = "";

            }
        }
        private void BuenasPracticas()
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtTramite.Text != "")
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }

        private void BuenasPracticasEliminar()
        {
            if (txtCodigoEliminar.Text != "" && txtNombreEliminar.Text != "" && txtTramiteEliminar.Text != "")
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
        }

        private void txtCodigoEliminar_TextChanged(object sender, EventArgs e)
        {
            BuenasPracticasEliminar();
        }

        private void txtNombreEliminar_TextChanged(object sender, EventArgs e)
        {
            BuenasPracticasEliminar();
        }

        private void txtTramiteEliminar_TextChanged(object sender, EventArgs e)
        {
            BuenasPracticasEliminar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            BuenasPracticas();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            BuenasPracticas();
        }

        private void txtTramite_TextChanged(object sender, EventArgs e)
        {
            BuenasPracticas();
        }
    }
}
