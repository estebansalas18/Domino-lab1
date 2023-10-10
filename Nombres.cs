using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaDomino
{
    public partial class Nombres : Form
    {
        public Nombres()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void continuar_Click(object sender, EventArgs e)
        {
            Juego j = new Juego();
            j.crearFichas();
            j.crearJugadores(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
            j.repartirFichas();
            Tablero x = new Tablero(j);
            x.Show();
            this.Hide();
        }
    }
}
