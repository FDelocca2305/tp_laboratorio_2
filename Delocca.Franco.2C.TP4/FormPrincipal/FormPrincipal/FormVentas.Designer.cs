namespace FormPrincipal
{
    partial class FormVentas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrecioProducto = new System.Windows.Forms.Label();
            this.btnAgregarVenta = new System.Windows.Forms.Button();
            this.btnBorrarVenta = new System.Windows.Forms.Button();
            this.btnEditarVenta = new System.Windows.Forms.Button();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "VENTAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(488, 340);
            this.dataGridView1.TabIndex = 1;
            // 
            // cmbProductos
            // 
            this.cmbProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(554, 103);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(321, 37);
            this.cmbProductos.TabIndex = 2;
            this.cmbProductos.SelectedValueChanged += new System.EventHandler(this.cmbProductos_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label2.Location = new System.Drawing.Point(549, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Producto";
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.txtCant.Location = new System.Drawing.Point(706, 170);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(169, 35);
            this.txtCant.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label3.Location = new System.Drawing.Point(551, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label4.Location = new System.Drawing.Point(553, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio:";
            // 
            // lblPrecioProducto
            // 
            this.lblPrecioProducto.AutoSize = true;
            this.lblPrecioProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblPrecioProducto.Location = new System.Drawing.Point(728, 242);
            this.lblPrecioProducto.Name = "lblPrecioProducto";
            this.lblPrecioProducto.Size = new System.Drawing.Size(111, 29);
            this.lblPrecioProducto.TabIndex = 7;
            this.lblPrecioProducto.Text = "lblPrecio";
            // 
            // btnAgregarVenta
            // 
            this.btnAgregarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.btnAgregarVenta.Location = new System.Drawing.Point(621, 437);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.Size = new System.Drawing.Size(195, 49);
            this.btnAgregarVenta.TabIndex = 8;
            this.btnAgregarVenta.Text = "Agregar";
            this.btnAgregarVenta.UseVisualStyleBackColor = true;
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarVenta_Click);
            // 
            // btnBorrarVenta
            // 
            this.btnBorrarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.btnBorrarVenta.Location = new System.Drawing.Point(12, 438);
            this.btnBorrarVenta.Name = "btnBorrarVenta";
            this.btnBorrarVenta.Size = new System.Drawing.Size(155, 48);
            this.btnBorrarVenta.TabIndex = 9;
            this.btnBorrarVenta.Text = "Borrar";
            this.btnBorrarVenta.UseVisualStyleBackColor = true;
            this.btnBorrarVenta.Click += new System.EventHandler(this.btnBorrarVenta_Click);
            // 
            // btnEditarVenta
            // 
            this.btnEditarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.btnEditarVenta.Location = new System.Drawing.Point(345, 438);
            this.btnEditarVenta.Name = "btnEditarVenta";
            this.btnEditarVenta.Size = new System.Drawing.Size(155, 49);
            this.btnEditarVenta.TabIndex = 10;
            this.btnEditarVenta.Text = "Editar";
            this.btnEditarVenta.UseVisualStyleBackColor = true;
            this.btnEditarVenta.Click += new System.EventHandler(this.btnEditarVenta_Click);
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnGenerarFactura.Location = new System.Drawing.Point(174, 438);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(165, 48);
            this.btnGenerarFactura.TabIndex = 11;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 534);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.btnEditarVenta);
            this.Controls.Add(this.btnBorrarVenta);
            this.Controls.Add(this.btnAgregarVenta);
            this.Controls.Add(this.lblPrecioProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FormVentas";
            this.Text = "Listado de Ventas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrecioProducto;
        private System.Windows.Forms.Button btnAgregarVenta;
        private System.Windows.Forms.Button btnBorrarVenta;
        private System.Windows.Forms.Button btnEditarVenta;
        private System.Windows.Forms.Button btnGenerarFactura;
    }
}