namespace Cliente
{
    partial class Juego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Juego));
            this.btnConectar = new System.Windows.Forms.Button();
            this.labelDesconectado = new System.Windows.Forms.Label();
            this.groupBoxEstado = new System.Windows.Forms.GroupBox();
            this.labelConectado = new System.Windows.Forms.Label();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTurno = new System.Windows.Forms.Label();
            this.groupBoxEstadoJuego = new System.Windows.Forms.GroupBox();
            this.labelEstadoJuego = new System.Windows.Forms.Label();
            this.btnPedirCarta = new System.Windows.Forms.Button();
            this.btnQuedarse = new System.Windows.Forms.Button();
            this.campoImagen = new System.Windows.Forms.PictureBox();
            this.labelSumaCartas = new System.Windows.Forms.Label();
            this.groupBoxPuntaje = new System.Windows.Forms.GroupBox();
            this.txtSumaOponente = new System.Windows.Forms.TextBox();
            this.txtSumaCartas = new System.Windows.Forms.TextBox();
            this.labelSumaOponente = new System.Windows.Forms.Label();
            this.campoImagenInicial = new System.Windows.Forms.PictureBox();
            this.groupBoxEstado.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxEstadoJuego.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.campoImagen)).BeginInit();
            this.groupBoxPuntaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.campoImagenInicial)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConectar.ForeColor = System.Drawing.Color.Green;
            this.btnConectar.Location = new System.Drawing.Point(6, 19);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(105, 39);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // labelDesconectado
            // 
            this.labelDesconectado.AutoSize = true;
            this.labelDesconectado.BackColor = System.Drawing.Color.Transparent;
            this.labelDesconectado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesconectado.ForeColor = System.Drawing.Color.Red;
            this.labelDesconectado.Location = new System.Drawing.Point(122, 78);
            this.labelDesconectado.Name = "labelDesconectado";
            this.labelDesconectado.Size = new System.Drawing.Size(181, 24);
            this.labelDesconectado.TabIndex = 1;
            this.labelDesconectado.Text = "DESCONECTADO";
            // 
            // groupBoxEstado
            // 
            this.groupBoxEstado.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEstado.Controls.Add(this.labelConectado);
            this.groupBoxEstado.Controls.Add(this.btnDesconectar);
            this.groupBoxEstado.Controls.Add(this.labelDesconectado);
            this.groupBoxEstado.Controls.Add(this.btnConectar);
            this.groupBoxEstado.ForeColor = System.Drawing.Color.Green;
            this.groupBoxEstado.Location = new System.Drawing.Point(18, 21);
            this.groupBoxEstado.Name = "groupBoxEstado";
            this.groupBoxEstado.Size = new System.Drawing.Size(309, 128);
            this.groupBoxEstado.TabIndex = 2;
            this.groupBoxEstado.TabStop = false;
            this.groupBoxEstado.Text = "Estado conexión";
            // 
            // labelConectado
            // 
            this.labelConectado.AutoSize = true;
            this.labelConectado.BackColor = System.Drawing.Color.Transparent;
            this.labelConectado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConectado.ForeColor = System.Drawing.Color.Lime;
            this.labelConectado.Location = new System.Drawing.Point(122, 24);
            this.labelConectado.Name = "labelConectado";
            this.labelConectado.Size = new System.Drawing.Size(140, 24);
            this.labelConectado.TabIndex = 2;
            this.labelConectado.Text = "CONECTADO";
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDesconectar.ForeColor = System.Drawing.Color.Red;
            this.btnDesconectar.Location = new System.Drawing.Point(6, 73);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(105, 39);
            this.btnDesconectar.TabIndex = 1;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = false;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.labelTurno);
            this.groupBox1.ForeColor = System.Drawing.Color.Aqua;
            this.groupBox1.Location = new System.Drawing.Point(196, 285);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 55);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado Turno";
            // 
            // labelTurno
            // 
            this.labelTurno.AutoSize = true;
            this.labelTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurno.Location = new System.Drawing.Point(85, 16);
            this.labelTurno.Name = "labelTurno";
            this.labelTurno.Size = new System.Drawing.Size(92, 25);
            this.labelTurno.TabIndex = 0;
            this.labelTurno.Text = "Tu turno";
            // 
            // groupBoxEstadoJuego
            // 
            this.groupBoxEstadoJuego.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEstadoJuego.Controls.Add(this.labelEstadoJuego);
            this.groupBoxEstadoJuego.ForeColor = System.Drawing.Color.Orange;
            this.groupBoxEstadoJuego.Location = new System.Drawing.Point(196, 186);
            this.groupBoxEstadoJuego.Name = "groupBoxEstadoJuego";
            this.groupBoxEstadoJuego.Size = new System.Drawing.Size(296, 58);
            this.groupBoxEstadoJuego.TabIndex = 4;
            this.groupBoxEstadoJuego.TabStop = false;
            this.groupBoxEstadoJuego.Text = "Estado Juego";
            // 
            // labelEstadoJuego
            // 
            this.labelEstadoJuego.AutoSize = true;
            this.labelEstadoJuego.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoJuego.Location = new System.Drawing.Point(62, 16);
            this.labelEstadoJuego.Name = "labelEstadoJuego";
            this.labelEstadoJuego.Size = new System.Drawing.Size(151, 25);
            this.labelEstadoJuego.TabIndex = 1;
            this.labelEstadoJuego.Text = "Juego iniciado";
            // 
            // btnPedirCarta
            // 
            this.btnPedirCarta.Location = new System.Drawing.Point(18, 363);
            this.btnPedirCarta.Name = "btnPedirCarta";
            this.btnPedirCarta.Size = new System.Drawing.Size(112, 54);
            this.btnPedirCarta.TabIndex = 5;
            this.btnPedirCarta.Text = "Solicitar carta";
            this.btnPedirCarta.UseVisualStyleBackColor = true;
            this.btnPedirCarta.Click += new System.EventHandler(this.btnPedirCarta_Click);
            // 
            // btnQuedarse
            // 
            this.btnQuedarse.Location = new System.Drawing.Point(18, 443);
            this.btnQuedarse.Name = "btnQuedarse";
            this.btnQuedarse.Size = new System.Drawing.Size(111, 54);
            this.btnQuedarse.TabIndex = 6;
            this.btnQuedarse.Text = "Pasar turno";
            this.btnQuedarse.UseVisualStyleBackColor = true;
            this.btnQuedarse.Click += new System.EventHandler(this.btnQuedarse_Click);
            // 
            // campoImagen
            // 
            this.campoImagen.BackColor = System.Drawing.Color.Transparent;
            this.campoImagen.Location = new System.Drawing.Point(33, 186);
            this.campoImagen.Name = "campoImagen";
            this.campoImagen.Size = new System.Drawing.Size(90, 154);
            this.campoImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.campoImagen.TabIndex = 7;
            this.campoImagen.TabStop = false;
            // 
            // labelSumaCartas
            // 
            this.labelSumaCartas.AutoSize = true;
            this.labelSumaCartas.BackColor = System.Drawing.Color.Transparent;
            this.labelSumaCartas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSumaCartas.Location = new System.Drawing.Point(17, 34);
            this.labelSumaCartas.Name = "labelSumaCartas";
            this.labelSumaCartas.Size = new System.Drawing.Size(150, 25);
            this.labelSumaCartas.TabIndex = 8;
            this.labelSumaCartas.Text = "Suma cartas:";
            // 
            // groupBoxPuntaje
            // 
            this.groupBoxPuntaje.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxPuntaje.Controls.Add(this.txtSumaOponente);
            this.groupBoxPuntaje.Controls.Add(this.txtSumaCartas);
            this.groupBoxPuntaje.Controls.Add(this.labelSumaOponente);
            this.groupBoxPuntaje.Controls.Add(this.labelSumaCartas);
            this.groupBoxPuntaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPuntaje.Location = new System.Drawing.Point(196, 363);
            this.groupBoxPuntaje.Name = "groupBoxPuntaje";
            this.groupBoxPuntaje.Size = new System.Drawing.Size(296, 135);
            this.groupBoxPuntaje.TabIndex = 9;
            this.groupBoxPuntaje.TabStop = false;
            this.groupBoxPuntaje.Text = "PUNTAJE";
            // 
            // txtSumaOponente
            // 
            this.txtSumaOponente.Enabled = false;
            this.txtSumaOponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumaOponente.Location = new System.Drawing.Point(220, 86);
            this.txtSumaOponente.Name = "txtSumaOponente";
            this.txtSumaOponente.ReadOnly = true;
            this.txtSumaOponente.Size = new System.Drawing.Size(41, 29);
            this.txtSumaOponente.TabIndex = 11;
            // 
            // txtSumaCartas
            // 
            this.txtSumaCartas.Enabled = false;
            this.txtSumaCartas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumaCartas.Location = new System.Drawing.Point(220, 34);
            this.txtSumaCartas.Name = "txtSumaCartas";
            this.txtSumaCartas.ReadOnly = true;
            this.txtSumaCartas.Size = new System.Drawing.Size(41, 29);
            this.txtSumaCartas.TabIndex = 10;
            // 
            // labelSumaOponente
            // 
            this.labelSumaOponente.AutoSize = true;
            this.labelSumaOponente.BackColor = System.Drawing.Color.Transparent;
            this.labelSumaOponente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSumaOponente.Location = new System.Drawing.Point(17, 86);
            this.labelSumaOponente.Name = "labelSumaOponente";
            this.labelSumaOponente.Size = new System.Drawing.Size(183, 25);
            this.labelSumaOponente.TabIndex = 9;
            this.labelSumaOponente.Text = "Suma oponente:";
            // 
            // campoImagenInicial
            // 
            this.campoImagenInicial.BackColor = System.Drawing.Color.Transparent;
            this.campoImagenInicial.Image = global::Cliente.Properties.Resources.juego1;
            this.campoImagenInicial.InitialImage = null;
            this.campoImagenInicial.Location = new System.Drawing.Point(352, 2);
            this.campoImagenInicial.Name = "campoImagenInicial";
            this.campoImagenInicial.Size = new System.Drawing.Size(172, 178);
            this.campoImagenInicial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.campoImagenInicial.TabIndex = 10;
            this.campoImagenInicial.TabStop = false;
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::Cliente.Properties.Resources.maxresdefault;
            this.ClientSize = new System.Drawing.Size(536, 532);
            this.Controls.Add(this.campoImagenInicial);
            this.Controls.Add(this.groupBoxPuntaje);
            this.Controls.Add(this.campoImagen);
            this.Controls.Add(this.btnQuedarse);
            this.Controls.Add(this.btnPedirCarta);
            this.Controls.Add(this.groupBoxEstadoJuego);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEstado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlackJack 1.0";
            this.Load += new System.EventHandler(this.Juego_Load);
            this.groupBoxEstado.ResumeLayout(false);
            this.groupBoxEstado.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxEstadoJuego.ResumeLayout(false);
            this.groupBoxEstadoJuego.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.campoImagen)).EndInit();
            this.groupBoxPuntaje.ResumeLayout(false);
            this.groupBoxPuntaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.campoImagenInicial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label labelDesconectado;
        private System.Windows.Forms.GroupBox groupBoxEstado;
        private System.Windows.Forms.Label labelConectado;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTurno;
        private System.Windows.Forms.GroupBox groupBoxEstadoJuego;
        private System.Windows.Forms.Label labelEstadoJuego;
        private System.Windows.Forms.Button btnPedirCarta;
        private System.Windows.Forms.Button btnQuedarse;
        private System.Windows.Forms.PictureBox campoImagen;
        private System.Windows.Forms.Label labelSumaCartas;
        private System.Windows.Forms.GroupBox groupBoxPuntaje;
        private System.Windows.Forms.TextBox txtSumaOponente;
        private System.Windows.Forms.TextBox txtSumaCartas;
        private System.Windows.Forms.Label labelSumaOponente;
        private System.Windows.Forms.PictureBox campoImagenInicial;
    }
}

