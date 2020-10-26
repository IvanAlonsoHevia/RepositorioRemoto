namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.conectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PerdedorBox = new System.Windows.Forms.TextBox();
            this.UsernameConsultaBox = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.registrar = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.FechaBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumJugadoresBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PuntuacionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Edgar = new System.Windows.Forms.RadioButton();
            this.Omar = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.PosicionBox = new System.Windows.Forms.TextBox();
            this.Ivan = new System.Windows.Forms.RadioButton();
            this.desconectar = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(200, 48);
            this.Username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(218, 26);
            this.Username.TabIndex = 3;
            // 
            // conectar
            // 
            this.conectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conectar.Location = new System.Drawing.Point(38, 62);
            this.conectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.conectar.Name = "conectar";
            this.conectar.Size = new System.Drawing.Size(224, 48);
            this.conectar.TabIndex = 4;
            this.conectar.Text = "conectar";
            this.conectar.UseVisualStyleBackColor = true;
            this.conectar.Click += new System.EventHandler(this.conectar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.logout);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.PerdedorBox);
            this.groupBox1.Controls.Add(this.UsernameConsultaBox);
            this.groupBox1.Controls.Add(this.enviar);
            this.groupBox1.Controls.Add(this.registrar);
            this.groupBox1.Controls.Add(this.login);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.FechaBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NumJugadoresBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.PuntuacionBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Password);
            this.groupBox1.Controls.Add(this.Edgar);
            this.groupBox1.Controls.Add(this.Omar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.PosicionBox);
            this.groupBox1.Controls.Add(this.Ivan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Username);
            this.groupBox1.Location = new System.Drawing.Point(34, 133);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1273, 358);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(812, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Perdedor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1052, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Username consulta";
            // 
            // PerdedorBox
            // 
            this.PerdedorBox.Location = new System.Drawing.Point(737, 110);
            this.PerdedorBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PerdedorBox.Name = "PerdedorBox";
            this.PerdedorBox.Size = new System.Drawing.Size(224, 26);
            this.PerdedorBox.TabIndex = 14;
            // 
            // UsernameConsultaBox
            // 
            this.UsernameConsultaBox.Location = new System.Drawing.Point(993, 110);
            this.UsernameConsultaBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UsernameConsultaBox.Name = "UsernameConsultaBox";
            this.UsernameConsultaBox.Size = new System.Drawing.Size(259, 26);
            this.UsernameConsultaBox.TabIndex = 14;
            // 
            // enviar
            // 
            this.enviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.Location = new System.Drawing.Point(22, 300);
            this.enviar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(224, 48);
            this.enviar.TabIndex = 12;
            this.enviar.Text = "enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // registrar
            // 
            this.registrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrar.Location = new System.Drawing.Point(265, 137);
            this.registrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(224, 48);
            this.registrar.TabIndex = 11;
            this.registrar.Text = "registrarse";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.registrar_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(22, 137);
            this.login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(224, 48);
            this.login.TabIndex = 11;
            this.login.Text = "login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1066, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha y Hora";
            // 
            // FechaBox
            // 
            this.FechaBox.Location = new System.Drawing.Point(993, 45);
            this.FechaBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FechaBox.Name = "FechaBox";
            this.FechaBox.Size = new System.Drawing.Size(259, 26);
            this.FechaBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(760, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Número de Jugadores";
            // 
            // NumJugadoresBox
            // 
            this.NumJugadoresBox.Location = new System.Drawing.Point(737, 48);
            this.NumJugadoresBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NumJugadoresBox.Name = "NumJugadoresBox";
            this.NumJugadoresBox.Size = new System.Drawing.Size(224, 26);
            this.NumJugadoresBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Puntuación";
            // 
            // PuntuacionBox
            // 
            this.PuntuacionBox.Location = new System.Drawing.Point(501, 110);
            this.PuntuacionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PuntuacionBox.Name = "PuntuacionBox";
            this.PuntuacionBox.Size = new System.Drawing.Size(204, 26);
            this.PuntuacionBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Password";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(200, 89);
            this.Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(218, 26);
            this.Password.TabIndex = 12;
            // 
            // Edgar
            // 
            this.Edgar.AutoSize = true;
            this.Edgar.Location = new System.Drawing.Point(22, 229);
            this.Edgar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Edgar.Name = "Edgar";
            this.Edgar.Size = new System.Drawing.Size(904, 24);
            this.Edgar.TabIndex = 7;
            this.Edgar.TabStop = true;
            this.Edgar.Text = "Quiero el ganador que ha jugado contra el usuario que te doy en las partidas con " +
                "un número de jugadores mayor o igual a 3.";
            this.Edgar.UseVisualStyleBackColor = true;
            // 
            // Omar
            // 
            this.Omar.AutoSize = true;
            this.Omar.Location = new System.Drawing.Point(22, 263);
            this.Omar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Omar.Name = "Omar";
            this.Omar.Size = new System.Drawing.Size(1068, 24);
            this.Omar.TabIndex = 7;
            this.Omar.TabStop = true;
            this.Omar.Text = "Quiero las IDs de partida. Te doy Puntuacion minima total, Num Jugadores minimos " +
                "y La fecha y Hora en el formato siguiente (dd-mm-aaaa-hh:mm)";
            this.Omar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Posición";
            // 
            // PosicionBox
            // 
            this.PosicionBox.Location = new System.Drawing.Point(501, 45);
            this.PosicionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PosicionBox.Name = "PosicionBox";
            this.PosicionBox.Size = new System.Drawing.Size(204, 26);
            this.PosicionBox.TabIndex = 9;
            // 
            // Ivan
            // 
            this.Ivan.AutoSize = true;
            this.Ivan.Location = new System.Drawing.Point(22, 195);
            this.Ivan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Ivan.Name = "Ivan";
            this.Ivan.Size = new System.Drawing.Size(1230, 24);
            this.Ivan.TabIndex = 8;
            this.Ivan.TabStop = true;
            this.Ivan.Text = "Quiero el nombre de usuario. Te doy  la posicion del jugador con una puntuación p" +
                "or debajo de la propuesta en la misma partida en la que el usuario propuesto ha " +
                "perdido.";
            this.Ivan.UseVisualStyleBackColor = true;
            // 
            // desconectar
            // 
            this.desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectar.Location = new System.Drawing.Point(38, 511);
            this.desconectar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(220, 82);
            this.desconectar.TabIndex = 10;
            this.desconectar.Text = "desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // logout
            // 
            this.logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.Location = new System.Drawing.Point(501, 137);
            this.logout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(224, 48);
            this.logout.TabIndex = 11;
            this.logout.Text = "log out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 865);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.conectar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.Button conectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Edgar;
        private System.Windows.Forms.RadioButton Ivan;
        private System.Windows.Forms.RadioButton Omar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PosicionBox;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FechaBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NumJugadoresBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PuntuacionBox;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UsernameConsultaBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PerdedorBox;
        private System.Windows.Forms.Button logout;
    }
}

