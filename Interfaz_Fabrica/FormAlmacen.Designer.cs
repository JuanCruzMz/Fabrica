namespace Interfaz_Fabrica
{
    partial class FormAlmacen
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
            lst_ReservasDeMateriasPrimas = new ListBox();
            lst_InventarioDeProductos = new ListBox();
            lbl_ReservasDeMateriasPrimas = new Label();
            lbl_InventarioDeProductos = new Label();
            btn_EncargarMateriasPrimas = new Button();
            SuspendLayout();
            // 
            // btn_Volver
            // 
            btn_Volver.BackColor = Color.FromArgb(255, 128, 128);
            btn_Volver.ImeMode = ImeMode.NoControl;
            btn_Volver.Location = new Point(300, 603);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(200, 100);
            btn_Volver.TabIndex = 1;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = false;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // btn_Ayuda
            // 
            btn_Ayuda.BackColor = Color.White;
            btn_Ayuda.Location = new Point(720, 702);
            btn_Ayuda.Name = "btn_Ayuda";
            btn_Ayuda.Size = new Size(68, 36);
            btn_Ayuda.TabIndex = 2;
            btn_Ayuda.Text = "Ayuda";
            btn_Ayuda.UseVisualStyleBackColor = false;
            btn_Ayuda.Click += btn_Ayuda_Click;
            // 
            // lst_ReservasDeMateriasPrimas
            // 
            lst_ReservasDeMateriasPrimas.FormattingEnabled = true;
            lst_ReservasDeMateriasPrimas.ItemHeight = 20;
            lst_ReservasDeMateriasPrimas.Location = new Point(12, 56);
            lst_ReservasDeMateriasPrimas.Name = "lst_ReservasDeMateriasPrimas";
            lst_ReservasDeMateriasPrimas.Size = new Size(350, 464);
            lst_ReservasDeMateriasPrimas.TabIndex = 3;
            // 
            // lst_InventarioDeProductos
            // 
            lst_InventarioDeProductos.FormattingEnabled = true;
            lst_InventarioDeProductos.ItemHeight = 20;
            lst_InventarioDeProductos.Location = new Point(438, 56);
            lst_InventarioDeProductos.Name = "lst_InventarioDeProductos";
            lst_InventarioDeProductos.Size = new Size(350, 464);
            lst_InventarioDeProductos.TabIndex = 5;
            // 
            // lbl_ReservasDeMateriasPrimas
            // 
            lbl_ReservasDeMateriasPrimas.AutoSize = true;
            lbl_ReservasDeMateriasPrimas.Location = new Point(89, 21);
            lbl_ReservasDeMateriasPrimas.Name = "lbl_ReservasDeMateriasPrimas";
            lbl_ReservasDeMateriasPrimas.Size = new Size(197, 20);
            lbl_ReservasDeMateriasPrimas.TabIndex = 2;
            lbl_ReservasDeMateriasPrimas.Text = "Reservas de materias primas";
            // 
            // lbl_InventarioDeProductos
            // 
            lbl_InventarioDeProductos.AutoSize = true;
            lbl_InventarioDeProductos.Location = new Point(530, 21);
            lbl_InventarioDeProductos.Name = "lbl_InventarioDeProductos";
            lbl_InventarioDeProductos.Size = new Size(167, 20);
            lbl_InventarioDeProductos.TabIndex = 4;
            lbl_InventarioDeProductos.Text = "Inventario de productos";
            // 
            // btn_EncargarMateriasPrimas
            // 
            btn_EncargarMateriasPrimas.BackColor = Color.FromArgb(255, 224, 192);
            btn_EncargarMateriasPrimas.Location = new Point(33, 541);
            btn_EncargarMateriasPrimas.Name = "btn_EncargarMateriasPrimas";
            btn_EncargarMateriasPrimas.Size = new Size(120, 70);
            btn_EncargarMateriasPrimas.TabIndex = 0;
            btn_EncargarMateriasPrimas.Text = "Encargar materias primas";
            btn_EncargarMateriasPrimas.UseVisualStyleBackColor = false;
            btn_EncargarMateriasPrimas.Click += btn_EncargarMateriasPrimas_Click;
            // 
            // FormAlmacen
            // 
            AcceptButton = btn_Volver;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(800, 750);
            Controls.Add(btn_EncargarMateriasPrimas);
            Controls.Add(lbl_InventarioDeProductos);
            Controls.Add(lbl_ReservasDeMateriasPrimas);
            Controls.Add(lst_InventarioDeProductos);
            Controls.Add(lst_ReservasDeMateriasPrimas);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Ayuda);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAlmacen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAlmacen";
            Load += FormAlmacen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Volver;
        private Button btn_Ayuda;
        private ListBox lst_ReservasDeMateriasPrimas;
        private ListBox lst_InventarioDeProductos;
        private Label lbl_ReservasDeMateriasPrimas;
        private Label lbl_InventarioDeProductos;
        private Button btn_EncargarMateriasPrimas;
    }
}