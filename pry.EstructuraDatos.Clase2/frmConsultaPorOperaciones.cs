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
    public partial class frmConsultaPorOperaciones : Form
    {
        public frmConsultaPorOperaciones()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsBaseDatos objBase = new clsBaseDatos();
            String VarSQL = "SELECT * FROM LIBRO";
            switch (cbOperaciones.SelectedIndex)
            {
                //Diferencia
                case 0:
                    lblMuestra.Text = cbOperaciones.Text + ":          " 
                        + "Idiomas que NO tienen libros";
                    VarSQL = "select * from idioma where " +
                        " ididioma not in " +
                        "(select ididioma from libro)";
                    objBase.Listar(dgvGrilla,VarSQL);
                    break;

                //Intersección
                case 1:
                    lblMuestra.Text = cbOperaciones.Text + ":          "+
                        "Idiomas que Si tienen libros";
                    VarSQL = "select * from idioma where "
                        + "IdIdioma in " + 
                        " (select IdIdioma from libro)";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;

                //Juntar
                case 2:
                    lblMuestra.Text = cbOperaciones.Text + ":          " +
                        "Autores y Paises";
                    VarSQL = "SELECT Autor, Pais " +
                "from  LIBRO  inner join  PAIS " +
                "on LIBRO.IdPais = Pais.IdPais  " 
                + "from LIBRO inner join Autor " +
                "on LIBRO.idAutor = Autor.IdAutor";

                    objBase.Listar(dgvGrilla, VarSQL);


                    break;
            }
        }
    }
}
