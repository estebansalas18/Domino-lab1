using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDomino.ListasLigadas
{
    public class NodoDoble
    {
        private Object dato;
        private NodoDoble ligaIzq;
        private NodoDoble ligaDer;

        public NodoDoble()
        {
            dato = null;
            ligaIzq = null;
            ligaDer = null;
        }

        public NodoDoble(Object dato)
        {
            this.dato = dato;
            ligaIzq = null;
            ligaDer = null; 
        }

        public void setLigaIzq(NodoDoble ligaIzq)
        {
            this.ligaIzq = ligaIzq;
        }

        public void setLigaDer(NodoDoble ligaDer)
        {
            this.ligaDer = ligaDer;
        }

        public void setDato(Object dato)
        {
            this.dato = dato;
        }

        public NodoDoble getLigaIzq()
        {
            return ligaIzq;
        }

        public NodoDoble getLigaDer()
        {
            return ligaDer;
        }

        public Object getDato()
        {
            return dato;
        }
    }
}
