namespace App
{
    partial class PantallaPrincipal
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
            pictureBox1 = new PictureBox();
            btnPedidos = new Button();
            btnVendedores = new Button();
            btnClientes = new Button();
            btnTransportes = new Button();
            lblNombre = new Label();
            lblCorreo = new Label();
            lblPerfil = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.MidnightBlue;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 731);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnPedidos
            // 
            btnPedidos.BackColor = Color.RoyalBlue;
            btnPedidos.FlatAppearance.BorderSize = 0;
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.ForeColor = SystemColors.ButtonHighlight;
            btnPedidos.Location = new Point(33, 50);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(153, 54);
            btnPedidos.TabIndex = 1;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = false;
            // 
            // btnVendedores
            // 
            btnVendedores.BackColor = Color.RoyalBlue;
            btnVendedores.FlatAppearance.BorderSize = 0;
            btnVendedores.FlatStyle = FlatStyle.Flat;
            btnVendedores.ForeColor = SystemColors.ButtonHighlight;
            btnVendedores.Location = new Point(33, 213);
            btnVendedores.Name = "btnVendedores";
            btnVendedores.Size = new Size(153, 54);
            btnVendedores.TabIndex = 2;
            btnVendedores.Text = "Vendedores";
            btnVendedores.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.RoyalBlue;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.ForeColor = SystemColors.ButtonHighlight;
            btnClientes.Location = new Point(33, 386);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(153, 54);
            btnClientes.TabIndex = 3;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            // 
            // btnTransportes
            // 
            btnTransportes.BackColor = Color.RoyalBlue;
            btnTransportes.FlatAppearance.BorderSize = 0;
            btnTransportes.FlatStyle = FlatStyle.Flat;
            btnTransportes.ForeColor = SystemColors.ButtonHighlight;
            btnTransportes.Location = new Point(33, 551);
            btnTransportes.Name = "btnTransportes";
            btnTransportes.Size = new Size(153, 54);
            btnTransportes.TabIndex = 4;
            btnTransportes.Text = "Transportes";
            btnTransportes.UseVisualStyleBackColor = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(302, 9);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(38, 15);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "label1";
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(529, 9);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(38, 15);
            lblCorreo.TabIndex = 6;
            lblCorreo.Text = "label2";
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Location = new Point(815, 9);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(38, 15);
            lblPerfil.TabIndex = 7;
            lblPerfil.Text = "label3";
            lblPerfil.Click += lblPerfil_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 9);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 8;
            label1.Text = "Nombre :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(474, 9);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 9;
            label2.Text = "Correo :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(769, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 10;
            label3.Text = "Perfil :";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.MidnightBlue;
            pictureBox2.Location = new Point(214, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1040, 50);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // PantallaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(1194, 651);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPerfil);
            Controls.Add(lblCorreo);
            Controls.Add(lblNombre);
            Controls.Add(btnTransportes);
            Controls.Add(btnClientes);
            Controls.Add(btnVendedores);
            Controls.Add(btnPedidos);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Name = "PantallaPrincipal";
            Text = "PantallaPrincipal";
            FormClosed += PantallaPrincipal_FormClosed;
            Load += PantallaPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnPedidos;
        private Button btnVendedores;
        private Button btnClientes;
        private Button btnTransportes;
        private Label lblNombre;
        private Label lblCorreo;
        private Label lblPerfil;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
    }
}