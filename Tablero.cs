using Logica;
using PracticaDomino.ListasLigadas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading;

namespace PracticaDomino
{
    public partial class Tablero : Form
    {
        private List<Button> fichasJ1, fichasJ2, fichasJ3, fichasJ4;
        private readonly List<PictureBox> fichasTablero;
        private SoundPlayer bandaSonora;
        private readonly List<Label> puntajes;
        private Ficha[] manoJ1;
        private Button iniciar;
        private Button pasar;
        private Panel mesa;
        private readonly Juego juego;
        private bool turnoJ1;

        public Tablero(Juego juego)
        {
            WindowState = FormWindowState.Maximized;
            this.juego = juego;
            turnoJ1 = true;
            fichasTablero = new List<PictureBox>();
            puntajes = new List<Label>();
            abrirSonido();
            InitializeComponent();
            ordenarTablero();
        }

        public SoundPlayer getBanda()
        {
            return bandaSonora;
        }

        public void borrarTodo()
        {
            for (int i = 0; i < fichasTablero.Count; i++)
            {
                mesa.Controls.Remove(fichasTablero[i]);
            }
            fichasTablero.Clear();
            for (int i = 0; i < fichasJ1.Count; i++)
            {
                this.Controls.Remove(fichasJ1[i]);
            }
            fichasJ1.Clear();
            for (int i = 0; i < fichasJ2.Count; i++)
            {
                this.Controls.Remove(fichasJ2[i]);
            }
            fichasJ2.Clear();
            for (int i = 0; i < fichasJ3.Count; i++)
            {
                this.Controls.Remove(fichasJ3[i]);
            }
            fichasJ3.Clear();
            for (int i = 0; i < fichasJ4.Count; i++)
            {
                this.Controls.Remove(fichasJ4[i]);
            }
            fichasJ4.Clear();
            for (int i = 0; i < puntajes.Count; i++)
            {
                this.Controls.Remove(puntajes[i]);
            }
            puntajes.Clear();
            this.Controls.Remove(iniciar);
            this.Controls.Remove(mesa);
        }

