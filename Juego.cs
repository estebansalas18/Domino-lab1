using PracticaDomino.ListasLigadas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaDomino
{
    public class Juego
    {
        private List<Ficha> fichas;
        private Jugador[] jugadores;
        private LDL tablerito;
        private bool finDeRonda;

        public Juego()
        {
            fichas = new List<Ficha>();
            jugadores = new Jugador[4];
            tablerito = new LDL();
        }

        public LDL getTablerito()
        {
            return tablerito;
        }

        public void crearFichas()
        {
            Ficha x;
            for (int i = 0; i < 7; i++)
            {
                for (int j = i; j < 7; j++)
                {
                    x = new Ficha(i, j);
                    fichas.Add(x);
                }
            }
        }

        public void crearJugadores(String n1, String n2, String n3, String n4)
        {
            Jugador x;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        x = new Jugador();
                        x.setNombre(n1);
                        x.setOrden(1);
                        jugadores[i] = x;
                        break;
                    case 1:
                        x = new Jugador();
                        x.setNombre(n2);
                        x.setOrden(2);
                        jugadores[i] = x;
                        break;
                    case 2:
                        x = new Jugador();
                        x.setNombre(n3);
                        x.setOrden(3);
                        jugadores[i] = x;
                        break;
                    case 3:
                        x = new Jugador();
                        x.setNombre(n4);
                        x.setOrden(4);
                        jugadores[i] = x;
                        break;
                }
            }
        }

        public void repartirFichas()
        {
            Ficha[] fichitas;
            Ficha x;
            LSL mano;
            Random r;
            for (int i = 0; i < jugadores.Length; i++)
            {
                mano = new LSL();
                fichitas = new Ficha[7];
                for (int j = 0; j < fichitas.Length; j++)
                {
                    r = new Random();
                    x = fichas.ElementAt(r.Next(fichas.Count));
                    fichitas[j] = x;
                    fichas.Remove(x);
                    mano.insertar(x, null);
                }
                jugadores[i].setMano(mano);
            }
        }

        public Jugador buscarPrimero()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].getMano().buscarDobleSeis())
                {
                    return jugadores[i];
                }
            }
            return null;
        }

        public int buscarPosicion()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].getMano().buscarDobleSeis())
                {
                    return i;
                }
            }
            return 0;
        }

        public Jugador[] getJugadores()
        {
            return jugadores;
        }

        public Jugador getJugador1()
        {
            return jugadores[0];
        }

        public void iniciarRonda(Tablero tablero, List<Button> j2, List<Button> j3, List<Button> j4)
        {
            NodoSimple x;
            Ficha doble;
            doble = new Ficha(6, 6);
            x = buscarPrimero().getMano().buscarDato(doble);
            tablerito.insertar(doble, tablero);
            primerTurno(tablero, x, j2, j3, j4);
        }

        public void primerTurno(Tablero tablero, NodoSimple x, List<Button> j2, List<Button> j3, List<Button> j4)
        {
            for(int i = 0; i < jugadores.Length; i++)
            {
                if(jugadores[i] == buscarPrimero())
                {
                    switch (i)
                    {
                        case 0:
                            jugadores[i].getMano().borrar(x, buscarPrimero().getMano().anterior(x));
                            for(int j = i + 1; j < jugadores.Length; j++)
                            {
                                NodoSimple p;
                                Ficha n;
                                n = (Ficha)jugadores[j].getMano().buscarFicha(tablerito);
                                if (n != null)
                                {
                                    switch (j)
                                    {
                                        case 1:
                                            j2[j2.Count - 1].Visible = false;
                                            j2.RemoveAt(j2.Count - 1);
                                            break;
                                        case 2:
                                            j3[j3.Count - 1].Visible = false;
                                            j3.RemoveAt(j3.Count - 1);
                                            break;
                                        case 3:
                                            j4[j4.Count - 1].Visible = false;
                                            j4.RemoveAt(j4.Count - 1);
                                            break;
                                        default:
                                            MessageBox.Show("Viva la u.");
                                            break;
                                    }
                                    tablerito.insertar(n, tablero);
                                    p = jugadores[j].getMano().buscarDato(n);
                                    jugadores[j].getMano().borrar(p, jugadores[j].getMano().anterior(p));
                                }
                                else
                                {
                                    MessageBox.Show(jugadores[j].getNombre() + " no tiene ficha para poner");
                                }
                            }
                            break;
                        case 1:
                            jugadores[i].getMano().borrar(x, buscarPrimero().getMano().anterior(x));
                            for (int j = i + 1; j < jugadores.Length; j++)
                            {
                                NodoSimple p;
                                Ficha n;
                                n = (Ficha)jugadores[j].getMano().buscarFicha(tablerito);
                                if (n != null)
                                {
                                    switch (j)
                                    {
                                        case 2:
                                            j3[j3.Count - 1].Visible = false;
                                            j3.RemoveAt(j3.Count - 1);
                                            break;
                                        case 3:
                                            j4[j4.Count - 1].Visible = false;
                                            j4.RemoveAt(j4.Count - 1);
                                            break;
                                        default:
                                            MessageBox.Show("ME quiero matar uwu");
                                            break;
                                    }
                                    tablerito.insertar(n, tablero);
                                    p = jugadores[j].getMano().buscarDato(n);
                                    jugadores[j].getMano().borrar(p, jugadores[j].getMano().anterior(p));
                                }
                                else
                                {
                                    MessageBox.Show(jugadores[j].getNombre() + " no tiene ficha para poner");
                                }
                            }
                            break;
                        case 2:
                            jugadores[i].getMano().borrar(x, buscarPrimero().getMano().anterior(x));
                            for (int j = i + 1; j < jugadores.Length; j++)
                            {
                                NodoSimple p;
                                Ficha n;
                                n = (Ficha)jugadores[j].getMano().buscarFicha(tablerito);
                                if (n != null)
                                {
                                    switch (j)
                                    {
                                        case 3:
                                            j4[j4.Count - 1].Visible = false;
                                            j4.RemoveAt(j4.Count - 1);
                                            break;
                                        default:
                                            MessageBox.Show("ME quiero matar uwu");
                                            break;
                                    }
                                    tablerito.insertar(n, tablero);
                                    p = jugadores[j].getMano().buscarDato(n);
                                    jugadores[j].getMano().borrar(p, jugadores[j].getMano().anterior(p));
                                }
                                else
                                {
                                    MessageBox.Show(jugadores[j].getNombre() + " no tiene ficha para poner");
                                }
                            }
                            break;
                        default:
                            jugadores[i].getMano().borrar(x, buscarPrimero().getMano().anterior(x));
                            break;
                    }
                }
            }
        }

        public bool getFinDeRonda()
        {
            int cte;
            cte = 0;
            for(int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].getMano().esVacia())
                {
                    finDeRonda = true;
                    return finDeRonda;
                }
                else if (jugadores[i].getMano().buscarFicha(tablerito) == null)
                {
                    cte++;
                }              
            }
            if (cte == 4)
            {
                finDeRonda = true;
                return finDeRonda;
            }
            finDeRonda = false;
            return finDeRonda;
        }

        public void setFinDeRonda(bool finDeRonda)
        {
            this.finDeRonda = finDeRonda;
        }

        public void jugarTurnos(Tablero tablero, List<Button> j2, List<Button> j3, List<Button> j4)
        {
            if (!getFinDeRonda())
            {
                for (int i = 1; i < jugadores.Length; i++)
                {
                    if (!getFinDeRonda())
                    {
                        NodoSimple p;
                        Ficha n;
                        n = (Ficha)jugadores[i].getMano().buscarFicha(tablerito);
                        if (n != null)
                        {
                            switch (i)
                            {
                                case 1:
                                    j2[j2.Count - 1].Visible = false;
                                    j2.RemoveAt(j2.Count - 1);
                                    break;
                                case 2:
                                    j3[j3.Count - 1].Visible = false;
                                    j3.RemoveAt(j3.Count - 1);
                                    break;
                                case 3:
                                    j4[j4.Count - 1].Visible = false;
                                    j4.RemoveAt(j4.Count - 1);
                                    break;
                                default:
                                    MessageBox.Show("Aborten mision");
                                    break;
                            }
                            tablerito.insertar(n, tablero);
                            p = jugadores[i].getMano().buscarDato(n);
                            jugadores[i].getMano().borrar(p, jugadores[i].getMano().anterior(p));
                            if (jugadores[i].getMano().esVacia())
                            {
                                finalizarRonda(i, tablero);
                                MessageBox.Show("Dale clic a Pasar para continuar");
                                MessageBox.Show(jugadores[i].getNombre() + " dominó la ronda.");
                            }
                        }
                    }
                }
                tablero.setTurnoJ1(true);
            }
            else
            {
                int x = compararPuntos();
                tablero.Controls.Remove(tablero.getPasar());         
                if (!manosVacias())
                {
                    finalizarRonda(x, tablero);
                    MessageBox.Show("Dale clic a Pasar para continuar");
                    MessageBox.Show(jugadores[x].getNombre() + " dominó la ronda.");
                }
                else if (getJugador1().getMano().esVacia())
                {
                    finalizarRonda(x, tablero);
                    MessageBox.Show(jugadores[x].getNombre() + " dominó la ronda.");
                }
                reiniciarRonda(tablero);
            }
        }

        public void finalizarRonda(int i,Tablero tablero)
        {
            switch (i)
            {
                case 0:
                    jugadores[1].sumarPuntos();
                    jugadores[2].sumarPuntos();
                    jugadores[3].sumarPuntos();
                    jugadores[i].setPuntaje(jugadores[i].getPuntaje() + jugadores[1].getPuntosFicha() + jugadores[2].getPuntosFicha() + jugadores[3].getPuntosFicha());
                    jugadores[0].reiniciarPuntos();
                    jugadores[1].reiniciarPuntos();
                    jugadores[2].reiniciarPuntos();
                    jugadores[3].reiniciarPuntos();
                    break;
                case 1:
                    jugadores[0].sumarPuntos();
                    jugadores[2].sumarPuntos();
                    jugadores[3].sumarPuntos();
                    jugadores[i].setPuntaje(jugadores[i].getPuntaje() + jugadores[0].getPuntosFicha() + jugadores[2].getPuntosFicha() + jugadores[3].getPuntosFicha());
                    jugadores[0].reiniciarPuntos();
                    jugadores[1].reiniciarPuntos();
                    jugadores[2].reiniciarPuntos();
                    jugadores[3].reiniciarPuntos();
                    break;
                case 2:
                    jugadores[0].sumarPuntos();
                    jugadores[1].sumarPuntos();
                    jugadores[3].sumarPuntos();
                    jugadores[i].setPuntaje(jugadores[i].getPuntaje() + jugadores[0].getPuntosFicha() + jugadores[1].getPuntosFicha() + jugadores[3].getPuntosFicha());
                    jugadores[0].reiniciarPuntos();
                    jugadores[1].reiniciarPuntos();
                    jugadores[2].reiniciarPuntos();
                    jugadores[3].reiniciarPuntos();
                    break;
                case 3:
                    jugadores[0].sumarPuntos();
                    jugadores[1].sumarPuntos();
                    jugadores[2].sumarPuntos();
                    jugadores[i].setPuntaje(jugadores[i].getPuntaje() + jugadores[0].getPuntosFicha() + jugadores[1].getPuntosFicha() + jugadores[2].getPuntosFicha());
                    jugadores[0].reiniciarPuntos();
                    jugadores[1].reiniciarPuntos();
                    jugadores[2].reiniciarPuntos();
                    jugadores[3].reiniciarPuntos();
                    break;
                default:
                    MessageBox.Show("Profe ayuda me secuestraron");
                    break;
            }
        }

        public int compararPuntos()
        {
            int[] p = new int[4];
            for(int i = 0; i < jugadores.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        jugadores[i].sumarPuntos();
                        p[i] = jugadores[i].getPuntosFicha();
                        break;
                    case 1:
                        jugadores[i].sumarPuntos();
                        p[i] = jugadores[i].getPuntosFicha();
                        break;
                    case 2:
                        jugadores[i].sumarPuntos();
                        p[i] = jugadores[i].getPuntosFicha();
                        break;
                    case 3:
                        jugadores[i].sumarPuntos();
                        p[i] = jugadores[i].getPuntosFicha();
                        break;
                }
            }
            for(int i = 0; i < p.Length; i++)
            {
                if(p[i] == p.Min())
                {
                    return i;
                }
            }
            return 0;
        }

        public bool manosVacias()
        {
            for(int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].getMano().esVacia())
                {
                    return true;
                }
            }
            return false;
        }

        public void reiniciarRonda(Tablero tablero)
        {
            tablerito = new LDL();
            for (int i = 0; i < jugadores.Length; i++)
            {
                jugadores[i].borrarMano();
            }
            crearFichas();
            repartirFichas();
            tablero.borrarTodo();
            tablero.ordenarTablero();
            tablero.addPatos();
            tablero.setTurnoJ1(true);
            if (checarFinal())
            {
                tablero.presentarGanador(checarGanador());
            }
        }

        public bool checarFinal()
        {
            for(int i = 0; i < jugadores.Length; i++)
            {
                if(jugadores[i].getPuntaje() >= 101)
                {
                    return true;
                }
            }
            return false;
        }

        public int checarGanador()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].getPuntaje() >= 101)
                {
                    return i;
                }
            }
            return 5;
        }
    }
}
           
