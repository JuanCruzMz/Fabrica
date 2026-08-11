namespace Interfaz_Fabrica
{
    partial class FormEncargarMateriasPrimas
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
            btn_Volver = new Button();
            btn_Ayuda = new Button();
            cmb_TipoDeMateriaPrima = new ComboBox();
            txt_CantidadDeMateriaPrima = new TextBox();
            lbl_TipoDeMateriaPrima = new Label();
            lbl_CantidadDeMateriaPrima = new Label();
            btn_ConfirmarEncargo = new Button();
            SuspendLayout();
            // 
            // btn_Volver
            // 
            btn_Volver.BackColor = Color.FromArgb(255, 128, 128);
            btn_Volver.ImeMode = ImeMode.NoControl;
            btn_Volver.Location = new Point(191, 258);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(200, 100);
            btn_Volver.TabIndex = 5;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = false;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // btn_Ayuda
            // 
            btn_Ayuda.BackColor = Color.White;
            btn_Ayuda.Location = new Point(502, 355);
            btn_Ayuda.Name = "btn_Ayuda";
            btn_Ayuda.Size = new Size(68, 36);
            btn_Ayuda.TabIndex = 4;
            btn_Ayuda.Text = "Ayuda";
            btn_Ayuda.UseVisualStyleBackColor = false;
            btn_Ayuda.Click += btn_Ayuda_Click;
            // 
            // cmb_TipoDeMateriaPrima
            // 
            cmb_TipoDeMateriaPrima.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_TipoDeMateriaPrima.FormattingEnabled = true;
            cmb_TipoDeMateriaPrima.Location = new Point(323, 86);
            cmb_TipoDeMateriaPrima.Name = "cmb_TipoDeMateriaPrima";
            cmb_TipoDeMateriaPrima.Size = new Size(133, 28);
            cmb_TipoDeMateriaPrima.TabIndex = 0;
            // 
            // txt_CantidadDeMateriaPrima
            // 
            txt_CantidadDeMateriaPrima.Location = new Point(323, 141);
            txt_CantidadDeMateriaPrima.Name = "txt_CantidadDeMateriaPrima";
            txt_CantidadDeMateriaPrima.Size = new Size(48, 27);
            txt_CantidadDeMateriaPrima.TabIndex = 2;
            txt_CantidadDeMateriaPrima.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_TipoDeMateriaPrima
            // 
            lbl_TipoDeMateriaPrima.AutoSize = true;
            lbl_TipoDeMateriaPrima.Location = new Point(126, 89);
            lbl_TipoDeMateriaPrima.Name = "lbl_TipoDeMateriaPrima";
            lbl_TipoDeMateriaPrima.Size = new Size(161, 20);
            lbl_TipoDeMateriaPrima.TabIndex = 6;
            lbl_TipoDeMateriaPrima.Text = "Tipo de materia prima:";
            // 
            // lbl_CantidadDeMateriaPrima
            // 
            lbl_CantidadDeMateriaPrima.AutoSize = true;
            lbl_CantidadDeMateriaPrima.Location = new Point(126, 141);
            lbl_CantidadDeMateriaPrima.Name = "lbl_CantidadDeMateriaPrima";
            lbl_CantidadDeMateriaPrima.Size = new Size(191, 20);
            lbl_CantidadDeMateriaPrima.TabIndex = 7;
            lbl_CantidadDeMateriaPrima.Text = "Cantidad de materia prima:";
            // 
            // btn_ConfirmarEncargo
            // 
            btn_ConfirmarEncargo.BackColor = Color.FromArgb(128, 255, 128);
            btn_ConfirmarEncargo.ImeMode = ImeMode.NoControl;
            btn_ConfirmarEncargo.Location = new Point(441, 157);
            btn_ConfirmarEncargo.Name = "btn_ConfirmarEncargo";
            btn_ConfirmarEncargo.Size = new Size(100, 50);
            btn_ConfirmarEncargo.TabIndex = 3;
            btn_ConfirmarEncargo.Text = "Confirmar encargo";
            btn_ConfirmarEncargo.UseVisualStyleBackColor = false;
            btn_ConfirmarEncargo.Click += btn_ConfirmarEncargo_Click;
            // 
            // FormEncargarMateriasPrimas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(582, 403);
            Controls.Add(btn_ConfirmarEncargo);
            Controls.Add(lbl_CantidadDeMateriaPrima);
            Controls.Add(lbl_TipoDeMateriaPrima);
            Controls.Add(txt_CantidadDeMateriaPrima);
            Controls.Add(cmb_TipoDeMateriaPrima);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Ayuda);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormEncargarMateriasPrimas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú de encargo de materias primas";
            Load += FormEncargarMateriasPrimas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Volver;
        private Button btn_Ayuda;
        private ComboBox cmb_TipoDeMateriaPrima;
        private TextBox txt_CantidadDeMateriaPrima;
        private Label lbl_TipoDeMateriaPrima;
        private Label lbl_CantidadDeMateriaPrima;
        private Button btn_ConfirmarEncargo;
    }
}