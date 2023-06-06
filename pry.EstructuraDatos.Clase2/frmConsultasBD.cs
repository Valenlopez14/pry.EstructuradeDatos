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
    public partial class frmConsultasBD : Form
    {
        public frmConsultasBD()
        {
            InitializeComponent();
        }

        private void cmdListar_Click(object sender, EventArgs e)
        {
            clsBaseDatos objBase = new clsBaseDatos();
            String VarSQL = txtVarSQL.Text;


            objBase.Listar(dgvGrilla, VarSQL);
            
        }
    }
}
