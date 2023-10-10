using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PracticaDomino.ListasLigadas
{
    public class LDL
    { 
        private NodoDoble primero;
        private NodoDoble ultimo;

        public LDL()
        {
            primero = ultimo = null;
        }

        public NodoDoble getPrimero()
        {
            return primero;
        }

        public NodoDoble getUltimo()
        {
            return ultimo;
        }

        public bool finDeRecorrido(NodoDoble x)
        {
            return x == null;
        }

        public bool esVacia()
        {
            return primero == null;
        }

        public void recorrerIzq_Der()
        {
            NodoDoble p;
            p = primero;
            while (!finDeRecorrido(p))
            {
                p = p.getLigaDer();
            }
        }

        public void insertar(Object dato, Tablero tablero)
        {
            NodoDoble x;
            x = new NodoDoble(dato);
            if (esVacia())
            {
                agregarPrimero(x);
            }
            else
            {
                conectar(x, tablero);
            }
        }

        public void conectar(NodoDoble x, Tablero tablero)
        {
            Ficha doce, n;
            n = (Ficha)x.getDato();
            if (primero == ultimo)
            {
                doce = (Ficha)primero.getDato();
                if (n.compatibleDer(doce))
                {
                    tablero.crearFicha(n, true, n.getInvertida());
                    conectarDer(x);
                }
                //else if(n.compatibleIzq(doce)
                //{
                //    conectarIzq(x);
                //}
            }
            else
            {
                Ficha izq, der;
                izq = (Ficha)primero.getDato();
                der = (Ficha)ultimo.getDato();
                if (n.compatibleDer(der))
                {
                    tablero.crearFicha(n, true, n.getInvertida());
                    conectarDer(x);
                }
                else if (n.compatibleIzq(izq))
                {
                    tablero.crearFicha(n, false, n.getInvertida());                  
                    conectarIzq(x);
                }
            }
        }

        public void conectarIzq(NodoDoble x)
        {
            x.setLigaDer(primero);
            primero = x;
        }

        public void conectarDer(NodoDoble x)
        {
            if(primero == ultimo)
            {
                primero.setLigaDer(x);
            }
            ultimo.setLigaDer(x);
            ultimo = x;
        }

        public void agregarPrimero(NodoDoble x)
        {
            primero = ultimo = x;
        }

        //public NodoDoble anterior(NodoDoble x)
        //{
        //    NodoDoble p, y;
        //    p = primero;
        //    y = null;
        //    while (p != x)
        //    {
        //        y = p;
        //        p = p.getLigaDer();
        //    }
        //    return y;
        //}

        //public NodoDoble siguiente(NodoDoble x)
        //{
        //    NodoDoble p, y;
        //    p = ultimo;
        //    y = null;
        //    while (p != x)
        //    {
        //        y = p;
        //        p = p.getLigaIzq();
        //    }
        //    return y;
        //}
    }
}
