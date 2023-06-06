using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace pry.EstructuraDatos.Clase2
{
    internal class clsBaseDatos
    {
        private OleDbConnection conexion = new OleDbConnection();// conexion con la base de datos
        private OleDbCommand comando = new OleDbCommand();//configuracion de orden de base de datos (da ordenes)
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();//adapta los datos traidos de la base de datos para que C# pueda entender

        private string cadena = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Libreria.mdb";

        public void Listar(DataGridView grilla)
        {
            try
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
                //3 instrucciones para la conexion 
                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;//que traiga una tabla
                comando.CommandText = "Libro";

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, "Libro");//llenado del DS con la tabla Libro

                grilla.DataSource = null;
                grilla.DataSource = DS.Tables["Libro"];
                conexion.Close();
            }
            catch (Exception e)
            {


            }
        }

        public void Listar(DataGridView grilla, String varInstruccionSQL)
        {
            try
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
                //3 instrucciones para la conexion 
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;//que traiga una tabla
                comando.CommandText = varInstruccionSQL;

                adaptador = new OleDbDataAdapter(comando);
                DataSet DS = new DataSet();
                adaptador.Fill(DS, "Resultado");//llenado del DS con la tabla Libro

                grilla.DataSource = null;
                grilla.DataSource = DS.Tables["Resultado"];
                conexion.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }


    }
}
