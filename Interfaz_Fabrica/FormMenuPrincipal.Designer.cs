using Logica_Fabrica;

namespace Interfaz_Fabrica
{
    partial class FormMenuPrincipal
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
            btn_Ayuda = new Button();
            btn_CerrarSesion = new Button();
            btn_VerAlmacen = new Button();
            btn_VerMaquinas = new Button();
            btn_VerOperarios = new Button();
            SuspendLayout();
            // 
            // btn_Ayuda
            // 
            btn_Ayuda.BackColor = Color.White;
            btn_Ayuda.Location = new Point(920, 502);
            btn_Ayuda.Name = "btn_Ayuda";
            btn_Ayuda.Size = new Size(68, 36);
            btn_Ayuda.TabIndex = 3;
            btn_Ayuda.Text = "Ayuda";
            btn_Ayuda.UseVisualStyleBackColor = false;
            btn_Ayuda.Click += btn_Ayuda_Click;
            // 
            // btn_CerrarSesion
            // 
            btn_CerrarSesion.BackColor = Color.FromArgb(255, 128, 128);
            btn_CerrarSesion.ImeMode = ImeMode.NoControl;
            btn_CerrarSesion.Location = new Point(400, 384);
            btn_CerrarSesion.Name = "btn_CerrarSesion";
            btn_CerrarSesion.Size = new Size(200, 100);
            btn_CerrarSesion.TabIndex = 4;
            btn_CerrarSesion.Text = "Cerrar sesión";
            btn_CerrarSesion.UseVisualStyleBackColor = false;
            btn_CerrarSesion.Click += btn_CerrarSesion_Click;
            // 
            // btn_VerAlmacen
            // 
            btn_VerAlmacen.BackColor = Color.FromArgb(255, 255, 128);
            btn_VerAlmacen.ImeMode = ImeMode.NoControl;
            btn_VerAlmacen.Location = new Point(41, 138);
            btn_VerAlmacen.Name = "btn_VerAlmacen";
            btn_VerAlmacen.Size = new Size(288, 126);
            btn_VerAlmacen.TabIndex = 0;
            btn_VerAlmacen.Text = "Ver almacén";
            btn_VerAlmacen.UseVisualStyleBackColor = false;
            btn_VerAlmacen.Click += btn_VerAlmacen_Click;
            // 
            // btn_VerMaquinas
            // 
            btn_VerMaquinas.BackColor = Color.FromArgb(255, 128, 0);
            btn_VerMaquinas.ImeMode = ImeMode.NoControl;
            btn_VerMaquinas.Location = new Point(356, 138);
            btn_VerMaquinas.Name = "btn_VerMaquinas";
            btn_VerMaquinas.Size = new Size(288, 126);
            btn_VerMaquinas.TabIndex = 1;
            btn_VerMaquinas.Text = "Ver máquinas";
            btn_VerMaquinas.UseVisualStyleBackColor = false;
            btn_VerMaquinas.Click += btn_VerMaquinas_Click;
            // 
            // btn_VerOperarios
            // 
            btn_VerOperarios.BackColor = Color.FromArgb(128, 255, 255);
            btn_VerOperarios.ImeMode = ImeMode.NoControl;
            btn_VerOperarios.Location = new Point(721, 207);
            btn_VerOperarios.Name = "btn_VerOperarios";
            btn_VerOperarios.Size = new Size(225, 126);
            btn_VerOperarios.TabIndex = 2;
            btn_VerOperarios.Text = "Ver operarios";
            btn_VerOperarios.UseVisualStyleBackColor = false;
            btn_VerOperarios.Click += btn_VerOperarios_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1000, 550);
            Controls.Add(btn_VerOperarios);
            Controls.Add(btn_VerMaquinas);
            Controls.Add(btn_VerAlmacen);
            Controls.Add(btn_CerrarSesion);
            Controls.Add(btn_Ayuda);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú principal";
            FormClosing += FormPrincipal_FormClosing;
            Load += FormMenuPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Ayuda;
        private Button btn_CerrarSesion;
        private Button btn_VerAlmacen;
        private Button btn_VerMaquinas;
        private Button btn_VerOperarios;
    }
}