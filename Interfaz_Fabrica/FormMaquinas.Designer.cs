namespace Interfaz_Fabrica
{
    partial class FormMaquinas
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
            btn_DetenerMaquina1 = new Button();
            lbl_InfoMaquinas = new Label();
            lbl_Maquina1 = new Label();
            cmb_CambiarProducciónMaquina1 = new ComboBox();
            lbl_ProduccionMaquina1 = new Label();
            lbl_CambiarProduccionMaquina1 = new Label();
            btn_ReanudarMaquina1 = new Button();
            lbl_CambiarProduccionMaquina2 = new Label();
            lbl_ProduccionMaquina2 = new Label();
            cmb_CambiarProducciónMaquina2 = new ComboBox();
            lbl_Maquina2 = new Label();
            btn_ReanudarMaquina2 = new Button();
            btn_DetenerMaquina2 = new Button();
            lbl_CambiarProduccionMaquina4 = new Label();
            lbl_ProduccionMaquina4 = new Label();
            cmb_CambiarProducciónMaquina4 = new ComboBox();
            lbl_Maquina4 = new Label();
            btn_ReanudarMaquina4 = new Button();
            btn_DetenerMaquina4 = new Button();
            lbl_CambiarProduccionMaquina3 = new Label();
            lbl_ProduccionMaquina3 = new Label();
            cmb_CambiarProducciónMaquina3 = new ComboBox();
            lbl_Maquina3 = new Label();
            btn_ReanudarMaquina3 = new Button();
            btn_DetenerMaquina3 = new Button();
            lbl_CambiarProduccionMaquina5 = new Label();
            lbl_ProduccionMaquina5 = new Label();
            cmb_CambiarProducciónMaquina5 = new ComboBox();
            lbl_Maquina5 = new Label();
            btn_ReanudarMaquina5 = new Button();
            btn_DetenerMaquina5 = new Button();
            lbl_SeleccionUnProductoMaquina1 = new Label();
            lbl_SeleccionUnProductoMaquina2 = new Label();
            lbl_SeleccionUnProductoMaquina3 = new Label();
            lbl_SeleccionUnProductoMaquina4 = new Label();
            lbl_SeleccionUnProductoMaquina5 = new Label();
            SuspendLayout();
            // 
            // btn_Volver
            // 
            btn_Volver.BackColor = Color.FromArgb(255, 128, 128);
            btn_Volver.ImeMode = ImeMode.NoControl;
            btn_Volver.Location = new Point(500, 603);
            btn_Volver.Name = "btn_Volver";
            btn_Volver.Size = new Size(200, 100);
            btn_Volver.TabIndex = 16;
            btn_Volver.Text = "Volver";
            btn_Volver.UseVisualStyleBackColor = false;
            btn_Volver.Click += btn_Volver_Click;
            // 
            // btn_Ayuda
            // 
            btn_Ayuda.BackColor = Color.White;
            btn_Ayuda.Location = new Point(1120, 702);
            btn_Ayuda.Name = "btn_Ayuda";
            btn_Ayuda.Size = new Size(68, 36);
            btn_Ayuda.TabIndex = 17;
            btn_Ayuda.Text = "Ayuda";
            btn_Ayuda.UseVisualStyleBackColor = false;
            btn_Ayuda.Click += btn_Ayuda_Click;
            // 
            // btn_DetenerMaquina1
            // 
            btn_DetenerMaquina1.BackColor = Color.Red;
            btn_DetenerMaquina1.Location = new Point(53, 88);
            btn_DetenerMaquina1.Name = "btn_DetenerMaquina1";
            btn_DetenerMaquina1.Size = new Size(30, 30);
            btn_DetenerMaquina1.TabIndex = 1;
            btn_DetenerMaquina1.UseVisualStyleBackColor = false;
            btn_DetenerMaquina1.Click += btn_DetenerMaquina1_Click;
            // 
            // lbl_InfoMaquinas
            // 
            lbl_InfoMaquinas.AutoSize = true;
            lbl_InfoMaquinas.Location = new Point(82, 9);
            lbl_InfoMaquinas.Name = "lbl_InfoMaquinas";
            lbl_InfoMaquinas.Size = new Size(73, 20);
            lbl_InfoMaquinas.TabIndex = 18;
            lbl_InfoMaquinas.Text = "Máquinas";
            // 
            // lbl_Maquina1
            // 
            lbl_Maquina1.AutoSize = true;
            lbl_Maquina1.Location = new Point(12, 50);
            lbl_Maquina1.Name = "lbl_Maquina1";
            lbl_Maquina1.Size = new Size(82, 20);
            lbl_Maquina1.TabIndex = 19;
            lbl_Maquina1.Text = "Máquina 1:";
            // 
            // cmb_CambiarProducciónMaquina1
            // 
            cmb_CambiarProducciónMaquina1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CambiarProducciónMaquina1.FormattingEnabled = true;
            cmb_CambiarProducciónMaquina1.Location = new Point(132, 118);
            cmb_CambiarProducciónMaquina1.Name = "cmb_CambiarProducciónMaquina1";
            cmb_CambiarProducciónMaquina1.Size = new Size(151, 28);
            cmb_CambiarProducciónMaquina1.TabIndex = 2;
            cmb_CambiarProducciónMaquina1.SelectedIndexChanged += cmb_CambiarProducciónMaquina1_SelectedIndexChanged;
            // 
            // lbl_ProduccionMaquina1
            // 
            lbl_ProduccionMaquina1.AutoSize = true;
            lbl_ProduccionMaquina1.Location = new Point(100, 50);
            lbl_ProduccionMaquina1.Name = "lbl_ProduccionMaquina1";
            lbl_ProduccionMaquina1.Size = new Size(102, 20);
            lbl_ProduccionMaquina1.TabIndex = 20;
            lbl_ProduccionMaquina1.Text = "Produciendo...";
            // 
            // lbl_CambiarProduccionMaquina1
            // 
            lbl_CambiarProduccionMaquina1.AutoSize = true;
            lbl_CambiarProduccionMaquina1.Location = new Point(99, 85);
            lbl_CambiarProduccionMaquina1.Name = "lbl_CambiarProduccionMaquina1";
            lbl_CambiarProduccionMaquina1.Size = new Size(217, 20);
            lbl_CambiarProduccionMaquina1.TabIndex = 21;
            lbl_CambiarProduccionMaquina1.Text = "Cambiar cadena de producción";
            // 
            // btn_ReanudarMaquina1
            // 
            btn_ReanudarMaquina1.BackColor = Color.Lime;
            btn_ReanudarMaquina1.Location = new Point(17, 88);
            btn_ReanudarMaquina1.Name = "btn_ReanudarMaquina1";
            btn_ReanudarMaquina1.Size = new Size(30, 30);
            btn_ReanudarMaquina1.TabIndex = 0;
            btn_ReanudarMaquina1.UseVisualStyleBackColor = false;
            btn_ReanudarMaquina1.Click += btn_ReanudarMaquina1_Click;
            // 
            // lbl_CambiarProduccionMaquina2
            // 
            lbl_CambiarProduccionMaquina2.AutoSize = true;
            lbl_CambiarProduccionMaquina2.Location = new Point(99, 208);
            lbl_CambiarProduccionMaquina2.Name = "lbl_CambiarProduccionMaquina2";
            lbl_CambiarProduccionMaquina2.Size = new Size(217, 20);
            lbl_CambiarProduccionMaquina2.TabIndex = 25;
            lbl_CambiarProduccionMaquina2.Text = "Cambiar cadena de producción";
            // 
            // lbl_ProduccionMaquina2
            // 
            lbl_ProduccionMaquina2.AutoSize = true;
            lbl_ProduccionMaquina2.Location = new Point(100, 173);
            lbl_ProduccionMaquina2.Name = "lbl_ProduccionMaquina2";
            lbl_ProduccionMaquina2.Size = new Size(102, 20);
            lbl_ProduccionMaquina2.TabIndex = 24;
            lbl_ProduccionMaquina2.Text = "Produciendo...";
            // 
            // cmb_CambiarProducciónMaquina2
            // 
            cmb_CambiarProducciónMaquina2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CambiarProducciónMaquina2.FormattingEnabled = true;
            cmb_CambiarProducciónMaquina2.Location = new Point(132, 241);
            cmb_CambiarProducciónMaquina2.Name = "cmb_CambiarProducciónMaquina2";
            cmb_CambiarProducciónMaquina2.Size = new Size(151, 28);
            cmb_CambiarProducciónMaquina2.TabIndex = 5;
            cmb_CambiarProducciónMaquina2.SelectedIndexChanged += cmb_CambiarProducciónMaquina2_SelectedIndexChanged;
            // 
            // lbl_Maquina2
            // 
            lbl_Maquina2.AutoSize = true;
            lbl_Maquina2.Location = new Point(12, 173);
            lbl_Maquina2.Name = "lbl_Maquina2";
            lbl_Maquina2.Size = new Size(82, 20);
            lbl_Maquina2.TabIndex = 23;
            lbl_Maquina2.Text = "Máquina 2:";
            // 
            // btn_ReanudarMaquina2
            // 
            btn_ReanudarMaquina2.BackColor = Color.Lime;
            btn_ReanudarMaquina2.Location = new Point(17, 211);
            btn_ReanudarMaquina2.Name = "btn_ReanudarMaquina2";
            btn_ReanudarMaquina2.Size = new Size(30, 30);
            btn_ReanudarMaquina2.TabIndex = 3;
            btn_ReanudarMaquina2.UseVisualStyleBackColor = false;
            btn_ReanudarMaquina2.Click += btn_ReanudarMaquina2_Click;
            // 
            // btn_DetenerMaquina2
            // 
            btn_DetenerMaquina2.BackColor = Color.Red;
            btn_DetenerMaquina2.Location = new Point(53, 211);
            btn_DetenerMaquina2.Name = "btn_DetenerMaquina2";
            btn_DetenerMaquina2.Size = new Size(30, 30);
            btn_DetenerMaquina2.TabIndex = 4;
            btn_DetenerMaquina2.UseVisualStyleBackColor = false;
            btn_DetenerMaquina2.Click += btn_DetenerMaquina2_Click;
            // 
            // lbl_CambiarProduccionMaquina4
            // 
            lbl_CambiarProduccionMaquina4.AutoSize = true;
            lbl_CambiarProduccionMaquina4.Location = new Point(99, 465);
            lbl_CambiarProduccionMaquina4.Name = "lbl_CambiarProduccionMaquina4";
            lbl_CambiarProduccionMaquina4.Size = new Size(217, 20);
            lbl_CambiarProduccionMaquina4.TabIndex = 33;
            lbl_CambiarProduccionMaquina4.Text = "Cambiar cadena de producción";
            // 
            // lbl_ProduccionMaquina4
            // 
            lbl_ProduccionMaquina4.AutoSize = true;
            lbl_ProduccionMaquina4.Location = new Point(100, 430);
            lbl_ProduccionMaquina4.Name = "lbl_ProduccionMaquina4";
            lbl_ProduccionMaquina4.Size = new Size(102, 20);
            lbl_ProduccionMaquina4.TabIndex = 32;
            lbl_ProduccionMaquina4.Text = "Produciendo...";
            // 
            // cmb_CambiarProducciónMaquina4
            // 
            cmb_CambiarProducciónMaquina4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CambiarProducciónMaquina4.FormattingEnabled = true;
            cmb_CambiarProducciónMaquina4.Location = new Point(132, 498);
            cmb_CambiarProducciónMaquina4.Name = "cmb_CambiarProducciónMaquina4";
            cmb_CambiarProducciónMaquina4.Size = new Size(151, 28);
            cmb_CambiarProducciónMaquina4.TabIndex = 11;
            cmb_CambiarProducciónMaquina4.SelectedIndexChanged += cmb_CambiarProducciónMaquina4_SelectedIndexChanged;
            // 
            // lbl_Maquina4
            // 
            lbl_Maquina4.AutoSize = true;
            lbl_Maquina4.Location = new Point(12, 430);
            lbl_Maquina4.Name = "lbl_Maquina4";
            lbl_Maquina4.Size = new Size(82, 20);
            lbl_Maquina4.TabIndex = 31;
            lbl_Maquina4.Text = "Máquina 4:";
            // 
            // btn_ReanudarMaquina4
            // 
            btn_ReanudarMaquina4.BackColor = Color.Lime;
            btn_ReanudarMaquina4.Location = new Point(17, 468);
            btn_ReanudarMaquina4.Name = "btn_ReanudarMaquina4";
            btn_ReanudarMaquina4.Size = new Size(30, 30);
            btn_ReanudarMaquina4.TabIndex = 9;
            btn_ReanudarMaquina4.UseVisualStyleBackColor = false;
            btn_ReanudarMaquina4.Click += btn_ReanudarMaquina4_Click;
            // 
            // btn_DetenerMaquina4
            // 
            btn_DetenerMaquina4.BackColor = Color.Red;
            btn_DetenerMaquina4.Location = new Point(53, 468);
            btn_DetenerMaquina4.Name = "btn_DetenerMaquina4";
            btn_DetenerMaquina4.Size = new Size(30, 30);
            btn_DetenerMaquina4.TabIndex = 10;
            btn_DetenerMaquina4.UseVisualStyleBackColor = false;
            btn_DetenerMaquina4.Click += btn_DetenerMaquina4_Click;
            // 
            // lbl_CambiarProduccionMaquina3
            // 
            lbl_CambiarProduccionMaquina3.AutoSize = true;
            lbl_CambiarProduccionMaquina3.Location = new Point(99, 334);
            lbl_CambiarProduccionMaquina3.Name = "lbl_CambiarProduccionMaquina3";
            lbl_CambiarProduccionMaquina3.Size = new Size(217, 20);
            lbl_CambiarProduccionMaquina3.TabIndex = 29;
            lbl_CambiarProduccionMaquina3.Text = "Cambiar cadena de producción";
            // 
            // lbl_ProduccionMaquina3
            // 
            lbl_ProduccionMaquina3.AutoSize = true;
            lbl_ProduccionMaquina3.Location = new Point(100, 299);
            lbl_ProduccionMaquina3.Name = "lbl_ProduccionMaquina3";
            lbl_ProduccionMaquina3.Size = new Size(102, 20);
            lbl_ProduccionMaquina3.TabIndex = 28;
            lbl_ProduccionMaquina3.Text = "Produciendo...";
            // 
            // cmb_CambiarProducciónMaquina3
            // 
            cmb_CambiarProducciónMaquina3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CambiarProducciónMaquina3.FormattingEnabled = true;
            cmb_CambiarProducciónMaquina3.Location = new Point(132, 367);
            cmb_CambiarProducciónMaquina3.Name = "cmb_CambiarProducciónMaquina3";
            cmb_CambiarProducciónMaquina3.Size = new Size(151, 28);
            cmb_CambiarProducciónMaquina3.TabIndex = 8;
            cmb_CambiarProducciónMaquina3.SelectedIndexChanged += cmb_CambiarProducciónMaquina3_SelectedIndexChanged;
            // 
            // lbl_Maquina3
            // 
            lbl_Maquina3.AutoSize = true;
            lbl_Maquina3.Location = new Point(12, 299);
            lbl_Maquina3.Name = "lbl_Maquina3";
            lbl_Maquina3.Size = new Size(82, 20);
            lbl_Maquina3.TabIndex = 27;
            lbl_Maquina3.Text = "Máquina 3:";
            // 
            // btn_ReanudarMaquina3
            // 
            btn_ReanudarMaquina3.BackColor = Color.Lime;
            btn_ReanudarMaquina3.Location = new Point(17, 337);
            btn_ReanudarMaquina3.Name = "btn_ReanudarMaquina3";
            btn_ReanudarMaquina3.Size = new Size(30, 30);
            btn_ReanudarMaquina3.TabIndex = 6;
            btn_ReanudarMaquina3.UseVisualStyleBackColor = false;
            btn_ReanudarMaquina3.Click += btn_ReanudarMaquina3_Click;
            // 
            // btn_DetenerMaquina3
            // 
            btn_DetenerMaquina3.BackColor = Color.Red;
            btn_DetenerMaquina3.Location = new Point(53, 337);
            btn_DetenerMaquina3.Name = "btn_DetenerMaquina3";
            btn_DetenerMaquina3.Size = new Size(30, 30);
            btn_DetenerMaquina3.TabIndex = 7;
            btn_DetenerMaquina3.UseVisualStyleBackColor = false;
            btn_DetenerMaquina3.Click += btn_DetenerMaquina3_Click;
            // 
            // lbl_CambiarProduccionMaquina5
            // 
            lbl_CambiarProduccionMaquina5.AutoSize = true;
            lbl_CambiarProduccionMaquina5.Location = new Point(99, 596);
            lbl_CambiarProduccionMaquina5.Name = "lbl_CambiarProduccionMaquina5";
            lbl_CambiarProduccionMaquina5.Size = new Size(217, 20);
            lbl_CambiarProduccionMaquina5.TabIndex = 37;
            lbl_CambiarProduccionMaquina5.Text = "Cambiar cadena de producción";
            // 
            // lbl_ProduccionMaquina5
            // 
            lbl_ProduccionMaquina5.AutoSize = true;
            lbl_ProduccionMaquina5.Location = new Point(100, 561);
            lbl_ProduccionMaquina5.Name = "lbl_ProduccionMaquina5";
            lbl_ProduccionMaquina5.Size = new Size(102, 20);
            lbl_ProduccionMaquina5.TabIndex = 36;
            lbl_ProduccionMaquina5.Text = "Produciendo...";
            // 
            // cmb_CambiarProducciónMaquina5
            // 
            cmb_CambiarProducciónMaquina5.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CambiarProducciónMaquina5.FormattingEnabled = true;
            cmb_CambiarProducciónMaquina5.Location = new Point(132, 629);
            cmb_CambiarProducciónMaquina5.Name = "cmb_CambiarProducciónMaquina5";
            cmb_CambiarProducciónMaquina5.Size = new Size(151, 28);
            cmb_CambiarProducciónMaquina5.TabIndex = 14;
            cmb_CambiarProducciónMaquina5.SelectedIndexChanged += cmb_CambiarProducciónMaquina5_SelectedIndexChanged;
            // 
            // lbl_Maquina5
            // 
            lbl_Maquina5.AutoSize = true;
            lbl_Maquina5.Location = new Point(12, 561);
            lbl_Maquina5.Name = "lbl_Maquina5";
            lbl_Maquina5.Size = new Size(82, 20);
            lbl_Maquina5.TabIndex = 35;
            lbl_Maquina5.Text = "Máquina 5:";
            // 
            // btn_ReanudarMaquina5
            // 
            btn_ReanudarMaquina5.BackColor = Color.Lime;
            btn_ReanudarMaquina5.Location = new Point(17, 599);
            btn_ReanudarMaquina5.Name = "btn_ReanudarMaquina5";
            btn_ReanudarMaquina5.Size = new Size(30, 30);
            btn_ReanudarMaquina5.TabIndex = 12;
            btn_ReanudarMaquina5.UseVisualStyleBackColor = false;
            btn_ReanudarMaquina5.Click += btn_ReanudarMaquina5_Click;
            // 
            // btn_DetenerMaquina5
            // 
            btn_DetenerMaquina5.BackColor = Color.Red;
            btn_DetenerMaquina5.Location = new Point(53, 599);
            btn_DetenerMaquina5.Name = "btn_DetenerMaquina5";
            btn_DetenerMaquina5.Size = new Size(30, 30);
            btn_DetenerMaquina5.TabIndex = 13;
            btn_DetenerMaquina5.UseVisualStyleBackColor = false;
            btn_DetenerMaquina5.Click += btn_DetenerMaquina5_Click;
            // 
            // lbl_SeleccionUnProductoMaquina1
            // 
            lbl_SeleccionUnProductoMaquina1.AutoSize = true;
            lbl_SeleccionUnProductoMaquina1.Location = new Point(289, 121);
            lbl_SeleccionUnProductoMaquina1.Name = "lbl_SeleccionUnProductoMaquina1";
            lbl_SeleccionUnProductoMaquina1.Size = new Size(191, 20);
            lbl_SeleccionUnProductoMaquina1.TabIndex = 22;
            lbl_SeleccionUnProductoMaquina1.Text = "<-- Seleccione un producto";
            // 
            // lbl_SeleccionUnProductoMaquina2
            // 
            lbl_SeleccionUnProductoMaquina2.AutoSize = true;
            lbl_SeleccionUnProductoMaquina2.Location = new Point(289, 244);
            lbl_SeleccionUnProductoMaquina2.Name = "lbl_SeleccionUnProductoMaquina2";
            lbl_SeleccionUnProductoMaquina2.Size = new Size(191, 20);
            lbl_SeleccionUnProductoMaquina2.TabIndex = 26;
            lbl_SeleccionUnProductoMaquina2.Text = "<-- Seleccione un producto";
            // 
            // lbl_SeleccionUnProductoMaquina3
            // 
            lbl_SeleccionUnProductoMaquina3.AutoSize = true;
            lbl_SeleccionUnProductoMaquina3.Location = new Point(289, 370);
            lbl_SeleccionUnProductoMaquina3.Name = "lbl_SeleccionUnProductoMaquina3";
            lbl_SeleccionUnProductoMaquina3.Size = new Size(191, 20);
            lbl_SeleccionUnProductoMaquina3.TabIndex = 30;
            lbl_SeleccionUnProductoMaquina3.Text = "<-- Seleccione un producto";
            // 
            // lbl_SeleccionUnProductoMaquina4
            // 
            lbl_SeleccionUnProductoMaquina4.AutoSize = true;
            lbl_SeleccionUnProductoMaquina4.Location = new Point(289, 501);
            lbl_SeleccionUnProductoMaquina4.Name = "lbl_SeleccionUnProductoMaquina4";
            lbl_SeleccionUnProductoMaquina4.Size = new Size(191, 20);
            lbl_SeleccionUnProductoMaquina4.TabIndex = 34;
            lbl_SeleccionUnProductoMaquina4.Text = "<-- Seleccione un producto";
            // 
            // lbl_SeleccionUnProductoMaquina5
            // 
            lbl_SeleccionUnProductoMaquina5.AutoSize = true;
            lbl_SeleccionUnProductoMaquina5.Location = new Point(289, 632);
            lbl_SeleccionUnProductoMaquina5.Name = "lbl_SeleccionUnProductoMaquina5";
            lbl_SeleccionUnProductoMaquina5.Size = new Size(191, 20);
            lbl_SeleccionUnProductoMaquina5.TabIndex = 38;
            lbl_SeleccionUnProductoMaquina5.Text = "<-- Seleccione un producto";
            // 
            // FormMaquinas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            ClientSize = new Size(1200, 750);
            Controls.Add(lbl_SeleccionUnProductoMaquina5);
            Controls.Add(lbl_SeleccionUnProductoMaquina4);
            Controls.Add(lbl_SeleccionUnProductoMaquina3);
            Controls.Add(lbl_SeleccionUnProductoMaquina2);
            Controls.Add(lbl_SeleccionUnProductoMaquina1);
            Controls.Add(lbl_CambiarProduccionMaquina5);
            Controls.Add(lbl_ProduccionMaquina5);
            Controls.Add(cmb_CambiarProducciónMaquina5);
            Controls.Add(lbl_Maquina5);
            Controls.Add(btn_ReanudarMaquina5);
            Controls.Add(btn_DetenerMaquina5);
            Controls.Add(lbl_CambiarProduccionMaquina4);
            Controls.Add(lbl_ProduccionMaquina4);
            Controls.Add(cmb_CambiarProducciónMaquina4);
            Controls.Add(lbl_Maquina4);
            Controls.Add(btn_ReanudarMaquina4);
            Controls.Add(btn_DetenerMaquina4);
            Controls.Add(lbl_CambiarProduccionMaquina3);
            Controls.Add(lbl_ProduccionMaquina3);
            Controls.Add(cmb_CambiarProducciónMaquina3);
            Controls.Add(lbl_Maquina3);
            Controls.Add(btn_ReanudarMaquina3);
            Controls.Add(btn_DetenerMaquina3);
            Controls.Add(lbl_CambiarProduccionMaquina2);
            Controls.Add(lbl_ProduccionMaquina2);
            Controls.Add(cmb_CambiarProducciónMaquina2);
            Controls.Add(lbl_Maquina2);
            Controls.Add(btn_ReanudarMaquina2);
            Controls.Add(btn_DetenerMaquina2);
            Controls.Add(lbl_CambiarProduccionMaquina1);
            Controls.Add(lbl_ProduccionMaquina1);
            Controls.Add(cmb_CambiarProducciónMaquina1);
            Controls.Add(lbl_Maquina1);
            Controls.Add(lbl_InfoMaquinas);
            Controls.Add(btn_ReanudarMaquina1);
            Controls.Add(btn_DetenerMaquina1);
            Controls.Add(btn_Volver);
            Controls.Add(btn_Ayuda);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMaquinas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMaquinas";
            Load += FormMaquinas_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Volver;
        private Button btn_Ayuda;
        private Button btn_DetenerMaquina1;
        private Label lbl_InfoMaquinas;
        private Label lbl_Maquina1;
        private ComboBox cmb_CambiarProducciónMaquina1;
        private Label lbl_ProduccionMaquina1;
        private Label lbl_CambiarProduccionMaquina1;
        private Button btn_ReanudarMaquina1;
        private Label lbl_CambiarProduccionMaquina2;
        private Label lbl_ProduccionMaquina2;
        private ComboBox cmb_CambiarProducciónMaquina2;
        private Label lbl_Maquina2;
        private Button btn_ReanudarMaquina2;
        private Button btn_DetenerMaquina2;
        private Label lbl_CambiarProduccionMaquina4;
        private Label lbl_ProduccionMaquina4;
        private ComboBox cmb_CambiarProducciónMaquina4;
        private Label lbl_Maquina4;
        private Button btn_ReanudarMaquina4;
        private Button btn_DetenerMaquina4;
        private Label lbl_CambiarProduccionMaquina3;
        private Label lbl_ProduccionMaquina3;
        private ComboBox cmb_CambiarProducciónMaquina3;
        private Label lbl_Maquina3;
        private Button btn_ReanudarMaquina3;
        private Button btn_DetenerMaquina3;
        private Label lbl_CambiarProduccionMaquina5;
        private Label lbl_ProduccionMaquina5;
        private ComboBox cmb_CambiarProducciónMaquina5;
        private Label lbl_Maquina5;
        private Button btn_ReanudarMaquina5;
        private Button btn_DetenerMaquina5;
        private Label lbl_SeleccionUnProductoMaquina1;
        private Label lbl_SeleccionUnProductoMaquina2;
        private Label lbl_SeleccionUnProductoMaquina3;
        private Label lbl_SeleccionUnProductoMaquina4;
        private Label lbl_SeleccionUnProductoMaquina5;
    }
}