        public void ordenarTablero()
        {
            this.CenterToScreen();
            MaximizeBox = false;
            Icon = new Icon("..\\..\\Recursos\\icono.ico");
            BackgroundImage = new Bitmap("..\\..\\Recursos\\tablero.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
            Text = "Domino";
            addIniciar();
            ponerFichas(juego);
            asignarManoJ1(juego);
            addClicks();
            addPatos();
        }

        public void addMesa()
        {
            mesa = new Panel
            {
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = System.Drawing.Color.SeaGreen,
                AutoScroll = true,
                Size = new Size(900, 400),
                Location = new Point(this.Width / 2 - 450, 200),
                Visible = true
            };
            this.Controls.Add(mesa);
            PictureBox ficha;
            ficha = new PictureBox
            {
                Size = new Size(55, 100),
                BackColor = Color.Transparent
            };
            ficha.Top = (mesa.Height - ficha.Height) / 2;
            ficha.Left = (mesa.Width * 4);
            mesa.Controls.Add(ficha);
        }

        public void addPasar()
        {
            pasar = new Button
            {
                Size = new Size(108, 46),
                Font = new Font("Tahoma", 20, FontStyle.Regular),
                Text = "Pasar",
                Location = new Point(fichasJ1[fichasJ1.Count - 1].Location.X + 85, fichasJ1[fichasJ1.Count - 1].Location.Y + 37)
            };
            pasar.Click += new EventHandler(pasar_Click);
            this.Controls.Add(pasar);
        }

        public void addPatos()
        {
            for (int i = 0; i < juego.getJugadores().Length; i++)
            {
                PictureBox pato;
                Label nombrecito;
                Jugador[] referencia;
                referencia = juego.getJugadores();
                pato = new PictureBox
                {
                    Visible = true,
                    Size = new Size(120, 120),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.Fixed3D
                };
                nombrecito = new Label
                {
                    Visible = true,
                    Size = new Size(120, 40),
                    Font = new Font("Tahoma", 12, FontStyle.Bold),
                    TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    BackColor = System.Drawing.Color.Transparent
                };
                switch (i)
                {
                    case 0:
                        pato.BackgroundImage = new Bitmap("..\\..\\Recursos\\Paca.png");
                        pato.Location = new Point(fichasJ1[0].Location.X - 130, fichasJ1[0].Location.Y);
                        nombrecito.Text = referencia[i].getNombre() + ": " + referencia[i].getPuntaje();
                        nombrecito.Location = new Point(pato.Location.X, pato.Location.Y - 40);
                        nombrecito.ForeColor = System.Drawing.Color.Gold;
                        break;
                    case 1:
                        pato.BackgroundImage = new Bitmap("..\\..\\Recursos\\Paco.png");
                        pato.Location = new Point(fichasJ2[0].Location.X, fichasJ2[0].Location.Y + 70);
                        nombrecito.Text = referencia[i].getNombre() + ": " + referencia[i].getPuntaje();
                        nombrecito.Location = new Point(pato.Location.X, pato.Location.Y + 120);
                        nombrecito.ForeColor = System.Drawing.Color.MediumSpringGreen;
                        break;
                    case 2:
                        pato.BackgroundImage = new Bitmap("..\\..\\Recursos\\Luisa.png");
                        pato.Location = new Point(fichasJ3[fichasJ3.Count - 1].Location.X + 70, fichasJ3[0].Location.Y);
                        nombrecito.Text = referencia[i].getNombre() + ": " + referencia[i].getPuntaje();
                        nombrecito.Location = new Point(pato.Location.X, pato.Location.Y + 120);
                        nombrecito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                        break;
                    case 3:
                        pato.BackgroundImage = new Bitmap("..\\..\\Recursos\\Hugo.png");
                        pato.Location = new Point(fichasJ4[0].Location.X, fichasJ4[fichasJ4.Count - 1].Location.Y - 130);
                        nombrecito.Text = referencia[i].getNombre() + ": " + referencia[i].getPuntaje();
                        nombrecito.Location = new Point(pato.Location.X, pato.Location.Y - 40);
                        nombrecito.ForeColor = System.Drawing.Color.CornflowerBlue;
                        break;
                    default:
                        MessageBox.Show("Lo logramos!");
                        break;
                }
                puntajes.Add(nombrecito);
                this.Controls.Add(nombrecito);
                this.Controls.Add(pato);
            }
        }

        private void pasar_Click(object sender, EventArgs e)
        {
            turnoJ1 = false;
            juego.jugarTurnos(this, fichasJ2, fichasJ3, fichasJ4);
        }

        public void addIniciar()
        {
            iniciar = new Button
            {
                Size = new Size(108, 46),
                Font = new Font("Tahoma", 20, FontStyle.Regular),
                Text = "Iniciar"
            };
            iniciar.Top = (this.ClientSize.Height - iniciar.Height) / 2;
            iniciar.Left = (this.ClientSize.Width - iniciar.Width) / 2;
            this.iniciar.Click += new EventHandler(iniciar_Click);
            this.Controls.Add(iniciar);
        }

        public void addClicks()
        {
            for (int i = 0; i < fichasJ1.Count; i++)
            {
                this.fichasJ1[i].Click += new EventHandler(fichasJ1_Click);
            }
        }

        private void fichasJ1_Click(object sender, EventArgs e)
        {
            if (turnoJ1)
            {
                if (!juego.getFinDeRonda())
                {
                    for (int i = 0; i < fichasJ1.Count; i++)
                    {
                        NodoSimple nodoBasura;
                        Ficha f;
                        Button x;
                        x = sender as Button;
                        if (fichasJ1[i] == x)
                        {
                            f = manoJ1[i];
                            if (juego.getJugador1().getMano().comprobarFicha(juego.getTablerito(), f))
                            {
                                x.Visible = false;
                                juego.getTablerito().insertar(f, this);
                                nodoBasura = juego.getJugador1().getMano().buscarDato(f);
                                juego.getJugador1().getMano().borrar(nodoBasura, juego.getJugador1().getMano().anterior(nodoBasura));
                                turnoJ1 = false;
                                juego.jugarTurnos(this, fichasJ2, fichasJ3, fichasJ4);
                            }
                        }
                    }
                }
            }
        }

        public void ponerFichas(Juego juego)
        {
            Button[] botones;
            fichasJ1 = new List<Button>();
            fichasJ2 = new List<Button>();
            fichasJ3 = new List<Button>();
            fichasJ4 = new List<Button>();
            for (int i = 0; i < juego.getJugadores().Length; i++)
            {
                botones = new Button[7];
                for (int j = 0; j < botones.Length; j++)
                {
                    botones[j] = new Button
                    {
                        BackgroundImage = new Bitmap("..\\..\\Recursos\\vacio.png"),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        BackColor = Color.Transparent,
                        FlatStyle = FlatStyle.Flat,
                    };
                    botones[j].FlatAppearance.BorderSize = 0;
                    botones[j].FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                    switch (i)
                    {
                        case 0:
                            botones[j].Size = new Size(65, 120);
                            switch (j)
                            {
                                case 0:
                                    botones[j].Location = new Point((2 * (this.Width / 5)), 675);
                                    this.Controls.Add(botones[j]);
                                    break;
                                default:
                                    botones[j].Location = new Point((botones[j - 1].Location.X + 70), botones[j - 1].Location.Y);
                                    this.Controls.Add(botones[j]);
                                    break;
                            }
                            botones[j].FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
                            botones[j].FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
                            fichasJ1.Add(botones[j]);
                            break;
                        case 1:
                            botones[j].Size = new Size(120, 65);
                            botones[j].BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                            switch (j)
                            {
                                case 0:
                                    botones[j].Location = new Point((this.Width - (this.Width / 10)), 500);
                                    this.Controls.Add(botones[j]);
                                    break;
                                default:
                                    botones[j].Location = new Point(botones[j - 1].Location.X, (botones[j - 1].Location.Y - 70));
                                    this.Controls.Add(botones[j]);
                                    break;
                            }
                            fichasJ2.Add(botones[j]);
                            break;
                        case 2:
                            botones[j].Size = new Size(65, 120);
                            switch (j)
                            {
                                case 0:
                                    botones[j].Location = new Point((2 * (this.Width / 7)), (this.Height / 60));
                                    this.Controls.Add(botones[j]);
                                    break;
                                default:
                                    botones[j].Location = new Point((botones[j - 1].Location.X + 70), botones[j - 1].Location.Y);
                                    this.Controls.Add(botones[j]);
                                    break;
                            }
                            fichasJ3.Add(botones[j]);
                            break;
                        case 3:
                            botones[j].Size = new Size(120, 65);
                            botones[j].BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                            switch (j)
                            {
                                case 0:
                                    botones[j].Location = new Point(this.Width / 70, 650);
                                    this.Controls.Add(botones[j]);
                                    break;
                                default:
                                    botones[j].Location = new Point(botones[j - 1].Location.X, (botones[j - 1].Location.Y - 70));
                                    this.Controls.Add(botones[j]);
                                    break;
                            }
                            fichasJ4.Add(botones[j]);
                            break;
                        default:
                            MessageBox.Show("Algo salio mal alv");
                            break;
                    }
                }
            }
        }

        public void voltearFichasJ1(Juego juego)
        {
            Ficha n;
            n = (Ficha)juego.getJugador1().getMano().getPrimero().getDato();
            for (int i = 0; i < fichasJ1.Count; i++)
            {
                fichasJ1[i].BackgroundImage = new Bitmap("..\\..\\Recursos\\" + n.getUbicacion());
                if (i < (fichasJ1.Count - 1))
                {
                    n = (Ficha)juego.getJugador1().getMano().buscarDato(n).getLiga().getDato();
                }
            }
        }

        public void asignarManoJ1(Juego juego)
        {
            manoJ1 = new Ficha[7];
            Ficha n;
            NodoSimple x;
            x = juego.getJugador1().getMano().getPrimero();
            n = (Ficha)x.getDato();
            for (int i = 0; i < manoJ1.Length; i++)
            {
                if (i == 0)
                {
                    manoJ1[i] = n;
                }
                else
                {
                    x = x.getLiga();
                    n = (Ficha)x.getDato();
                    manoJ1[i] = n;
                }
            }
        }

        public void crearFicha(int n1, int n2)
        {
            PictureBox ficha;
            ficha = new PictureBox
            {
                Size = new Size(55, 100),
                BackgroundImage = new Bitmap("..\\..\\Recursos\\" + n1 + " " + n2 + ".png"),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };
            ficha.Top = (mesa.Height - ficha.Height) / 2;
            ficha.Left = (mesa.Width * 2);
            fichasTablero.Add(ficha);
            mesa.Controls.Add(ficha);
        }

        public void crearFicha(Ficha n, bool izq_der, bool invertida)
        {
            PictureBox ficha;
            if (n.getN1() == n.getN2())
            {
                ficha = new PictureBox
                {
                    Size = new Size(55, 100),
                    BackgroundImage = new Bitmap("..\\..\\Recursos\\" + n.getUbicacion()),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackColor = Color.Transparent
                };
                if (izq_der) // Se pone a la derecha
                {
                    PictureBox referencia;
                    referencia = fichasTablero[fichasTablero.Count - 1];
                    ficha.Location = new Point(referencia.Location.X + 100, referencia.Location.Y - 25);
                    fichasTablero.Add(ficha);
                }
                else // Se pone a la izquierda
                {
                    PictureBox referencia;
                    referencia = fichasTablero[0];
                    ficha.Location = new Point(referencia.Location.X - 55, referencia.Location.Y - 25);
                    fichasTablero.Insert(0, ficha);
                }
                mesa.Controls.Add(ficha);
            }
            else
            {
                ficha = new PictureBox
                {
                    Size = new Size(100, 55),
                    BackgroundImage = new Bitmap("..\\..\\Recursos\\" + n.getUbicacion()),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackColor = Color.Transparent
                };
                checkInvertida(ficha, invertida);
                if (izq_der) // Se pone a la derecha
                {
                    PictureBox referencia;
                    referencia = fichasTablero[fichasTablero.Count - 1];
                    if (referencia.Size == new Size(55, 100))
                    {
                        ficha.Location = new Point(referencia.Location.X + 55, referencia.Location.Y + 25);
                    }
                    else
                    {
                        ficha.Location = new Point(referencia.Location.X + 100, referencia.Location.Y);
                    }
                    fichasTablero.Add(ficha);
                }
                else // Se pone a la izquierda
                {
                    PictureBox referencia;
                    referencia = fichasTablero[0];
                    if (referencia.Size == new Size(55, 100))
                    {
                        ficha.Location = new Point(referencia.Location.X - 100, referencia.Location.Y + 25);
                    }
                    else
                    {
                        ficha.Location = new Point(referencia.Location.X - 100, referencia.Location.Y);
                    }
                    fichasTablero.Insert(0, ficha);
                }
                mesa.Controls.Add(ficha);  // AQUI SE ANADE AL PANEL
            }
        }

        public void checkInvertida(PictureBox x, bool invertida)
        {
            if (invertida)
            {
                x.BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipX);
            }
            else
            {
                x.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
        }

        public void ponerDoble(int orden)
        {
            switch (orden)
            {
                case 1:
                    Ficha doce;
                    doce = new Ficha(6, 6);
                    for (int i = 0; i < fichasJ1.Count; i++)
                    {
                        if (manoJ1[i].esIgual(doce))
                        {
                            fichasJ1[i].Visible = false;
                            fichasJ1.RemoveAt(i);
                        }
                    }
                    break;
                case 2:
                    fichasJ2[fichasJ2.Count - 1].Visible = false;
                    fichasJ2.RemoveAt(fichasJ2.Count - 1);
                    break;
                case 3:
                    fichasJ3[fichasJ3.Count - 1].Visible = false;
                    fichasJ3.RemoveAt(fichasJ3.Count - 1);
                    break;
                case 4:
                    fichasJ4[fichasJ4.Count - 1].Visible = false;
                    fichasJ4.RemoveAt(fichasJ4.Count - 1);
                    break;
                default:
                    MessageBox.Show("Algo volvio a salir mal alv");
                    break;
            }
        }

        public bool getTurnoJ1()
        {
            return turnoJ1;
        }

        public void setTurnoJ1(bool turnoJ1)
        {
            this.turnoJ1 = turnoJ1;
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            iniciar.Visible = false;
            addMesa();
            addPasar();
            Jugador x;
            voltearFichasJ1(juego);
            crearFicha(6, 6);
            x = juego.buscarPrimero();
            ponerDoble(x.getOrden());
            juego.iniciarRonda(this, fichasJ2, fichasJ3, fichasJ4);
            mesa.AutoScrollPosition = new Point(1380);
        }

        public void presentarGanador(int i)
        {
            this.Controls.Remove(mesa);
            Jugador[] referencia;
            PictureBox ganador;
            Label felicitacion;
            Button regresar;
            referencia = juego.getJugadores();
            ganador = new PictureBox
            {
                Visible = true,
                Size = new Size(200, 200),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150)
            };
            felicitacion = new Label
            {
                Visible = true,
                Size = new Size(300, 40),
                Font = new Font("Tahoma", 14, FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                BackColor = System.Drawing.Color.Transparent,
                Location = new Point(this.Width / 2 - 100, this.Height / 2 + 60)
            };
            regresar = new Button
            {
                Size = new Size(135, 46),
                Font = new Font("Tahoma", 20, FontStyle.Regular),
                Text = "Regresar",
                Location = new Point(felicitacion.Location.X + 30, felicitacion.Location.Y + 45)
            };
            regresar.Click += new EventHandler(regresar_Click);
            switch (i)
            {
                case 0:
                    ganador.BackgroundImage = new Bitmap("..\\..\\Recursos\\Paca.png");
                    felicitacion.Text = "¡El ganador es " + referencia[i].getNombre() + '!';
                    felicitacion.ForeColor = System.Drawing.Color.Gold;
                    break;
                case 1:
                    ganador.BackgroundImage = new Bitmap("..\\..\\Recursos\\Paco.png");
                    felicitacion.Text = "¡El ganador es " + referencia[i].getNombre() + '!';
                    felicitacion.ForeColor = System.Drawing.Color.MediumSpringGreen;
                    break;
                case 2:
                    ganador.BackgroundImage = new Bitmap("..\\..\\Recursos\\Luisa.png");
                    felicitacion.Text = "¡El ganador es " + referencia[i].getNombre() + '!';
                    felicitacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                    break;
                case 3:
                    ganador.BackgroundImage = new Bitmap("..\\..\\Recursos\\Hugo.png");
                    felicitacion.Text = "¡El ganador es " + referencia[i].getNombre() + '!';
                    felicitacion.ForeColor = System.Drawing.Color.CornflowerBlue;
                    break;
                default:
                    MessageBox.Show("Hola monitor, un 5 porfa");
                    break;
            }
            this.Controls.Add(felicitacion);
            this.Controls.Add(ganador);
            this.Controls.Remove(iniciar);
            this.Controls.Remove(pasar);
            this.Controls.Add(regresar);
            turnoJ1 = false;
        }

        private void regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal x = new MenuPrincipal();
            x.Show();
        }

        public void abrirSonido()
        {
            bandaSonora = new SoundPlayer("..\\..\\Recursos\\BandaSonora.wav");
            bandaSonora.PlayLooping();
        }

        public Button getPasar()
        {
            return pasar;
        }
    }
}
