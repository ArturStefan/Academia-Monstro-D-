namespace Login
{
    partial class AreaSecretaria
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
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnMatricula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maskValorCpf = new System.Windows.Forms.MaskedTextBox();
            this.maskVencimento = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.maskDataCadastro = new System.Windows.Forms.MaskedTextBox();
            this.txtHoracadastro = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptbAlterarImagem = new System.Windows.Forms.PictureBox();
            this.ptbMenu = new System.Windows.Forms.PictureBox();
            this.panel25 = new System.Windows.Forms.Panel();
            this.lbl_FecharMenu = new System.Windows.Forms.Label();
            this.lbl_SairProg = new System.Windows.Forms.Label();
            this.lbl_AlterarCad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAlterarImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).BeginInit();
            this.panel25.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(399, 182);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(152, 54);
            this.btnPesquisar.TabIndex = 1;
            this.btnPesquisar.Text = "Pesquisar Aluno";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txt_Id
            // 
            this.txt_Id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Id.Enabled = false;
            this.txt_Id.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Id.Location = new System.Drawing.Point(161, 350);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(57, 22);
            this.txt_Id.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Enabled = false;
            this.txtNome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(247, 350);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(291, 22);
            this.txtNome.TabIndex = 3;
            // 
            // btnMatricula
            // 
            this.btnMatricula.BackColor = System.Drawing.Color.OrangeRed;
            this.btnMatricula.Enabled = false;
            this.btnMatricula.FlatAppearance.BorderSize = 0;
            this.btnMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatricula.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatricula.ForeColor = System.Drawing.Color.White;
            this.btnMatricula.Location = new System.Drawing.Point(359, 419);
            this.btnMatricula.Name = "btnMatricula";
            this.btnMatricula.Size = new System.Drawing.Size(147, 60);
            this.btnMatricula.TabIndex = 3;
            this.btnMatricula.Text = "Atualizar Matrícula";
            this.btnMatricula.UseVisualStyleBackColor = false;
            this.btnMatricula.Click += new System.EventHandler(this.btnMatricula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data da Matrícula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "CPF do Aluno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nome";
            // 
            // maskValorCpf
            // 
            this.maskValorCpf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskValorCpf.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskValorCpf.Location = new System.Drawing.Point(267, 198);
            this.maskValorCpf.Mask = "000,000,000-00";
            this.maskValorCpf.Name = "maskValorCpf";
            this.maskValorCpf.Size = new System.Drawing.Size(118, 22);
            this.maskValorCpf.TabIndex = 0;
            this.maskValorCpf.Enter += new System.EventHandler(this.maskValorCpf_Enter);
            this.maskValorCpf.Leave += new System.EventHandler(this.maskValorCpf_Leave);
            // 
            // maskVencimento
            // 
            this.maskVencimento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskVencimento.Enabled = false;
            this.maskVencimento.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskVencimento.Location = new System.Drawing.Point(199, 451);
            this.maskVencimento.Mask = "00/00/0000";
            this.maskVencimento.Name = "maskVencimento";
            this.maskVencimento.Size = new System.Drawing.Size(100, 22);
            this.maskVencimento.TabIndex = 2;
            this.maskVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskVencimento.ValidatingType = typeof(System.DateTime);
            this.maskVencimento.Enter += new System.EventHandler(this.maskVencimento_Enter);
            this.maskVencimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskVencimento_KeyPress);
            this.maskVencimento.Leave += new System.EventHandler(this.maskVencimento_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(113, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nome do Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(121, 103);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(189, 22);
            this.txtUsuario.TabIndex = 10;
            // 
            // maskDataCadastro
            // 
            this.maskDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maskDataCadastro.Enabled = false;
            this.maskDataCadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskDataCadastro.Location = new System.Drawing.Point(363, 103);
            this.maskDataCadastro.Mask = "00/00/0000";
            this.maskDataCadastro.Name = "maskDataCadastro";
            this.maskDataCadastro.Size = new System.Drawing.Size(91, 22);
            this.maskDataCadastro.TabIndex = 12;
            this.maskDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskDataCadastro.ValidatingType = typeof(System.DateTime);
            // 
            // txtHoracadastro
            // 
            this.txtHoracadastro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHoracadastro.Enabled = false;
            this.txtHoracadastro.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoracadastro.Location = new System.Drawing.Point(474, 103);
            this.txtHoracadastro.Name = "txtHoracadastro";
            this.txtHoracadastro.Size = new System.Drawing.Size(92, 22);
            this.txtHoracadastro.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(121, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 1);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(474, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 1);
            this.panel2.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(161, 378);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(57, 1);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(247, 378);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 1);
            this.panel4.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // ptbAlterarImagem
            // 
            this.ptbAlterarImagem.Image = global::Login.Properties.Resources.camera_01;
            this.ptbAlterarImagem.Location = new System.Drawing.Point(569, 82);
            this.ptbAlterarImagem.Name = "ptbAlterarImagem";
            this.ptbAlterarImagem.Size = new System.Drawing.Size(40, 36);
            this.ptbAlterarImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbAlterarImagem.TabIndex = 95;
            this.ptbAlterarImagem.TabStop = false;
            this.ptbAlterarImagem.Click += new System.EventHandler(this.ptbAlterarImagem_Click);
            // 
            // ptbMenu
            // 
            this.ptbMenu.Image = global::Login.Properties.Resources.icone_menu_02;
            this.ptbMenu.Location = new System.Drawing.Point(569, 12);
            this.ptbMenu.Name = "ptbMenu";
            this.ptbMenu.Size = new System.Drawing.Size(40, 36);
            this.ptbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMenu.TabIndex = 96;
            this.ptbMenu.TabStop = false;
            this.ptbMenu.Click += new System.EventHandler(this.ptbMenu_Click);
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.OrangeRed;
            this.panel25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel25.Controls.Add(this.lbl_FecharMenu);
            this.panel25.Controls.Add(this.lbl_SairProg);
            this.panel25.Controls.Add(this.lbl_AlterarCad);
            this.panel25.Location = new System.Drawing.Point(446, 12);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(163, 123);
            this.panel25.TabIndex = 97;
            this.panel25.Visible = false;
            // 
            // lbl_FecharMenu
            // 
            this.lbl_FecharMenu.AutoSize = true;
            this.lbl_FecharMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FecharMenu.ForeColor = System.Drawing.Color.White;
            this.lbl_FecharMenu.Location = new System.Drawing.Point(16, 4);
            this.lbl_FecharMenu.Name = "lbl_FecharMenu";
            this.lbl_FecharMenu.Size = new System.Drawing.Size(106, 18);
            this.lbl_FecharMenu.TabIndex = 2;
            this.lbl_FecharMenu.Text = "Fechar Menu";
            this.lbl_FecharMenu.Click += new System.EventHandler(this.lbl_FecharMenu_Click);
            this.lbl_FecharMenu.MouseEnter += new System.EventHandler(this.lbl_FecharMenu_MouseEnter);
            this.lbl_FecharMenu.MouseLeave += new System.EventHandler(this.lbl_FecharMenu_MouseLeave);
            // 
            // lbl_SairProg
            // 
            this.lbl_SairProg.AutoSize = true;
            this.lbl_SairProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SairProg.ForeColor = System.Drawing.Color.White;
            this.lbl_SairProg.Location = new System.Drawing.Point(16, 86);
            this.lbl_SairProg.Name = "lbl_SairProg";
            this.lbl_SairProg.Size = new System.Drawing.Size(60, 18);
            this.lbl_SairProg.TabIndex = 1;
            this.lbl_SairProg.Text = "Logout";
            this.lbl_SairProg.Click += new System.EventHandler(this.lbl_SairProg_Click);
            this.lbl_SairProg.MouseEnter += new System.EventHandler(this.lbl_SairProg_MouseEnter);
            this.lbl_SairProg.MouseLeave += new System.EventHandler(this.lbl_SairProg_MouseLeave);
            // 
            // lbl_AlterarCad
            // 
            this.lbl_AlterarCad.AutoSize = true;
            this.lbl_AlterarCad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AlterarCad.ForeColor = System.Drawing.Color.White;
            this.lbl_AlterarCad.Location = new System.Drawing.Point(16, 46);
            this.lbl_AlterarCad.Name = "lbl_AlterarCad";
            this.lbl_AlterarCad.Size = new System.Drawing.Size(131, 18);
            this.lbl_AlterarCad.TabIndex = 0;
            this.lbl_AlterarCad.Text = "Alterar Cadastro";
            this.lbl_AlterarCad.Click += new System.EventHandler(this.lbl_AlterarCad_Click);
            this.lbl_AlterarCad.MouseEnter += new System.EventHandler(this.lbl_AlterarCad_MouseEnter);
            this.lbl_AlterarCad.MouseLeave += new System.EventHandler(this.lbl_AlterarCad_MouseLeave);
            // 
            // AreaSecretaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(621, 540);
            this.Controls.Add(this.panel25);
            this.Controls.Add(this.ptbMenu);
            this.Controls.Add(this.ptbAlterarImagem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.maskDataCadastro);
            this.Controls.Add(this.txtHoracadastro);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskVencimento);
            this.Controls.Add(this.maskValorCpf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMatricula);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.btnPesquisar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AreaSecretaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AreaSecretaria";
            this.Load += new System.EventHandler(this.AreaSecretaria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAlterarImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMenu)).EndInit();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnMatricula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskValorCpf;
        private System.Windows.Forms.MaskedTextBox maskVencimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.MaskedTextBox maskDataCadastro;
        private System.Windows.Forms.TextBox txtHoracadastro;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ptbAlterarImagem;
        private System.Windows.Forms.PictureBox ptbMenu;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.Label lbl_FecharMenu;
        private System.Windows.Forms.Label lbl_SairProg;
        private System.Windows.Forms.Label lbl_AlterarCad;
    }
}