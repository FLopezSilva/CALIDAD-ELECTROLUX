
namespace Presentation.Opcion.MenuEnsayosIndi.Pruebas
{
    partial class FormCondicionEnsayoIndi
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodCocina = new System.Windows.Forms.TextBox();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCalorifico = new System.Windows.Forms.TextBox();
            this.txtPresiongas = new System.Windows.Forms.TextBox();
            this.numericTemperatura = new System.Windows.Forms.NumericUpDown();
            this.numericHumedad = new System.Windows.Forms.NumericUpDown();
            this.cmbGasReferencia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHumedad)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(427, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 25);
            this.label10.TabIndex = 42;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(423, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 25);
            this.label9.TabIndex = 41;
            this.label9.Text = "°C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(423, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "Kcal/kg.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(423, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 25);
            this.label7.TabIndex = 39;
            this.label7.Text = "KPA";
            // 
            // txtCodCocina
            // 
            this.txtCodCocina.Enabled = false;
            this.txtCodCocina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodCocina.Location = new System.Drawing.Point(596, 160);
            this.txtCodCocina.Name = "txtCodCocina";
            this.txtCodCocina.Size = new System.Drawing.Size(262, 28);
            this.txtCodCocina.TabIndex = 38;
            this.txtCodCocina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTerminar
            // 
            this.btnTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            this.btnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTerminar.Location = new System.Drawing.Point(623, 227);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(205, 51);
            this.btnTerminar.TabIndex = 37;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(676, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 25);
            this.label6.TabIndex = 36;
            this.label6.Text = "ID COCINA:";
            // 
            // txtCalorifico
            // 
            this.txtCalorifico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalorifico.Location = new System.Drawing.Point(253, 163);
            this.txtCalorifico.Name = "txtCalorifico";
            this.txtCalorifico.Size = new System.Drawing.Size(165, 27);
            this.txtCalorifico.TabIndex = 35;
            this.txtCalorifico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCalorifico.TextChanged += new System.EventHandler(this.txtCalorifico_TextChanged);
            this.txtCalorifico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalorifico_KeyPress_1);
            // 
            // txtPresiongas
            // 
            this.txtPresiongas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresiongas.Location = new System.Drawing.Point(253, 121);
            this.txtPresiongas.Name = "txtPresiongas";
            this.txtPresiongas.Size = new System.Drawing.Size(165, 27);
            this.txtPresiongas.TabIndex = 34;
            this.txtPresiongas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPresiongas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPresiongas_KeyPress_1);
            // 
            // numericTemperatura
            // 
            this.numericTemperatura.DecimalPlaces = 1;
            this.numericTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericTemperatura.Location = new System.Drawing.Point(253, 248);
            this.numericTemperatura.Name = "numericTemperatura";
            this.numericTemperatura.Size = new System.Drawing.Size(165, 27);
            this.numericTemperatura.TabIndex = 33;
            this.numericTemperatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericHumedad
            // 
            this.numericHumedad.DecimalPlaces = 1;
            this.numericHumedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHumedad.Location = new System.Drawing.Point(253, 206);
            this.numericHumedad.Name = "numericHumedad";
            this.numericHumedad.Size = new System.Drawing.Size(165, 27);
            this.numericHumedad.TabIndex = 32;
            this.numericHumedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbGasReferencia
            // 
            this.cmbGasReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGasReferencia.FormattingEnabled = true;
            this.cmbGasReferencia.Location = new System.Drawing.Point(253, 80);
            this.cmbGasReferencia.Name = "cmbGasReferencia";
            this.cmbGasReferencia.Size = new System.Drawing.Size(165, 28);
            this.cmbGasReferencia.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 25);
            this.label5.TabIndex = 30;
            this.label5.Text = "Temperatura ambiente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 29;
            this.label4.Text = "Humedad relativa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Poder calorifico:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Presion de gas:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Gas de referencia:";
            // 
            // FormCondicionEnsayoIndi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCondicionEnsayoIndi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCondicionEnsayoIndi";
            this.Leave += new System.EventHandler(this.FormCondicionEnsayoIndi_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.numericTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHumedad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtCodCocina;
        public System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtCalorifico;
        public System.Windows.Forms.TextBox txtPresiongas;
        public System.Windows.Forms.NumericUpDown numericTemperatura;
        public System.Windows.Forms.NumericUpDown numericHumedad;
        public System.Windows.Forms.ComboBox cmbGasReferencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}