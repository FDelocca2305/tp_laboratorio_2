namespace FormPrincipal
{
    partial class FormClientes
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
            this.lstEntradaClientes = new System.Windows.Forms.ListBox();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstEntradaClientes
            // 
            this.lstEntradaClientes.FormattingEnabled = true;
            this.lstEntradaClientes.Location = new System.Drawing.Point(12, 51);
            this.lstEntradaClientes.Name = "lstEntradaClientes";
            this.lstEntradaClientes.Size = new System.Drawing.Size(644, 394);
            this.lstEntradaClientes.TabIndex = 0;
            // 
            // btnEntrada
            // 
            this.btnEntrada.Location = new System.Drawing.Point(755, 220);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(177, 59);
            this.btnEntrada.TabIndex = 1;
            this.btnEntrada.Text = "Permitir entrada de clientes";
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "CLIENTES";
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 548);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.lstEntradaClientes);
            this.Name = "FormClientes";
            this.Text = "Simulacion de entrada de clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstEntradaClientes;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Label label1;
    }
}