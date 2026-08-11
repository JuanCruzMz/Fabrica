namespace Interfaz_Fabrica
{
    partial class FormDeInicio
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
            txt_Nombre = new TextBox();
            btn_Iniciar_Sesion = new Button();
            txt_Contrasenia = new TextBox();
            btn_Cerrar = new Button();
            btn_AutocompletarSupervisor = new Button();
            btn_Ayuda = new Button();
            btn_AutocompletarOperario = new Button();
            SuspendLayout();
            // 
            // txt_Nombre
            // 
            txt_Nombre.Location = new Point(246, 99);
            txt_Nombre.Name = "txt_Nombre";
            txt_Nombre.PlaceholderText = "Escriba su nombre";
            txt_Nombre.Size = new Size(260, 27);
            txt_Nombre.TabIndex = 0;
            txt_Nombre.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_Iniciar_Sesion
            // 
            btn_Iniciar_Sesion.BackColor = Color.FromArgb(128, 255, 128);
            btn_Iniciar_Sesion.ImeMode = ImeMode.NoControl;
            btn_Iniciar_Sesion.Location = new Point(105, 287);
            btn_Iniciar_Sesion.Name = "btn_Iniciar_Sesion";
            btn_Iniciar_Sesion.Size = new Size(200, 100);
            btn_Iniciar_Sesion.TabIndex = 4;
            btn_Iniciar_Sesion.Text = "Iniciar sesión";
            btn_Iniciar_Sesion.UseVisualStyleBackColor = false;
            btn_Iniciar_Sesion.Click += btn_Iniciar_Sesion_Click;
            // 
            // txt_Contrasenia
            // 
            txt_Contrasenia.Location = new Point(246, 177);
            txt_Contrasenia.Name = "txt_Contrasenia";
            txt_Contrasenia.PasswordChar = '*';
            txt_Contrasenia.PlaceholderText = "Escriba su contraseña";
            txt_Contrasenia.RightToLeft = RightToLeft.No;
            txt_Contrasenia.Size = new Size(260, 27);
            txt_Contrasenia.TabIndex = 1;
            txt_Contrasenia.Tag = "";
            txt_Contrasenia.TextAlign = HorizontalAlignment.Center;
            txt_Contrasenia.UseSystemPasswordChar = true;
            // 
            // btn_Cerrar
            // 
            btn_Cerrar.BackColor = Color.Red;
            btn_Cerrar.ImeMode = ImeMode.NoControl;
            btn_Cerrar.Location = new Point(446, 287);
            btn_Cerrar.Name = "btn_Cerrar";
            btn_Cerrar.Size = new Size(200, 100);
            btn_Cerrar.TabIndex = 6;
            btn_Cerrar.Text = "Cerrar";
            btn_Cerrar.UseVisualStyleBackColor = false;
            btn_Cerrar.Click += btn_Cerrar_Click;
            // 
            // btn_AutocompletarSupervisor
            // 
            btn_AutocompletarSupervisor.BackColor = Color.FromArgb(255, 192, 128);
            btn_AutocompletarSupervisor.ImeMode = ImeMode.NoControl;
            btn_AutocompletarSupervisor.Location = new Point(597, 111);
            btn_AutocompletarSupervisor.Name = "btn_AutocompletarSupervisor";
            btn_AutocompletarSupervisor.Size = new Size(120, 50);
            btn_AutocompletarSupervisor.TabIndex = 2;
            btn_AutocompletarSupervisor.Text = "Autocompletar (supervisor)";
            btn_AutocompletarSupervisor.UseVisualStyleBackColor = false;
            btn_AutocompletarSupervisor.Click += btn_AutocompletarSupervisor_Click;
            // 
            // btn_Ayuda
            // 
            btn_Ayuda.BackColor = Color.White;
            btn_Ayuda.Location = new Point(702, 405);
            btn_Ayuda.Name = "btn_Ayuda";
            btn_Ayuda.Size = new Size(68, 36);
            btn_Ayuda.TabIndex = 5;
            btn_Ayuda.Text = "Ayuda";
            btn_Ayuda.UseVisualStyleBackColor = false;
            btn_Ayuda.Click += btn_Ayuda_Click;
            // 
            // btn_AutocompletarOperario
            // 
            btn_AutocompletarOperario.BackColor = Color.Cyan;
            btn_AutocompletarOperario.ImeMode = ImeMode.NoControl;
            btn_AutocompletarOperario.Location = new Point(597, 187);
            btn_AutocompletarOperario.Name = "btn_AutocompletarOperario";
            btn_AutocompletarOperario.Size = new Size(120, 50);
            btn_AutocompletarOperario.TabIndex = 3;
            btn_AutocompletarOperario.Text = "Autocompletar (operario)";
            btn_AutocompletarOperario.UseVisualStyleBackColor = false;
            btn_AutocompletarOperario.Click += btn_AutocompletarOperario_Click;
            // 
            // FormDeInicio
            // 
            AcceptButton = btn_Iniciar_Sesion;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(150, 60, 60);
            ClientSize = new Size(782, 453);
            Controls.Add(btn_AutocompletarOperario);
            Controls.Add(btn_Ayuda);
            Controls.Add(btn_AutocompletarSupervisor);
            Controls.Add(txt_Nombre);
            Controls.Add(btn_Iniciar_Sesion);
            Controls.Add(txt_Contrasenia);
            Controls.Add(btn_Cerrar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormDeInicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDeInicio";
            FormClosing += FormDeInicio_FormClosing;
            Load += FormDeInicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Nombre;
        private Button btn_Iniciar_Sesion;
        private TextBox txt_Contrasenia;
        private Button btn_Cerrar;
        private Button btn_AutocompletarSupervisor;
        private Button btn_Ayuda;
        private Button btn_AutocompletarOperario;
    }
}