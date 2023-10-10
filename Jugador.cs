using PracticaDomino.ListasLigadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaDomino
{
    public class Jugador
    {
        private String nombre;
        private LSL manoJugador;
        private int orden;
        private int puntaje;
        private int puntosFicha;

        public Jugador()
        {
            nombre = "";
            manoJugador = null;
            orden = 0;
            puntaje = 0;
            puntosFicha = 0;
        }

        public void sumarPuntos()
        {
            NodoSimple p;
            Ficha x;
            int suma = 0;
            p = manoJugador.getPrimero();
            while (!manoJugador.finDeRecorrido(p))
            {
                x = (Ficha)p.getDato();
                suma += (x.getN1() + x.getN2());
                p = p.getLiga();
            }
            puntosFicha = suma;
        }

        public int getPuntosFicha()
        {
            return puntosFicha;
        }

        public void reiniciarPuntos()
        {
            puntosFicha = 0;
        }

        public int getPuntaje()
        {
            return puntaje;
        }

        public void setPuntaje(int puntaje)
        {
            this.puntaje = puntaje;
        }

        public void setOrden(int orden)
        {
            this.orden = orden;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void setMano(LSL manoJugador)
        {
            this.manoJugador = manoJugador;
        }

        public void borrarMano()
        {
            manoJugador.setPrimero(null);
            manoJugador.setUltimo(null);
        }

        public LSL getMano()
        {
            return manoJugador;
        }

        public String getNombre()
        {
            return nombre;
        }

        public int getOrden()
        {
            return orden;
        }
    }
}
