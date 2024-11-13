namespace SegundoParcialElipses.Windows
{
    partial class frmElipsesAE
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtSemiejeMayor = new TextBox();
            label2 = new Label();
            txtSemiejeMenor = new TextBox();
            groupBox1 = new GroupBox();
            rbtDoble = new RadioButton();
            rbtRayado = new RadioButton();
            rbtPunteado = new RadioButton();
            rbtSolido = new RadioButton();
            cboColores = new ComboBox();
            label3 = new Label();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 45);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Semieje Mayor:";
            // 
            // txtSemiejeMayor
            // 
            txtSemiejeMayor.Location = new Point(158, 42);
            txtSemiejeMayor.Name = "txtSemiejeMayor";
            txtSemiejeMayor.Size = new Size(100, 23);
            txtSemiejeMayor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 74);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 0;
            label2.Text = "Semieje Menor:";
            // 
            // txtSemiejeMenor
            // 
            txtSemiejeMenor.Location = new Point(158, 71);
            txtSemiejeMenor.Name = "txtSemiejeMenor";
            txtSemiejeMenor.Size = new Size(100, 23);
            txtSemiejeMenor.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtDoble);
            groupBox1.Controls.Add(rbtRayado);
            groupBox1.Controls.Add(rbtPunteado);
            groupBox1.Controls.Add(rbtSolido);
            groupBox1.Location = new Point(60, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 140);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = " Seleccione Borde ";
            // 
            // rbtDoble
            // 
            rbtDoble.AutoSize = true;
            rbtDoble.Location = new Point(11, 97);
            rbtDoble.Name = "rbtDoble";
            rbtDoble.Size = new Size(56, 19);
            rbtDoble.TabIndex = 0;
            rbtDoble.Text = "Doble";
            rbtDoble.UseVisualStyleBackColor = true;
            // 
            // rbtRayado
            // 
            rbtRayado.AutoSize = true;
            rbtRayado.Location = new Point(11, 72);
            rbtRayado.Name = "rbtRayado";
            rbtRayado.Size = new Size(64, 19);
            rbtRayado.TabIndex = 0;
            rbtRayado.Text = "Rayado";
            rbtRayado.UseVisualStyleBackColor = true;
            // 
            // rbtPunteado
            // 
            rbtPunteado.AutoSize = true;
            rbtPunteado.Location = new Point(11, 47);
            rbtPunteado.Name = "rbtPunteado";
            rbtPunteado.Size = new Size(76, 19);
            rbtPunteado.TabIndex = 0;
            rbtPunteado.Text = "Punteado";
            rbtPunteado.UseVisualStyleBackColor = true;
            // 
            // rbtSolido
            // 
            rbtSolido.AutoSize = true;
            rbtSolido.Checked = true;
            rbtSolido.Location = new Point(11, 22);
            rbtSolido.Name = "rbtSolido";
            rbtSolido.Size = new Size(58, 19);
            rbtSolido.TabIndex = 0;
            rbtSolido.TabStop = true;
            rbtSolido.Text = "Sólido";
            rbtSolido.UseVisualStyleBackColor = true;
            // 
            // cboColores
            // 
            cboColores.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColores.FormattingEnabled = true;
            cboColores.Location = new Point(137, 267);
            cboColores.Name = "cboColores";
            cboColores.Size = new Size(121, 23);
            cboColores.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 271);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Color";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(62, 323);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 54);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(185, 323);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 54);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmElipsesAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 399);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(label3);
            Controls.Add(cboColores);
            Controls.Add(groupBox1);
            Controls.Add(txtSemiejeMenor);
            Controls.Add(label2);
            Controls.Add(txtSemiejeMayor);
            Controls.Add(label1);
            MaximumSize = new Size(338, 438);
            MinimumSize = new Size(338, 438);
            Name = "frmElipsesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmElipsesAE";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSemiejeMayor;
        private Label label2;
        private TextBox txtSemiejeMenor;
        private GroupBox groupBox1;
        private RadioButton rbtSolido;
        private RadioButton rbtDoble;
        private RadioButton rbtRayado;
        private RadioButton rbtPunteado;
        private ComboBox cboColores;
        private Label label3;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}