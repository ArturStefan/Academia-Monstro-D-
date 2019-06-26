namespace Login
{
    partial class RecuperarSenha
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
            this.components = new System.ComponentModel.Container();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIdade = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskCep = new System.Windows.Forms.MaskedTextBox();
            this.maskNascimento = new System.Windows.Forms.MaskedTextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSalvarAlteracao = new System.Windows.Forms.Button();
            this.maskValorCpf = new System.Windows.Forms.MaskedTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.maskDataAtual = new System.Windows.Forms.MaskedTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(327, 314);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 21);
            this.label14.TabIndex = 66;
            this.label14.Text = "Idade";
            // 
            // txtIdade
            // 
            this.txtIdade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdade.Enabled = false;
            this.txtIdade.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdade.Location = new System.Drawing.Point(328, 345);
            this.txtIdade.Name = "txtIdade";
            this.txtIdade.Size = new System.Drawing.Size(50, 22);
            this.txtIdade.TabIndex = 65;
            this.txtIdade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdade.Enter += new System.EventHandler(this.textBox8_Enter);
            this.txtIdade.Leave += new System.EventHandler(this.textBox8_Leave);
            // 
            // txtEstado
            // 
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(825, 195);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(50, 22);
            this.txtEstado.TabIndex = 51;
            this.txtEstado.Text = "UF";
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.Enter += new System.EventHandler(this.textBox7_Enter);
            this.txtEstado.Leave += new System.EventHandler(this.textBox7_Leave);
            // 
            // txtCidade
            // 
            this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCidade.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCidade.Location = new System.Drawing.Point(506, 195);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(300, 22);
            this.txtCidade.TabIndex = 49;
            this.txtCidade.Text = "Cidade";
            this.txtCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCidade.Enter += new System.EventHandler(this.textBox6_Enter);
            this.txtCidade.Leave += new System.EventHandler(this.textBox6_Leave);
            // 
            // txtBairro
            // 
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBairro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBairro.Location = new System.Drawing.Point(506, 253);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(300, 22);
            this.txtBairro.TabIndex = 48;
            this.txtBairro.Text = "Bairro";
            this.txtBairro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBairro.Enter += new System.EventHandler(this.textBox5_Enter);
            this.txtBairro.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(825, 138);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(50, 22);
            this.txtNumero.TabIndex = 47;
            this.txtNumero.Text = "N°";
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumero.Enter += new System.EventHandler(this.textBox4_Enter);
            this.txtNumero.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // txtRua
            // 
            this.txtRua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRua.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRua.Location = new System.Drawing.Point(506, 138);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(300, 22);
            this.txtRua.TabIndex = 45;
            this.txtRua.Text = "Endereço";
            this.txtRua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRua.Enter += new System.EventHandler(this.textBox3_Enter);
            this.txtRua.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(86, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 21);
            this.label8.TabIndex = 59;
            this.label8.Text = "CPF :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(270, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 21);
            this.label7.TabIndex = 58;
            this.label7.Text = "CEP :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(104, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 21);
            this.label6.TabIndex = 57;
            this.label6.Text = "Data de Nascimento";
            // 
            // maskCep
            // 
            this.maskCep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskCep.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskCep.Location = new System.Drawing.Point(318, 419);
            this.maskCep.Mask = "00000-000";
            this.maskCep.Name = "maskCep";
            this.maskCep.Size = new System.Drawing.Size(80, 22);
            this.maskCep.TabIndex = 43;
            this.maskCep.Enter += new System.EventHandler(this.maskedTextBox2_Enter);
            this.maskCep.Leave += new System.EventHandler(this.maskedTextBox2_Leave);
            // 
            // maskNascimento
            // 
            this.maskNascimento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskNascimento.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskNascimento.Location = new System.Drawing.Point(137, 352);
            this.maskNascimento.Mask = "00/00/0000";
            this.maskNascimento.Name = "maskNascimento";
            this.maskNascimento.Size = new System.Drawing.Size(90, 22);
            this.maskNascimento.TabIndex = 42;
            this.maskNascimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskNascimento.ValidatingType = typeof(System.DateTime);
            this.maskNascimento.Enter += new System.EventHandler(this.maskedTextBox1_Enter);
            this.maskNascimento.Leave += new System.EventHandler(this.maskedTextBox1_Leave);
            // 
            // txtSobrenome
            // 
            this.txtSobrenome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSobrenome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSobrenome.Location = new System.Drawing.Point(94, 195);
            this.txtSobrenome.Name = "txtSobrenome";
            this.txtSobrenome.Size = new System.Drawing.Size(300, 22);
            this.txtSobrenome.TabIndex = 38;
            this.txtSobrenome.Text = "Sobrenome";
            this.txtSobrenome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSobrenome.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txtSobrenome.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(94, 138);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 22);
            this.txtNome.TabIndex = 37;
            this.txtNome.Text = "Nome";
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNome.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtNome.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(94, 253);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 22);
            this.txtEmail.TabIndex = 39;
            this.txtEmail.Text = "Email";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // btnSalvarAlteracao
            // 
            this.btnSalvarAlteracao.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSalvarAlteracao.FlatAppearance.BorderSize = 0;
            this.btnSalvarAlteracao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarAlteracao.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarAlteracao.ForeColor = System.Drawing.Color.White;
            this.btnSalvarAlteracao.Location = new System.Drawing.Point(578, 395);
            this.btnSalvarAlteracao.Name = "btnSalvarAlteracao";
            this.btnSalvarAlteracao.Size = new System.Drawing.Size(185, 46);
            this.btnSalvarAlteracao.TabIndex = 56;
            this.btnSalvarAlteracao.Text = "Salvar Alterações";
            this.btnSalvarAlteracao.UseVisualStyleBackColor = false;
            this.btnSalvarAlteracao.Click += new System.EventHandler(this.btnSalvarAlteracao_Click);
            // 
            // maskValorCpf
            // 
            this.maskValorCpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskValorCpf.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskValorCpf.Location = new System.Drawing.Point(134, 419);
            this.maskValorCpf.Mask = "000,000,000-00";
            this.maskValorCpf.Name = "maskValorCpf";
            this.maskValorCpf.Size = new System.Drawing.Size(127, 22);
            this.maskValorCpf.TabIndex = 40;
            this.maskValorCpf.Enter += new System.EventHandler(this.maskValorCpfCnpj_Enter);
            this.maskValorCpf.Leave += new System.EventHandler(this.maskValorCpfCnpj_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(94, 223);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 1);
            this.panel3.TabIndex = 74;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(94, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 1);
            this.panel1.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(94, 281);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 1);
            this.panel2.TabIndex = 76;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(506, 223);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 1);
            this.panel4.TabIndex = 77;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(506, 166);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 1);
            this.panel5.TabIndex = 78;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(506, 281);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 1);
            this.panel6.TabIndex = 79;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(825, 223);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(50, 1);
            this.panel10.TabIndex = 82;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Location = new System.Drawing.Point(825, 166);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(50, 1);
            this.panel11.TabIndex = 83;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Black;
            this.panel13.Location = new System.Drawing.Point(328, 373);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(50, 1);
            this.panel13.TabIndex = 84;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(910, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 85;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(86, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 21);
            this.label16.TabIndex = 87;
            this.label16.Text = "Data do Cadastro";
            // 
            // maskDataAtual
            // 
            this.maskDataAtual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDataAtual.Enabled = false;
            this.maskDataAtual.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskDataAtual.Location = new System.Drawing.Point(108, 57);
            this.maskDataAtual.Mask = "00/00/0000";
            this.maskDataAtual.Name = "maskDataAtual";
            this.maskDataAtual.Size = new System.Drawing.Size(100, 22);
            this.maskDataAtual.TabIndex = 86;
            this.maskDataAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskDataAtual.ValidatingType = typeof(System.DateTime);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // RecuperarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 486);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.maskDataAtual);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtIdade);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskCep);
            this.Controls.Add(this.maskNascimento);
            this.Controls.Add(this.txtSobrenome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnSalvarAlteracao);
            this.Controls.Add(this.maskValorCpf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecuperarSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecuperarSenha";
            this.Load += new System.EventHandler(this.RecuperarSenha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIdade;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskCep;
        private System.Windows.Forms.MaskedTextBox maskNascimento;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSalvarAlteracao;
        private System.Windows.Forms.MaskedTextBox maskValorCpf;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.MaskedTextBox maskDataAtual;
        private System.Windows.Forms.Timer timer1;
    }
}