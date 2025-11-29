namespace P02_Forms
{
    partial class AddUsuario
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
            lblTitle = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            txtNome = new TextBox();
            label2 = new Label();
            txtSenha = new TextBox();
            label3 = new Label();
            txtConfirmarSenha = new TextBox();
            label4 = new Label();
            rdAtivo = new RadioButton();
            rdInativo = new RadioButton();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.Location = new Point(100, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 45);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Novo usuario";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(310, 370);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(102, 23);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(202, 370);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 91);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 9;
            label1.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNome.Location = new Point(12, 109);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(400, 29);
            txtNome.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 156);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 11;
            label2.Text = "Senha:";
            // 
            // txtSenha
            // 
            txtSenha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSenha.Location = new Point(12, 174);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(400, 29);
            txtSenha.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 217);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 13;
            label3.Text = "Confirmar senha:";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtConfirmarSenha.Location = new Point(12, 235);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.Size = new Size(400, 29);
            txtConfirmarSenha.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 282);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 14;
            label4.Text = "Status:";
            // 
            // rdAtivo
            // 
            rdAtivo.AutoSize = true;
            rdAtivo.Checked = true;
            rdAtivo.Location = new Point(12, 307);
            rdAtivo.Name = "rdAtivo";
            rdAtivo.Size = new Size(53, 19);
            rdAtivo.TabIndex = 15;
            rdAtivo.TabStop = true;
            rdAtivo.Text = "Ativo";
            rdAtivo.UseVisualStyleBackColor = true;
            // 
            // rdInativo
            // 
            rdInativo.AutoSize = true;
            rdInativo.Location = new Point(100, 307);
            rdInativo.Name = "rdInativo";
            rdInativo.Size = new Size(61, 19);
            rdInativo.TabIndex = 16;
            rdInativo.Text = "Inativo";
            rdInativo.UseVisualStyleBackColor = true;
            // 
            // AddUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 407);
            Controls.Add(rdInativo);
            Controls.Add(rdAtivo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(label2);
            Controls.Add(txtSenha);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(lblTitle);
            Name = "AddUsuario";
            Text = "AddUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label label1;
        private TextBox txtNome;
        private Label label2;
        private TextBox txtSenha;
        private Label label3;
        private TextBox txtConfirmarSenha;
        private Label label4;
        private RadioButton rdAtivo;
        private RadioButton rdInativo;
    }
}