using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDomino
{
    public class Ficha
    {
        private int n1, n2;
        private String ubicacion;
        private bool invertida;

        public Ficha()
        {
            n1 = 0;
            n2 = 0;
            ubicacion = "";
        }

        public Ficha(int n1, int n2)
        {
            this.n1 = n1;
            this.n2 = n2;
            ubicacion = n1 + " " + n2 +".png";
        }

        public void setN2(int n2)
        {
            this.n2 = n2;
        }

        public void setN1(int n1)
        {
            this.n1 = n1;
        }

        public int getN1()
        {
            return n1;
        }

        public int getN2()
        {
            return n2;
        }

        public String getUbicacion()
        {
            return ubicacion;
        }

        public bool esIgual(Ficha n)
        {
            if(this.n1 == n.getN1() && this.n2 == n.getN2())
            {
                return true;
            }
            if(this.n2 == n.getN1() && this.n1 == n.getN2())
            {
                return true;
            }
            return false;
        }

        public bool compatibleIzq(Ficha n)
        {
            if(this.n2 == n.getN1())
            {
                return true;
            }
            if(this.n1 == n.getN1())
            {
                girarFicha(this);
                return true;
            }
            return false;
        }

        public bool compatible(Ficha izq, Ficha der)
        {
            if (this.n2 == izq.getN1())
            {
                return true;
            }
            if (this.n1 == izq.getN1())
            {
                return true;
            }
            if (this.n1 == der.getN2())
            {
                return true;
            }
            if (this.n2 == der.getN2())
            {
                return true;
            }
            return false;
        }

        public bool compatibleDer(Ficha n)
        {
            if (this.n1 == n.getN2())
            {
                return true;
            }
            if (this.n2 == n.getN2())
            {
                girarFicha(this);
                return true;
            }
            return false;
        }

        public void girarFicha(Ficha n)
        {
            int x;
            x = n.getN2();
            n.setN2(n.getN1());
            n.setN1(x);
            invertida = true;
        }

        public bool getInvertida()
        {
            return invertida;
        }

        public String toString()
        {
            return "[" + n1 + "|" + n2 + "]";
        }
    }
}
