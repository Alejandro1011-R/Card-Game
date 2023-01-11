namespace The_Clam_Boat
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Salir = new CustomControls.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.JvsJ = new CustomControls.RJControls.RJButton();
            this.JvsPC = new CustomControls.RJControls.RJButton();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.rjButton2 = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 702);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.Transparent;
            this.Salir.BackgroundColor = System.Drawing.Color.Transparent;
            this.Salir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Salir.BorderRadius = 30;
            this.Salir.BorderSize = 3;
            this.Salir.FlatAppearance.BorderSize = 0;
            this.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salir.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.ForeColor = System.Drawing.Color.White;
            this.Salir.Location = new System.Drawing.Point(513, 599);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(256, 64);
            this.Salir.TabIndex = 8;
            this.Salir.Text = "Salir";
            this.Salir.TextColor = System.Drawing.Color.White;
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(297, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(694, 98);
            this.label1.TabIndex = 7;
            this.label1.Text = "THE CLAM BOAT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // JvsJ
            // 
            this.JvsJ.BackColor = System.Drawing.Color.Transparent;
            this.JvsJ.BackgroundColor = System.Drawing.Color.Transparent;
            this.JvsJ.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.JvsJ.BorderRadius = 30;
            this.JvsJ.BorderSize = 3;
            this.JvsJ.FlatAppearance.BorderSize = 0;
            this.JvsJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JvsJ.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JvsJ.ForeColor = System.Drawing.Color.White;
            this.JvsJ.Location = new System.Drawing.Point(513, 315);
            this.JvsJ.Name = "JvsJ";
            this.JvsJ.Size = new System.Drawing.Size(256, 67);
            this.JvsJ.TabIndex = 6;
            this.JvsJ.Text = "Jugador vs Jugador";
            this.JvsJ.TextColor = System.Drawing.Color.White;
            this.JvsJ.UseVisualStyleBackColor = false;
            this.JvsJ.Click += new System.EventHandler(this.JvsJ_Click);
            // 
            // JvsPC
            // 
            this.JvsPC.BackColor = System.Drawing.Color.Transparent;
            this.JvsPC.BackgroundColor = System.Drawing.Color.Transparent;
            this.JvsPC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.JvsPC.BorderRadius = 30;
            this.JvsPC.BorderSize = 3;
            this.JvsPC.FlatAppearance.BorderSize = 0;
            this.JvsPC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JvsPC.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JvsPC.ForeColor = System.Drawing.Color.White;
            this.JvsPC.Location = new System.Drawing.Point(504, 223);
            this.JvsPC.Name = "JvsPC";
            this.JvsPC.Size = new System.Drawing.Size(256, 67);
            this.JvsPC.TabIndex = 5;
            this.JvsPC.Text = "Jugador vs PC";
            this.JvsPC.TextColor = System.Drawing.Color.White;
            this.JvsPC.UseVisualStyleBackColor = false;
            this.JvsPC.Click += new System.EventHandler(this.JvsPC_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Transparent;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rjButton1.BorderRadius = 30;
            this.rjButton1.BorderSize = 3;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(513, 412);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(256, 66);
            this.rjButton1.TabIndex = 9;
            this.rjButton1.Text = "Crear Cartas";
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.Transparent;
            this.rjButton2.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rjButton2.BorderRadius = 30;
            this.rjButton2.BorderSize = 3;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Location = new System.Drawing.Point(513, 506);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(256, 66);
            this.rjButton2.TabIndex = 10;
            this.rjButton2.Text = "Reglas del Juego";
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1280, 702);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JvsJ);
            this.Controls.Add(this.JvsPC);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1280, 702);
            this.MinimumSize = new System.Drawing.Size(1280, 702);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RJControls.RJButton Salir;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJButton JvsJ;
        private CustomControls.RJControls.RJButton JvsPC;
        private System.ServiceProcess.ServiceController serviceController1;
        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJButton rjButton2;
    }
}

