using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry.EstructuraDatos.Clase2
{
    class clsCola
    {
        public clsNodo Primero;
        public clsNodo Ultimo;


        public void Agregar (clsNodo Nuevo)// recibe un nuevo nodo 
        {
            //Si no existe ninguno en la fila
            if (Primero == null)
            {
                Primero = Nuevo;
                Ultimo = Nuevo;

            }
            else
            {
                //Si existe uno en la fila ya, el ultimo lo pasa hacia adelante 
                Ultimo.Siguiente = Nuevo;
                //Al nuevo lo pone al ultimo de la fila
                Ultimo = Nuevo;
            } 

        }
        public void Eliminar()
        {
            if (Primero == Ultimo)
	        {
                Primero = null;
                Ultimo = null;

	        }
            else
            {
                Primero = Primero.Siguiente;
            }
        }
        public void Recorrer(DataGridView Grilla)
        {
            clsNodo aux = Primero;
            Grilla.Rows.Clear();
            while (aux != null)
            {
                Grilla.Rows.Add(aux.Codigo, aux.Nombre, aux.Tramite);
                aux = aux.Siguiente;
            }
            

        }

        public void Recorrer(ListBox Lista)
        {
            clsNodo aux = Primero;
            Lista.Items.Clear();
            while (aux != null)
            {
                Lista.Items.Add(aux.Codigo + " " + aux.Nombre + " " + aux.Tramite);
                aux = aux.Siguiente;
            }
        }

        public void Recorrer(ComboBox Combo)
        {
            clsNodo aux = Primero;
            Combo.Items.Clear();
            while (aux != null)
            {
                Combo.Items.Add(aux.Nombre);
                aux = aux.Siguiente;
            }
        }

    }
}
