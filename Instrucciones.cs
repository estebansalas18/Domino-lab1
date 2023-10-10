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
    public partial class Instrucciones : Form
    {
        public Instrucciones()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal x = new MenuPrincipal();
            x.Show();
        }
    }
}
