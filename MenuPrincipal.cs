using PracticaDomino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Logica
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            abrirSonido();
            InitializeComponent();
            this.CenterToScreen();
        }

        private void jugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Nombres n = new Nombres();
            n.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void abrirSonido()
        {
            SoundPlayer bandaSonora = new SoundPlayer("..\\..\\Recursos\\SonidoMenu.wav");
            bandaSonora.PlayLooping();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void instrucciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instrucciones i = new Instrucciones();
            i.Show();
        }
    }
}
