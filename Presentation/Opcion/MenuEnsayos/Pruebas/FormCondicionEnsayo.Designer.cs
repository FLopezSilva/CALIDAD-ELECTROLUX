namespace Presentation.Opcion.MenuEnsayos.Pruebas
{
    partial class FormCondicionEnsayo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGasReferencia = new System.Windows.Forms.ComboBox();
            this.numericHumedad = new System.Windows.Forms.NumericUpDown();
            this.numericTemperatura = new System.Windows.Forms.NumericUpDown();
            this.txtPresiongas = new System.Windows.Forms.TextBox();
            this.txtCalorifico = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.txtCodCocina = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericHumedad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperatura)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gas de referencia:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Presion de gas:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Poder calorifico:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Humedad relativa:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Temperatura ambiente:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbGasReferencia
            // 
            this.cmbGasReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGasReferencia.FormattingEnabled = true;
            this.cmbGasReferencia.Location = new System.Drawing.Point(228, 67);
            this.cmbGasReferencia.Name = "cmbGasReferencia";
            this.cmbGasReferencia.Size = new System.Drawing.Size(165, 28);
            this.cmbGasReferencia.TabIndex = 8;
            this.cmbGasReferencia.SelectedIndexChanged += new System.EventHandler(this.cmbGasReferencia_SelectedIndexChanged);
            this.cmbGasReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbGasReferencia_KeyPress);
            // 
            // numericHumedad
            // 
            this.numericHumedad.DecimalPlaces = 1;
            this.numericHumedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHumedad.Location = new System.Drawing.Point(228, 193);
            this.numericHumedad.Name = "numericHumedad";
            this.numericHumedad.Size = new System.Drawing.Size(165, 27);
            this.numericHumedad.TabIndex = 14;
            this.numericHumedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericHumedad.ValueChanged += new System.EventHandler(this.numericHumedad_ValueChanged);
            // 
            // numericTemperatura
            // 
            this.numericTemperatura.DecimalPlaces = 1;
            this.numericTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTemperatura.Location = new System.Drawing.Point(228, 235);
            this.numericTemperatura.Name = "numericTemperatura";
            this.numericTemperatura.Size = new System.Drawing.Size(165, 27);
            this.numericTemperatura.TabIndex = 15;
            this.numericTemperatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTemperatura.ValueChanged += new System.EventHandler(this.numericTemperatura_ValueChanged);
            // 
            // txtPresiongas
            // 
            this.txtPresiongas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresiongas.Location = new System.Drawing.Point(228, 108);
            this.txtPresiongas.Name = "txtPresiongas";
            this.txtPresiongas.Size = new System.Drawing.Size(165, 27);
            this.txtPresiongas.TabIndex = 16;
            this.txtPresiongas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPresiongas.TextChanged += new System.EventHandler(this.txtPresiongas_TextChanged_1);
            this.txtPresiongas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPresiongas_KeyPress_1);
            // 
            // txtCalorifico
            // 
            this.txtCalorifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalorifico.Location = new System.Drawing.Point(228, 150);
            this.txtCalorifico.Name = "txtCalorifico";
            this.txtCalorifico.Size = new System.Drawing.Size(165, 27);
            this.txtCalorifico.TabIndex = 17;
            this.txtCalorifico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCalorifico.TextChanged += new System.EventHandler(this.txtCalorifico_TextChanged);
            this.txtCalorifico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalorifico_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(651, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "ID COCINA:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTerminar.Location = new System.Drawing.Point(598, 214);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(205, 51);
            this.btnTerminar.TabIndex = 20;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // txtCodCocina
            // 
            this.txtCodCocina.Enabled = false;
            this.txtCodCocina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCocina.Location = new System.Drawing.Point(571, 147);
            this.txtCodCocina.Name = "txtCodCocina";
            this.txtCodCocina.Size = new System.Drawing.Size(262, 28);
            this.txtCodCocina.TabIndex = 21;
            this.txtCodCocina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodCocina.TextChanged += new System.EventHandler(this.txtCodCocina_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(398, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "KPA";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(398, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Kcal/kg.";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(398, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "°C";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(402, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "%";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // FormCondicionEnsayo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(933, 357);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCodCocina);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCalorifico);
            this.Controls.Add(this.txtPresiongas);
            this.Controls.Add(this.numericTemperatura);
            this.Controls.Add(this.numericHumedad);
            this.Controls.Add(this.cmbGasReferencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCondicionEnsayo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCondicionEnsayo";
            this.Load += new System.EventHandler(this.FormCondicionEnsayo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormCondicionEnsayo_KeyPress);
            this.Leave += new System.EventHandler(this.FormCondicionEnsayo_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.numericHumedad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperatura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCodCocina;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnTerminar;
        public System.Windows.Forms.ComboBox cmbGasReferencia;
        public System.Windows.Forms.NumericUpDown numericHumedad;
        public System.Windows.Forms.NumericUpDown numericTemperatura;
        public System.Windows.Forms.TextBox txtPresiongas;
        public System.Windows.Forms.TextBox txtCalorifico;
    }
}