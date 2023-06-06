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
    public partial class frmListaDoblementeEnlazada : Form
    {
        public frmListaDoblementeEnlazada()
        {
            InitializeComponent();
        }

        clsListaDoblementeEnlazada clsListaDoble = new clsListaDoblementeEnlazada();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsNodo objNodo = new clsNodo();
            objNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
            objNodo.Nombre = txtNombre.Text;
            objNodo.Tramite = txtTramite.Text;
            clsListaDoble.Agregar(objNodo);
            clsListaDoble.Recorrer(dgvGrilla);
            clsListaDoble.Recorrer(ListBoxLista);
            clsListaDoble.Recorrer(lstCodigoEliminado);
            

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtTramite.Text = "";



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Int32 combo = Convert.ToInt32(lstCodigoEliminado.SelectedItem);
            if (clsListaDoble.Primero != null)
            {

                clsListaDoble.Eliminar(combo);
                clsListaDoble.Recorrer(dgvGrilla);
                clsListaDoble.Recorrer(ListBoxLista);
                clsListaDoble.Recorrer(lstCodigoEliminado);
                
            }
            else
            {
                MessageBox.Show("La Lista está vacia");
                btnEliminar.Enabled = false;
            }
        }

        private void boDescendente_CheckedChanged(object sender, EventArgs e)
        {
            clsListaDoble.RecorrerDes(dgvGrilla);
            clsListaDoble.RecorrerDes(ListBoxLista);
            clsListaDoble.RecorrerDes(lstCodigoEliminado);

        }

        private void boAscendente_CheckedChanged(object sender, EventArgs e)
        {
            clsListaDoble.Recorrer(dgvGrilla);
            clsListaDoble.Recorrer(ListBoxLista);
            clsListaDoble.Recorrer(lstCodigoEliminado);
        }

        private void mrcListado_Enter(object sender, EventArgs e)
        {

        }

        private void BuenasPracticas()
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtTramite.Text != "" )
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
            if (lstCodigoEliminado.SelectedIndex != -1)
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

        private void lstCodigoEliminado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuenasPracticasEliminar();
        }
    }
}
