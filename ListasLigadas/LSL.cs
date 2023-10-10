using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaDomino.ListasLigadas
{
    public class LSL
    {
        private NodoSimple primero;
        private NodoSimple ultimo;

        public LSL()
        {
            primero = ultimo = null;
        }

        public bool finDeRecorrido(NodoSimple x)
        {
            return x == null;
        }

        public bool esVacia()
        {
            return primero == null;
        }

        public void recorrer()
        {
            NodoSimple p;
            p = primero;
            while (!finDeRecorrido(p))
            {
                p = p.getLiga();
            }
        }

        public bool buscarDobleSeis()
        {
            NodoSimple p;
            Ficha doble;
            Ficha n;
            p = primero;
            doble = new Ficha(6, 6);
            while (!finDeRecorrido(p))
            {
                n = (Ficha)p.getDato();
                if (n.esIgual(doble))
                {
                    return true;
                }      
                p = p.getLiga();
            }
            return false;
        }

        public NodoSimple buscarDato(Ficha dato)
        {
            NodoSimple p;
            Ficha n;
            p = primero;
            while (!finDeRecorrido(p))
            {
                n = (Ficha)p.getDato();
                if (n.esIgual(dato))
                {
                    return p;
                }
                p = p.getLiga();
            }
            return null;
        }

        public Object buscarFicha(LDL juego) // Busca una ficha que se pueda poner
        {
            NodoSimple p;
            Ficha n;
            p = primero;
            while (!finDeRecorrido(p))
            {
                n = (Ficha)p.getDato();
                if (n.compatible((Ficha)juego.getPrimero().getDato(), (Ficha)juego.getUltimo().getDato()))
                {
                    return n;
                }
                p = p.getLiga();
            }
            return null;
        }

        public bool comprobarFicha(LDL juego, Ficha x) // Busca si una ficha que se pueda poner
        {
            NodoSimple p;
            Ficha n;
            p = primero;
            do
            {
                n = (Ficha)p.getDato();
                p = p.getLiga();
            }
            while (n != x);
            if (n.compatibleIzq((Ficha)juego.getPrimero().getDato()))
            {
                return true;
            }
            if (n.compatibleDer((Ficha)juego.getUltimo().getDato()))
            {
                return true;
            }
            return false;
        }

        public void insertar(Object d, NodoSimple y)
        {
            NodoSimple x;
            x = new NodoSimple(d);
            conectar(x, y);
        }

        public void conectar(NodoSimple x, NodoSimple y)
        {
            if(y != null)
            {
                x.setLiga(y.getLiga());
                y.setLiga(x);
                if (y == ultimo)
                {
                    ultimo = x;
                }
            }
            else
            {
                x.setLiga(this.getPrimero());
                if (this.getPrimero() == null)
                {
                    ultimo = x;
                }
                primero = x;
            }
        }

        public NodoSimple anterior(NodoSimple x)
        {
            NodoSimple p, y;
            p = primero;
            y = null;
            while(p != x)
            {
                y = p;
                p = p.getLiga();
            }
            return y;
        }

        public void borrar(NodoSimple x, NodoSimple y)
        {
            if (x == null)
            {
                MessageBox.Show("Algo salio mal xd");
                return;
            }
            desconectar(x, y);
        }

        public void desconectar(NodoSimple x, NodoSimple y)
        {
            if (x != primero)
            {
                y.setLiga(x.getLiga());
                if (x == ultimo)
                {
                    ultimo = y;
                }
            }
            else
            {
                primero = primero.getLiga();
                if (primero == null)
                {
                    ultimo = null;
                }
            }
        }

        public void setPrimero(NodoSimple primero)
        {
            this.primero = primero;
        }

        public void setUltimo(NodoSimple ultimo)
        {
            this.ultimo = ultimo;
        }

        public NodoSimple getPrimero()
        {
            return primero;
        }

        public NodoSimple getUltimo()
        {
            return ultimo;
        }
    }
}
