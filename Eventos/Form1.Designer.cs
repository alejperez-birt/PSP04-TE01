namespace Eventos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Btn_ActivarConsulta = new Button();
            Btn_ActivarEnvioFTP = new Button();
            Lbl_Provincia = new Label();
            Cmb_Provincia = new ComboBox();
            Cmb_Municipio = new ComboBox();
            Lbl_Municipio = new Label();
            Cmb_Evento = new ComboBox();
            Lbl_Evento = new Label();
            Lbl_DatosEvento = new Label();
            Txt_DatosEvento = new TextBox();
            Pic_Imagen = new PictureBox();
            Txt_Servidor = new TextBox();
            Lbl_Servidor = new Label();
            Txt_Usuario = new TextBox();
            Lbl_Usuario = new Label();
            Txt_Contrasena = new TextBox();
            Lbl_Contrasena = new Label();
            Btn_Guardar = new Button();
            ((System.ComponentModel.ISupportInitialize)Pic_Imagen).BeginInit();
            SuspendLayout();
            // 
            // Btn_ActivarConsulta
            // 
            Btn_ActivarConsulta.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_ActivarConsulta.Location = new Point(50, 50);
            Btn_ActivarConsulta.Name = "Btn_ActivarConsulta";
            Btn_ActivarConsulta.Size = new Size(150, 50);
            Btn_ActivarConsulta.TabIndex = 0;
            Btn_ActivarConsulta.Text = "Activar Consulta";
            Btn_ActivarConsulta.UseVisualStyleBackColor = true;
            Btn_ActivarConsulta.Click += Btn_ActivarConsulta_Click;
            // 
            // Btn_ActivarEnvioFTP
            // 
            Btn_ActivarEnvioFTP.Enabled = false;
            Btn_ActivarEnvioFTP.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_ActivarEnvioFTP.Location = new Point(50, 425);
            Btn_ActivarEnvioFTP.Name = "Btn_ActivarEnvioFTP";
            Btn_ActivarEnvioFTP.Size = new Size(150, 50);
            Btn_ActivarEnvioFTP.TabIndex = 1;
            Btn_ActivarEnvioFTP.Text = "Activar Envio FTP";
            Btn_ActivarEnvioFTP.UseVisualStyleBackColor = true;
            Btn_ActivarEnvioFTP.Click += Btn_ActivarEnvioFTP_Click;
            // 
            // Lbl_Provincia
            // 
            Lbl_Provincia.AutoSize = true;
            Lbl_Provincia.Enabled = false;
            Lbl_Provincia.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_Provincia.Location = new Point(250, 53);
            Lbl_Provincia.Name = "Lbl_Provincia";
            Lbl_Provincia.Size = new Size(119, 15);
            Lbl_Provincia.TabIndex = 3;
            Lbl_Provincia.Text = "Provincia / Lurraldea";
            // 
            // Cmb_Provincia
            // 
            Cmb_Provincia.Enabled = false;
            Cmb_Provincia.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Cmb_Provincia.FormattingEnabled = true;
            Cmb_Provincia.Location = new Point(400, 50);
            Cmb_Provincia.Name = "Cmb_Provincia";
            Cmb_Provincia.Size = new Size(250, 23);
            Cmb_Provincia.TabIndex = 4;
            Cmb_Provincia.SelectedIndexChanged += Cmb_Provincia_SelectedIndexChanged;
            // 
            // Cmb_Municipio
            // 
            Cmb_Municipio.Enabled = false;
            Cmb_Municipio.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Cmb_Municipio.FormattingEnabled = true;
            Cmb_Municipio.Location = new Point(400, 110);
            Cmb_Municipio.Name = "Cmb_Municipio";
            Cmb_Municipio.Size = new Size(250, 23);
            Cmb_Municipio.TabIndex = 6;
            Cmb_Municipio.SelectedIndexChanged += Cmb_Municipio_SelectedIndexChanged;
            // 
            // Lbl_Municipio
            // 
            Lbl_Municipio.AutoSize = true;
            Lbl_Municipio.Enabled = false;
            Lbl_Municipio.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_Municipio.Location = new Point(250, 113);
            Lbl_Municipio.Name = "Lbl_Municipio";
            Lbl_Municipio.Size = new Size(104, 15);
            Lbl_Municipio.TabIndex = 5;
            Lbl_Municipio.Text = "Municipio / Herria";
            // 
            // Cmb_Evento
            // 
            Cmb_Evento.Enabled = false;
            Cmb_Evento.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Cmb_Evento.FormattingEnabled = true;
            Cmb_Evento.Location = new Point(400, 170);
            Cmb_Evento.Name = "Cmb_Evento";
            Cmb_Evento.Size = new Size(250, 23);
            Cmb_Evento.TabIndex = 8;
            Cmb_Evento.SelectedIndexChanged += Cmb_Evento_SelectedIndexChanged;
            // 
            // Lbl_Evento
            // 
            Lbl_Evento.AutoSize = true;
            Lbl_Evento.Enabled = false;
            Lbl_Evento.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_Evento.Location = new Point(250, 173);
            Lbl_Evento.Name = "Lbl_Evento";
            Lbl_Evento.Size = new Size(44, 15);
            Lbl_Evento.TabIndex = 7;
            Lbl_Evento.Text = "Evento";
            // 
            // Lbl_DatosEvento
            // 
            Lbl_DatosEvento.AutoSize = true;
            Lbl_DatosEvento.Enabled = false;
            Lbl_DatosEvento.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_DatosEvento.Location = new Point(250, 233);
            Lbl_DatosEvento.Name = "Lbl_DatosEvento";
            Lbl_DatosEvento.Size = new Size(98, 15);
            Lbl_DatosEvento.TabIndex = 9;
            Lbl_DatosEvento.Text = "Datos del evento";
            // 
            // Txt_DatosEvento
            // 
            Txt_DatosEvento.Enabled = false;
            Txt_DatosEvento.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_DatosEvento.Location = new Point(400, 230);
            Txt_DatosEvento.Multiline = true;
            Txt_DatosEvento.Name = "Txt_DatosEvento";
            Txt_DatosEvento.Size = new Size(250, 120);
            Txt_DatosEvento.TabIndex = 10;
            // 
            // Pic_Imagen
            // 
            Pic_Imagen.BackgroundImageLayout = ImageLayout.Stretch;
            Pic_Imagen.Enabled = false;
            Pic_Imagen.Location = new Point(700, 50);
            Pic_Imagen.Name = "Pic_Imagen";
            Pic_Imagen.Size = new Size(300, 300);
            Pic_Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            Pic_Imagen.TabIndex = 11;
            Pic_Imagen.TabStop = false;
            // 
            // Txt_Servidor
            // 
            Txt_Servidor.Enabled = false;
            Txt_Servidor.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Servidor.Location = new Point(400, 425);
            Txt_Servidor.Name = "Txt_Servidor";
            Txt_Servidor.Size = new Size(250, 21);
            Txt_Servidor.TabIndex = 13;
            Txt_Servidor.Text = "ftp.dlptest.com";
            // 
            // Lbl_Servidor
            // 
            Lbl_Servidor.AutoSize = true;
            Lbl_Servidor.Enabled = false;
            Lbl_Servidor.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_Servidor.Location = new Point(250, 428);
            Lbl_Servidor.Name = "Lbl_Servidor";
            Lbl_Servidor.Size = new Size(52, 15);
            Lbl_Servidor.TabIndex = 12;
            Lbl_Servidor.Text = "Servidor";
            // 
            // Txt_Usuario
            // 
            Txt_Usuario.Enabled = false;
            Txt_Usuario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Usuario.Location = new Point(400, 475);
            Txt_Usuario.Name = "Txt_Usuario";
            Txt_Usuario.Size = new Size(250, 21);
            Txt_Usuario.TabIndex = 15;
            Txt_Usuario.Text = "dlpuser";
            // 
            // Lbl_Usuario
            // 
            Lbl_Usuario.AutoSize = true;
            Lbl_Usuario.Enabled = false;
            Lbl_Usuario.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_Usuario.Location = new Point(250, 478);
            Lbl_Usuario.Name = "Lbl_Usuario";
            Lbl_Usuario.Size = new Size(50, 15);
            Lbl_Usuario.TabIndex = 14;
            Lbl_Usuario.Text = "Usuario";
            // 
            // Txt_Contrasena
            // 
            Txt_Contrasena.Enabled = false;
            Txt_Contrasena.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Txt_Contrasena.Location = new Point(400, 525);
            Txt_Contrasena.Name = "Txt_Contrasena";
            Txt_Contrasena.PasswordChar = '*';
            Txt_Contrasena.Size = new Size(250, 21);
            Txt_Contrasena.TabIndex = 17;
            Txt_Contrasena.Text = "rNrKYTX9g7z3RgJRmxWuGHbeu";
            // 
            // Lbl_Contrasena
            // 
            Lbl_Contrasena.AutoSize = true;
            Lbl_Contrasena.Enabled = false;
            Lbl_Contrasena.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Lbl_Contrasena.Location = new Point(250, 528);
            Lbl_Contrasena.Name = "Lbl_Contrasena";
            Lbl_Contrasena.Size = new Size(70, 15);
            Lbl_Contrasena.TabIndex = 16;
            Lbl_Contrasena.Text = "Contraseña";
            // 
            // Btn_Guardar
            // 
            Btn_Guardar.Enabled = false;
            Btn_Guardar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Btn_Guardar.Location = new Point(850, 496);
            Btn_Guardar.Name = "Btn_Guardar";
            Btn_Guardar.Size = new Size(150, 50);
            Btn_Guardar.TabIndex = 18;
            Btn_Guardar.Text = "Guardar";
            Btn_Guardar.UseVisualStyleBackColor = true;
            Btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 576);
            Controls.Add(Btn_Guardar);
            Controls.Add(Txt_Contrasena);
            Controls.Add(Lbl_Contrasena);
            Controls.Add(Txt_Usuario);
            Controls.Add(Lbl_Usuario);
            Controls.Add(Txt_Servidor);
            Controls.Add(Lbl_Servidor);
            Controls.Add(Pic_Imagen);
            Controls.Add(Txt_DatosEvento);
            Controls.Add(Lbl_DatosEvento);
            Controls.Add(Cmb_Evento);
            Controls.Add(Lbl_Evento);
            Controls.Add(Cmb_Municipio);
            Controls.Add(Lbl_Municipio);
            Controls.Add(Cmb_Provincia);
            Controls.Add(Lbl_Provincia);
            Controls.Add(Btn_ActivarEnvioFTP);
            Controls.Add(Btn_ActivarConsulta);
            Name = "Form1";
            Text = "Consultar Eventos Euskadi";
            ((System.ComponentModel.ISupportInitialize)Pic_Imagen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_ActivarConsulta;
        private Button Btn_ActivarEnvioFTP;
        private Label Lbl_Provincia;
        private ComboBox Cmb_Provincia;
        private ComboBox Cmb_Municipio;
        private Label Lbl_Municipio;
        private ComboBox Cmb_Evento;
        private Label Lbl_Evento;
        private Label Lbl_DatosEvento;
        private TextBox Txt_DatosEvento;
        private PictureBox Pic_Imagen;
        private TextBox Txt_Servidor;
        private Label Lbl_Servidor;
        private TextBox Txt_Usuario;
        private Label Lbl_Usuario;
        private TextBox Txt_Contrasena;
        private Label Lbl_Contrasena;
        private Button Btn_Guardar;
    }
}