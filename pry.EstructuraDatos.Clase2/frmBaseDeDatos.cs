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
    public partial class frmBaseDeDatos : Form
    {
        clsBaseDatos objBaseDatos;

        public frmBaseDeDatos()
        {
            InitializeComponent();
        }

        private void btnProyeccionSimple_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSQL = "Select Titulo FROM Libro ";
            objBaseDatos.Listar(dgvGrilla, varSQL);

        }

        private void btnProyeccionMultiAtributo_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSQL = "Select Titulo, Año, IdIdioma FROM Libro";
            objBaseDatos.Listar(dgvGrilla, varSQL);
        }

        private void btnSeleccionSimple_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSQL = "SELECT TITULO FROM Libro WHERE IdIdioma = 2";
            objBaseDatos.Listar(dgvGrilla, varSQL);
        }

        private void btnSeleccionMultiatributo_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSQL = "SELECT * FROM Libro WHERE IdLibro = 2 AND IdAutor > 1";
            objBaseDatos.Listar(dgvGrilla, varSQL);
        }

        private void btnUnion_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSQL = " SELECT * FROM Libro WHERE IdIdioma = 2 " +
                " union " +
                " SELECT * FROM Libro where IdIdioma = 3 ";
            objBaseDatos.Listar(dgvGrilla, varSQL);
        }

        private void btnDiferencia_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSql = "Select * from libro " +
                            " where IdIdioma=3 and IdLibro not in " +
                            " (Select IdLibro from libro where IdPais =2 )" +
                            " order by 1 asc ";
            objBaseDatos.Listar(dgvGrilla, varSql);
        }

        private void btnIntersección_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String varSql = "Select * from libro " +
                            " where IdIdioma=3 and IdLibro in " +
                            " (Select IdLibro from libro where IdPais =2 )" +
                            " order by 1 asc ";
            objBaseDatos.Listar(dgvGrilla, varSql);
        }

        private void btnSeleccionConvulc_Click(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            String VarSQL = "Select * " +
                " FROM (Select * from libro where IdIdioma > 1) as X " +
                "WHERE IdPais = 2";
            objBaseDatos.Listar(dgvGrilla, VarSQL);

        }

        private void btnJuntar_Click(object sender, EventArgs e)
        {
            //objBaseDatos = new clsBaseDatos();
            //String VarSQL = "Select TITULO, NOMBRE "
            //    + " FROM LIBRO, PAIS " +
            //    "WHERE LIBRO.IDPAIS = PAIS.IDPAIS";
            //objBaseDatos.Listar(dgvGrilla, VarSQL);

            objBaseDatos = new clsBaseDatos();
            String VarSQL = "SELECT TITULO, NOMBRE " +
                "from  LIBRO  inner join  PAIS " +
                "on LIBRO.IdPais = Pais.IdPais  ";
            objBaseDatos.Listar(dgvGrilla, VarSQL);
        }
    }
}
