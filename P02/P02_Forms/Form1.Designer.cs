namespace P02_Forms
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
            lblTitle = new Label();
            dgUsuarios = new DataGridView();
            btnNovoUsuario = new Button();
            txtBusca = new TextBox();
            btnBuscar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(256, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(295, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Gestão de Usuarios";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgUsuarios
            // 
            dgUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUsuarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgUsuarios.Location = new Point(12, 152);
            dgUsuarios.MultiSelect = false;
            dgUsuarios.Name = "dgUsuarios";
            dgUsuarios.ReadOnly = true;
            dgUsuarios.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgUsuarios.RowTemplate.Height = 25;
            dgUsuarios.Size = new Size(776, 286);
            dgUsuarios.TabIndex = 1;
            dgUsuarios.CellContentClick += dgUsuarios_CellContentClick;
            // 
            // btnNovoUsuario
            // 
            btnNovoUsuario.Location = new Point(666, 123);
            btnNovoUsuario.Name = "btnNovoUsuario";
            btnNovoUsuario.Size = new Size(122, 23);
            btnNovoUsuario.TabIndex = 2;
            btnNovoUsuario.Text = "Novo usuario";
            btnNovoUsuario.UseVisualStyleBackColor = true;
            btnNovoUsuario.Click += btnNovoUsuario_Click;
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(12, 123);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(253, 23);
            txtBusca.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(271, 123);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(87, 23);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Buscar:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusca);
            Controls.Add(btnNovoUsuario);
            Controls.Add(dgUsuarios);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgUsuarios;
        private Button btnNovoUsuario;
        private TextBox txtBusca;
        private Button btnBuscar;
        private Label label1;
    }
}