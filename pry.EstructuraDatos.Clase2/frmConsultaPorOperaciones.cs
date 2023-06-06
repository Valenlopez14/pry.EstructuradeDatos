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
                        "Libros y Autores";
                    VarSQL = "SELECT TITULO, NOMBRE " +
                "from  LIBRO  inner join  AUTOR " +
                "on LIBRO.IdAutor = Autor.IdAutor ";

                    objBase.Listar(dgvGrilla, VarSQL);


                    break;
                //Proyeccion Simple
                case 3:
                    lblMuestra.Text = cbOperaciones.Text + ":          " +
                        "Todos los Nombres de Autores";
                    VarSQL = "SELECT Nombre FROM Autor ";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;
                //Proyección Multiatributo
                case 4:
                    lblMuestra.Text = cbOperaciones.Text + ":       " +
                        "Proyecta Titulo, Cantidad, Pais";
                    VarSQL = "Select Titulo, Cantidad, idPais from Libro";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;

                //Selección Multiatributo con operador AND
                case 5:
                    lblMuestra.Text = cbOperaciones.Text + ":       " +
                        "Muestra los Libros de Ucrania " +
                        "escritos por Carlos ";
                    VarSQL = "SELECT * FROM Libro Where idPais = 2 AND idAutor = 2";
                    objBase.Listar(dgvGrilla,VarSQL);

                    break;

                //Seleecion MultiAtributo con operador OR
                case 6:
                    lblMuestra.Text = cbOperaciones.Text + ":       " +
                        "Los Libros escritos por Sófocles o Ralph Ellison";
                    VarSQL = "SELECT * FROM Libro Where idAutor = 17 OR idAutor =21";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;
                //Seleccion por Convolucion
                case 7:
                    lblMuestra.Text = cbOperaciones.Text + ":       " +
                        "Libros que cuestan menos 500 de en Idioma Aleman ";
                    VarSQL = "Select * " +
                        " FROM (Select Cantidad, Titulo, idIdioma, Precio from Libro where Precio < 500) as X " +
                        "WHERE idIdioma = 3";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;

                 //Seleccion simple
                 case 8:
                    lblMuestra.Text = cbOperaciones.Text + ":        " +
                        "Muestra los Libros en Idioma Ingles";
                    VarSQL = "SELECT TITULO from Libro where IdIdioma = 1 ";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;

                //Union
                case 9:
                    lblMuestra.Text = cbOperaciones.Text + ":       " +
                        "Muestra la Informacion de los Libros en Nórdico Antiguo y Griego Moderno";
                    VarSQL = "Select * FROM Libro WHERE IdIdioma = 23 " +
                        " union " +
                        " SELECT * FROM Libro where IdIdioma = 24 ";
                    objBase.Listar(dgvGrilla, VarSQL);
                    break;
            }
        }
    }
}
