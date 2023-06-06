using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry.EstructuraDatos.Clase2
{
    class clsNodo
    {
        //Declarar los campos a utilizar

        private String nom;
        private String tra;
        private Int32 cod;
        private clsNodo sig;
        private clsNodo ant;
        private clsNodo izq;
        private clsNodo der;

       
 

        //Crear y declarar propiedades para poder utilizar los datos en otro lado(Interfaz)

        public Int32 Codigo
        {
            //Si alguien quiere usar la propiedad le muestra lo que tiene la variable codigo
            get { return cod; }
            //si alguien quiere modificar la propiedad le modifica el valor y lo guarda
            set { cod = value; }

        }


        public String Nombre
        {
            //Si alguien quiere usar la propiedad le muestra lo que tiene la variable codigo
            get { return nom; }
            //si alguien quiere modificar la propiedad le modifica el valor y lo guarda
            set { nom = value; }
        }

        public String Tramite
        {
            //Si alguien quiere usar la propiedad le muestra lo que tiene la variable codigo
            get { return tra; }
            set { tra = value; }
        }

        public clsNodo Siguiente
        {
            //Si alguien quiere usar la propiedad le muestra lo que tiene la variable codigo
            get { return sig; }
            //si alguien quiere modificar la propiedad le modifica el valor y lo guarda
            set { sig = value; }
        }

        public clsNodo Anterior
        {   //Si alguien quiere usar la propiedad le muestra lo que tiene la variable codigo
            get { return ant; }
            //si alguien quiere modificar la propiedad le modifica el valor y lo guarda
            set { ant = value; }
        }

        public clsNodo Izquierdo
        {
            get { return izq; }
            set { izq = value; }
        }

        public clsNodo Derecho
        {
            get { return der; }
            set { der = value; }
        }


    }
}
