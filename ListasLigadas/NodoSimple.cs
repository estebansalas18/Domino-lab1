using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDomino.ListasLigadas
{
    public class NodoSimple
    {
        private Object dato;
        private NodoSimple liga;

        public NodoSimple()
        {
            dato = null;
            liga = null;
        }

        public NodoSimple(Object dato)
        {
            this.dato = dato;
            liga = null;
        }

        public void setLiga(NodoSimple liga)
        {
            this.liga = liga;
        }

        public void setDato(Object dato)
        {
            this.dato = dato;
        }

        public NodoSimple getLiga()
        {
            return liga;
        }

        public Object getDato()
        {
            return dato;
        }
    }
}
