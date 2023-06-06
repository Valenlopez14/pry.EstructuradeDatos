using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pry.EstructuraDatos.Clase2
{
    
    class ArbolBinario
    {
        private clsNodo Inicio;
        private clsNodo pri;
        private clsNodo ult;
        public clsNodo Raiz

        {
            get { return Inicio; }
            set { Inicio = value;  }
        }

        //Declaro los campos

        //Declaro las propiedades
        public clsNodo Primero
        {
            get { return pri; }
            set { pri = value; }
        }

        public clsNodo Ultimo
        {
            get { return ult; }
            set { ult = value; }

        }

        //========================================================================

        public void Agregar (clsNodo Nvo)
        {
            Nvo.Izquierdo = null;
            Nvo.Derecho = null;
            if (Raiz  == null)
            {
                Raiz = Nvo;
            }
            else
            {
                clsNodo NodoPadre = Raiz; //ant
                clsNodo Aux = Raiz;
                while (Aux != null)
                {
                    NodoPadre = Aux;
                    if (Nvo.Codigo < Aux.Codigo)
                    {
                        Aux = Aux.Izquierdo;

                    }
                    else
                    {
                        Aux = Aux.Derecho;
                    }
                }

                //Afuera del while
                if (Nvo.Codigo < NodoPadre.Codigo)
                {
                    NodoPadre.Izquierdo = Nvo;
                }
                else
                {
                    NodoPadre.Derecho = Nvo;
                }
            }
        }
        //=============================================================================
       


        //=============================================================================
        private clsNodo[] Vector = new clsNodo[100];
        private Int32 i = 0;

        public void Equilibrar()
        {
            i = 0;
            CargarVectorInOrden(Raiz);
            Raiz = null;
            EquilibrarArbol(0, i - 1);

        }

        private void CargarVectorInOrden(clsNodo NodoPadre)
        {
            if(NodoPadre.Izquierdo != null)
            {
                CargarVectorInOrden(NodoPadre.Izquierdo);
            }
            Vector[i] = NodoPadre;
            i = i + 1;
            if (NodoPadre.Derecho != null)
            {
                CargarVectorInOrden(NodoPadre.Derecho);
            }
        }

        private void EquilibrarArbol(Int32 ini, Int32 fin)
        {
            Int32 m = (ini + fin) / 2;
            if (ini <= fin)
            {
                Agregar(Vector[m]);
                EquilibrarArbol(ini, m - 1);
                EquilibrarArbol(m + 1, fin);
            }
        }
        //=========================================================================
        public void RecorrerSW(StreamWriter sw)
        {
            InOrdenAsc(sw, Raiz);
        }

        public void InOrdenAsc(StreamWriter sw, clsNodo R)
        {
            if (R.Izquierdo != null) InOrdenAsc(sw, R.Izquierdo);
            sw.Write(R.Codigo);
            sw.Write(";");
            sw.Write(R.Nombre);
            sw.Write(";");
            sw.WriteLine(R.Tramite);
            if (R.Derecho != null) InOrdenAsc(sw, R.Derecho);
        }

        public void RecorrerDesSW(StreamWriter sw)
        {
            InOrdenDesc(sw, Raiz);
        }

        public void InOrdenDesc(StreamWriter Sw, clsNodo R)
        {
            if (R.Derecho != null) InOrdenDesc(Sw, R.Derecho);
            Sw.Write(R.Codigo);
            Sw.Write(";");
            Sw.Write(R.Nombre);
            Sw.Write(";");
            Sw.WriteLine(R.Tramite);
            if (R.Izquierdo != null) InOrdenDesc(Sw, R.Izquierdo);
        }


        public void Recorrer(StreamWriter Sw, bool Ascedente, string Recorrer)
        {
            if (Recorrer == "InOrden")
            {
                if (Ascedente == true)
                {
                    InOrdenAsc(Sw, Raiz);
                }
                else if (Ascedente == false)
                {
                    InOrdenDesc(Sw, Raiz);
                }
            }
            else if (Recorrer == "PostOrden")
            {
                PostOrden(Sw, Raiz);
            }
            else if (Recorrer == "PreOrden")
            {
                PreOrden(Sw, Raiz);
            }
        }
        public void RecorrerPostOrden(StreamWriter Sw)
        {
            PostOrden(Sw, Raiz);
        }
        public void PostOrden(StreamWriter Sw, clsNodo R)
        {
            if (R.Izquierdo != null) InOrdenDesc(Sw, R.Izquierdo);
            if (R.Derecho != null) InOrdenDesc(Sw, R.Derecho);
            Sw.Write(R.Codigo);
            Sw.Write(";");
            Sw.Write(R.Nombre);
            Sw.Write(";");
            Sw.WriteLine(R.Tramite);
        }
        public void RecorrerPreOrden(StreamWriter sw)
        {
            PreOrden(sw, Raiz);
        }
        public void PreOrden(StreamWriter Sw, clsNodo R)
        {
            Sw.Write(R.Codigo);
            Sw.Write(";");
            Sw.Write(R.Nombre);
            Sw.Write(";");
            Sw.WriteLine(R.Tramite);
            if (R.Izquierdo != null) InOrdenDesc(Sw, R.Izquierdo);
            if (R.Derecho != null) InOrdenDesc(Sw, R.Derecho);
        }


        //==========================================================================
        public void Recorrer(ListBox Lista)
        {
            Lista.Items.Clear();
            InOrdenAsc(Lista, Raiz);

        }
        public void InOrdenAsc(ListBox Lst, clsNodo R)//ListBox Ascendente
        {
            if (R.Izquierdo != null)
            {
                InOrdenAsc(Lst, R.Izquierdo);
            }
            Lst.Items.Add(R.Codigo);
            if (R.Derecho != null)
            {
                InOrdenAsc(Lst, R.Derecho);
            }
        }
        //===========================================================================
        public void RecorrerDesc(ListBox Lista)
        {
            Lista.Items.Clear();
            InOrdenDesc(Lista, Raiz);

        }
        public void InOrdenDesc(ListBox Lst, clsNodo R) //ListBox Descendente
        {
            if (R.Derecho != null) InOrdenDesc(Lst, R.Derecho); //D
            Lst.Items.Add(R.Codigo);//R
            if (R.Izquierdo != null) InOrdenDesc(Lst, R.Izquierdo);//I
        }

        //==========================================================================
        public void Recorrer(ComboBox Combo)
        {
            Combo.Items.Clear();
            InOrdenAsc(Combo, Raiz);

        }
        public void InOrdenAsc(ComboBox combo, clsNodo R)//ComboBox Ascendente
        {
            if(R.Izquierdo != null) InOrdenAsc(combo, R.Izquierdo); //I
            combo.Items.Add(R.Codigo);//R
            if(R.Derecho != null) InOrdenAsc(combo,R.Derecho);//D
        }
        public void RecorrerDesc(ComboBox Combo)
        {
            Combo.Items.Clear();
            InOrdenDesc(Combo, Raiz);

        }
        public void InOrdenDesc(ComboBox combo, clsNodo R)//ComboBox Descendente
        {
            if(R.Derecho != null) InOrdenDesc(combo, R.Derecho);//D
            combo.Items.Add(R.Codigo);//R
            if(R.Izquierdo != null) InOrdenDesc(combo, R.Izquierdo);//I
        }

        //===========================================================================
        public void Recorrer(DataGridView grilla)
        {
            grilla.Rows.Clear();
            InOrdenAsc(grilla, Raiz);
        }

        public void InOrdenAsc(DataGridView grilla, clsNodo R) //ListBoxAscendente
        {
            if (R.Izquierdo != null) InOrdenAsc(grilla, R.Izquierdo);//I
            grilla.Rows.Add(R.Codigo,R.Nombre,R.Tramite);//R
            if(R.Derecho!= null) InOrdenAsc(grilla, R.Derecho);//D
        }
        public void Recorrerdesc(DataGridView grilla)
        {
            grilla.Rows.Clear();
            InOrdenDesc(grilla, Raiz);
        }

        public void InOrdenDesc(DataGridView grilla, clsNodo R)
        {
            if(R.Derecho != null) InOrdenAsc(grilla,R.Derecho); //D
            grilla.Rows.Add(R.Codigo, R.Nombre, R.Tramite);//R
            if (R.Izquierdo != null) InOrdenAsc(grilla, R.Izquierdo);//I
        }
        //=============================================================================
        public void Recorrer(TreeView treeView)
        {
            treeView.Nodes.Clear();
            InOrdenAsc(treeView.Nodes, Raiz);
        }
        public void InOrdenAsc(TreeNodeCollection NodoPadre, clsNodo Raiz)
        {
            if (Raiz != null)
            {
                TreeNode NodoNuevo = NodoPadre.Add(Raiz.Codigo.ToString());
                if (Raiz.Izquierdo != null) InOrdenAsc(NodoNuevo.Nodes, Raiz.Izquierdo);
                if (Raiz.Derecho != null) InOrdenAsc(NodoNuevo.Nodes, Raiz.Derecho);

            }
            

        }
        //==============================================================================
        public void RecorrerPreOrden(ListBox lst)
        {
            lst.Items.Clear();
            PreOrden(lst, Raiz);
        }
        public void PreOrden(ListBox lst, clsNodo R)//Orden ListBox
        {
            lst.Items.Add(R.Codigo);//R
            if(R.Izquierdo!= null) PreOrden(lst, R.Izquierdo); //I
            if(R.Derecho != null ) PreOrden(lst, R.Derecho);//D
        }

        public void RecorrerPostOrden(ListBox lst)
        {
            lst.Items.Clear();
            PostOrden(lst, Raiz);
        }

        public void PostOrden(ListBox lst, clsNodo R)
        {
            if(R.Izquierdo!= null) PostOrden(lst, R.Izquierdo);//I
            if(R.Derecho != null ) PostOrden(lst, R.Derecho);//D
            lst.Items.Add(R.Codigo); //R
        }

        //=============================================================================
        public void RecorrerPreOrden(ComboBox combo)
        {
            combo.Items.Clear();
            PreOrden(combo, Raiz);
        }
        public void PreOrden(ComboBox combo, clsNodo R) //Orden ComboBox
        {
            combo.Items.Add(R.Codigo);
            if(R.Izquierdo != null) PreOrden(combo, R.Izquierdo);
            if( R.Derecho != null ) PreOrden(combo, R.Derecho);

        }

        public void PostOrden(ComboBox combo,clsNodo R)
        {
            if(R.Izquierdo != null) PostOrden(combo, R.Izquierdo);//I
            if(R.Derecho != null ) PostOrden(combo, R.Derecho); //D
            combo.Items.Add(R.Codigo);//R
        }
        public void RecorrerPostOrden(ComboBox combo)
        {
            combo.Items.Clear();
            PostOrden(combo, Raiz);
        }

        //============================================================================
        public void RecorrerPreOrden(DataGridView grilla)
        {
            grilla.Rows.Clear();
            PreOrden(grilla, Raiz);
        }
        public void PreOrden(DataGridView grilla, clsNodo R)
        {
            grilla.Rows.Add(R.Codigo, R.Nombre, R.Tramite);
            if(R.Izquierdo!= null) PreOrden(grilla, R.Izquierdo);
            if(R.Derecho!= null ) PreOrden(grilla, R.Derecho);
        }

        public void PostOrden(DataGridView grilla, clsNodo R)
        {
            if(R.Izquierdo!= null )PostOrden(grilla, R.Izquierdo);
            if(R.Derecho != null ) PostOrden(grilla, R.Derecho);
            grilla.Rows.Add(R.Codigo, R.Nombre, R.Tramite);
        }
        public void RecorrerPostOrden(DataGridView grilla)
        {
            grilla.Rows.Clear();
            PostOrden(grilla, Raiz);
        }

        //==============================================================================
        public void RecorrerPreOrden(TreeView treeView)
        {
            treeView.Nodes.Clear();
            PreOrden(treeView.Nodes, Raiz);
        }

        public void PreOrden(TreeNodeCollection NodoPadre, clsNodo R)
        {
            TreeNode NodoNuevo = NodoPadre.Add(R.Codigo.ToString());
            if (R.Izquierdo != null) PreOrden(NodoNuevo.Nodes, R.Izquierdo);
            if (R.Derecho != null) PreOrden(NodoNuevo.Nodes, R.Derecho);

        }
        public void PostOrden(TreeView treeView, clsNodo R)
        {
            if (R.Izquierdo != null) InOrdenAsc(treeView.Nodes, R.Izquierdo);
            if (R.Derecho != null) InOrdenAsc(treeView.Nodes, R.Derecho);
            treeView.Nodes.Add(R.Codigo.ToString());
        }

        public void RecorrerPostOrden(TreeView treeView)
        {
            treeView.Nodes.Clear();
            PostOrden(treeView, Raiz);
        }

        public void RecorrerDesc(TreeView treeView)
        {
            treeView.Nodes.Clear();
            InOrdenDesc(treeView, Raiz);

        }

        public void InOrdenDesc(TreeView treeView, clsNodo R)
        {
            if (R.Derecho != null) InOrdenAsc(treeView.Nodes, R.Derecho);
            treeView.Nodes.Add(R.Codigo.ToString());
            if (R.Izquierdo != null) InOrdenAsc(treeView.Nodes, R.Izquierdo);
        }
        //===========================================================================
        public void Eliminar(Int32 Codigo)
        {
            Raiz = EliminarNodos(Raiz, Codigo);
        }
        private clsNodo EliminarNodos(clsNodo NodoActual, Int32 Codigo)
        {
            if (NodoActual == null)
            {
                return null;
            }
            if (Codigo < NodoActual.Codigo)
            {
                NodoActual.Izquierdo = EliminarNodos(NodoActual.Izquierdo, Codigo);
            }
            else if (Codigo > NodoActual.Codigo)
            {
                NodoActual.Derecho = EliminarNodos(NodoActual.Derecho, Codigo);
            }
            else
            {
                if (NodoActual.Izquierdo == null)
                {
                    return NodoActual.Derecho;
                }
                else if (NodoActual.Derecho == null)
                {
                    return NodoActual.Izquierdo;
                }

                clsNodo sucesor = NodoActual.Derecho;
                while (sucesor.Izquierdo != null)
                {
                    sucesor = sucesor.Izquierdo;
                }
                NodoActual.Codigo = sucesor.Codigo;
                NodoActual.Derecho = EliminarNodos(NodoActual.Derecho, sucesor.Codigo);
            }
            return NodoActual;
        }

        //busqueda
     
        public bool Buscar(Int32 Codigo)
        {
            clsNodo auxiliar = Raiz;
            while (auxiliar != null && auxiliar.Codigo != Codigo)
            {
                if (Codigo < auxiliar.Codigo)
                {
                    auxiliar = auxiliar.Izquierdo;
                }
                else
                {
                    auxiliar = auxiliar.Derecho;
                }
            }
            if (auxiliar != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Recorridos Eliminar

        public void Recorrer(ComboBox combo, bool ascedente, string recorrer)
        {
            combo.Items.Clear();
            if (recorrer == "InOrden")
            {
                if (ascedente == true)
                {
                    InOrdenAsc(combo, Raiz);
                }
                else if (ascedente == false)
                {
                    InOrdenDesc(combo, Raiz);
                }
            }
            else if (recorrer == "PostOrden")
            {
                PostOrden(combo, Raiz);
            }
            else if (recorrer == "PreOrden")
            {
                PreOrden(combo, Raiz);
            }
        }
        public void Recorrer(ListBox lst, bool ascedente, string recorrer)
        {
            lst.Items.Clear();
            if (recorrer == "InOrden")
            {
                if (ascedente == true)
                {
                    InOrdenAsc(lst, Raiz);
                }
                else if (ascedente == false)
                {
                    InOrdenDesc(lst, Raiz);
                }
            }
            else if (recorrer == "PostOrden")
            {
                PostOrden(lst, Raiz);
            }
            else if (recorrer == "PreOrden")
            {
                PreOrden(lst, Raiz);
            }
        }

        public void Recorrer(DataGridView Grilla, string recorrer, bool ascedente)
        {
            Grilla.Rows.Clear();
            if (recorrer == "InOrden")
            {
                if (ascedente == true)
                {
                    InOrdenAsc(Grilla, Raiz);
                }
                else if (ascedente == false)
                {
                    InOrdenDesc(Grilla, Raiz);
                }
            }
            else if (recorrer == "PostOrden")
            {
                PostOrden(Grilla, Raiz);
            }
            else if (recorrer == "PreOrden")
            {
                PreOrden(Grilla, Raiz);
            }
        }




    }

}
