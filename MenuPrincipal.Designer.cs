namespace Logica
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.instrucciones = new System.Windows.Forms.Button();
            this.salir = new System.Windows.Forms.Button();
            this.jugar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // instrucciones
            // 
            this.instrucciones.BackColor = System.Drawing.Color.Transparent;
            this.instrucciones.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.instrucciones.Font = new System.Drawing.Font("Tahoma", 16.2F);
            this.instrucciones.Location = new System.Drawing.Point(397, 173);
            this.instrucciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.instrucciones.Name = "instrucciones";
            this.instrucciones.Size = new System.Drawing.Size(196, 46);
            this.instrucciones.TabIndex = 0;
            this.instrucciones.Text = "Instrucciones";
            this.instrucciones.UseVisualStyleBackColor = false;
            this.instrucciones.Click += new System.EventHandler(this.instrucciones_Click);
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.Transparent;
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.salir.Font = new System.Drawing.Font("Tahoma", 16.2F);
            this.salir.Location = new System.Drawing.Point(397, 223);
            this.salir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(196, 46);
            this.salir.TabIndex = 0;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // jugar
            // 
            this.jugar.BackColor = System.Drawing.Color.Transparent;
            this.jugar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.jugar.Font = new System.Drawing.Font("Tahoma", 16.2F);
            this.jugar.Location = new System.Drawing.Point(397, 122);
            this.jugar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.jugar.Name = "jugar";
            this.jugar.Size = new System.Drawing.Size(196, 46);
            this.jugar.TabIndex = 0;
            this.jugar.Text = "Jugar";
            this.jugar.UseVisualStyleBackColor = false;
            this.jugar.Click += new System.EventHandler(this.jugar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 158);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(12, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(581, 90);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(605, 275);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.jugar);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.instrucciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.Text = "D O M I N O";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button instrucciones;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button jugar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}