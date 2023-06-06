using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pry.EstructuraDatos.Clase2
{
    public partial class frmArbolBinario : Form
    {
        public frmArbolBinario()
        {
            InitializeComponent();
        }
        ArbolBinario objArbol = new ArbolBinario();
        public bool Asc;
        public string Recorrer;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (objArbol.Buscar(Convert.ToInt32(txtCodigo.Text)) == false)
            {
                clsNodo objNodo = new clsNodo();

                objNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
                objNodo.Nombre = txtNombre.Text;
                objNodo.Tramite = txtTramite.Text;
                StreamWriter Sw = new StreamWriter("./Hoja.csv", false);

                objArbol.Agregar(objNodo);


                   objArbol.Recorrer(lstCodigoEliminado);
                   objArbol.Recorrer(dgvGrilla);
                   objArbol.Recorrer(ListBoxLista);
                   objArbol.Recorrer(treeView);
                   objArbol.RecorrerSW(Sw);

 

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtTramite.Text = "";
                Sw.Close();
                Sw.Dispose();
            }
            else
            {
                MessageBox.Show("El codigo ya Existe", "ERROR");
            }
               

        }

        private void rbInOrden_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((objArbol.Raiz != null) && (lstCodigoEliminado.SelectedIndex != -1))
            {
                objArbol.Eliminar(Convert.ToInt32(lstCodigoEliminado.SelectedItem));
                SeleccionRecorrido();
                RecorrerElementos();


                if (objArbol.Raiz == null)
                {
                    dgvGrilla.Rows.Clear();
                    lstCodigoEliminado.Items.Clear();
                    ListBoxLista.Items.Clear();
                    treeView.Nodes.Clear();
                    File.Delete("./Hoja.csv");
                }

            }
            else
            {
                MessageBox.Show("No se encuentran datos");
            }
            txtCodigo.Focus();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public void EstadoInOrden()
        {
            if (btnInOrden.Checked)
            {
                btnAscendente.Enabled = true;
                btnDescendente.Enabled = true;
            }
            else
            {
                btnAscendente.Enabled = false;
                btnDescendente.Enabled = false;
            }
        }
        public void SeleccionRecorrido()
        {
            if (btnInOrden.Checked)
            {
                Recorrer = "InOrden";
                if (btnAscendente.Checked)
                {
                    Asc = true;
                }
                else if (btnDescendente.Checked)
                {
                    Asc = false;
                }
            }
            else if (btnPostOrden.Checked)
            {
                Recorrer = "PostOrden";
            }
            else if (btnPreOrden.Checked)
            {
                Recorrer = "PreOrden";
            }
        }
        public void RecorrerElementos()
        {
            if (objArbol.Raiz != null)
            {
                StreamWriter Sw= new StreamWriter("./Hoja.txt", false);
                objArbol.Recorrer(Sw, Asc, Recorrer);
                Sw.Close();
                Sw.Dispose();
                objArbol.Recorrer(ListBoxLista, Asc, Recorrer);
                objArbol.Recorrer(lstCodigoEliminado, Asc, Recorrer);
                objArbol.Recorrer(dgvGrilla, Recorrer, Asc);
                objArbol.Recorrer(treeView);
                treeView.ExpandAll();

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
            if (lstCodigoEliminado.SelectedIndex != -1)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
        }

        private void frmArbolBinario_Load(object sender, EventArgs e)
        {

        }

        private void lstCodigoEliminado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuenasPracticasEliminar();
        }

        private void ListBoxLista_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void btnAscendente_CheckedChanged(object sender, EventArgs e)
        {
            if (objArbol.Raiz != null)
            {
                objArbol.Recorrer(ListBoxLista);
                objArbol.Recorrer(lstCodigoEliminado);
               objArbol.Recorrer(dgvGrilla);
               objArbol.RecorrerPreOrden(treeView);
            }
        }

        private void btnDescendente_CheckedChanged(object sender, EventArgs e)
        {
            if (objArbol.Raiz != null)
            {
                objArbol.RecorrerDesc(lstCodigoEliminado);
                objArbol.RecorrerDesc(ListBoxLista);
                objArbol.Recorrerdesc(dgvGrilla);
                objArbol.RecorrerPreOrden(treeView);
            }
        }

        private void btnPostOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (objArbol.Raiz != null)
            {
                objArbol.RecorrerPostOrden(lstCodigoEliminado);
                objArbol.RecorrerPostOrden(ListBoxLista);
                objArbol.RecorrerPostOrden(dgvGrilla);
                objArbol.RecorrerPreOrden(treeView);

            }
        }

        private void btnPreOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (objArbol.Raiz != null)
            {
                objArbol.RecorrerPreOrden(lstCodigoEliminado);
                objArbol.RecorrerPreOrden(ListBoxLista);
                objArbol.RecorrerPreOrden(dgvGrilla);
                objArbol.RecorrerPreOrden(treeView);

            }
        }

        private void cmdEquilibrar_Click(object sender, EventArgs e)
        {
            objArbol.Equilibrar();
            objArbol.Recorrer(ListBoxLista);
            objArbol.Recorrer(dgvGrilla);
            objArbol.Recorrer(lstCodigoEliminado);
            objArbol.RecorrerPreOrden(treeView);
        }
    }
}
