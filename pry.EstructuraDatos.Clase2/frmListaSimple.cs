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
    public partial class frmListaSimple : Form
    {
        clsListaSimple clsListaSimple = new clsListaSimple();

        public frmListaSimple()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsNodo objNodo = new clsNodo();
            objNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
            objNodo.Nombre = txtNombre.Text;
            objNodo.Tramite = txtTramite.Text;

            clsListaSimple.Agregar(objNodo);
            clsListaSimple.Recorrer(dgvGrilla);
            clsListaSimple.Recorrer(ListBoxLista);
            clsListaSimple.Recorrer(lstTramiteEliminado);

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTramite.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 combo = Convert.ToInt32(lstTramiteEliminado.SelectedItem);
            if (clsListaSimple.Primero != null)
            {

                clsListaSimple.Eliminar(combo);
                clsListaSimple.Recorrer(dgvGrilla);
                clsListaSimple.Recorrer(ListBoxLista);
                clsListaSimple.Recorrer(lstTramiteEliminado);
            }
            else
            {
                MessageBox.Show("La Lista está vacia");
                btnEliminar.Enabled = false;
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
            if (lstTramiteEliminado.SelectedIndex != -1)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
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

        private void lstTramiteEliminado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuenasPracticasEliminar();
        }
    }
}
