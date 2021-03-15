namespace Condominio
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewReporte = new System.Windows.Forms.DataGridView();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.buttonOrdenar = new System.Windows.Forms.Button();
            this.buttonMasPropiedades = new System.Windows.Forms.Button();
            this.labelPropietario = new System.Windows.Forms.Label();
            this.labelPropiedades = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReporte
            // 
            this.dataGridViewReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReporte.Location = new System.Drawing.Point(28, 26);
            this.dataGridViewReporte.Name = "dataGridViewReporte";
            this.dataGridViewReporte.Size = new System.Drawing.Size(558, 259);
            this.dataGridViewReporte.TabIndex = 0;
            // 
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(40, 333);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(177, 55);
            this.buttonCargar.TabIndex = 1;
            this.buttonCargar.Text = "Cargar Datos";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // buttonOrdenar
            // 
            this.buttonOrdenar.Location = new System.Drawing.Point(283, 333);
            this.buttonOrdenar.Name = "buttonOrdenar";
            this.buttonOrdenar.Size = new System.Drawing.Size(117, 56);
            this.buttonOrdenar.TabIndex = 2;
            this.buttonOrdenar.Text = "Ordenar por Cuota";
            this.buttonOrdenar.UseVisualStyleBackColor = true;
            this.buttonOrdenar.Click += new System.EventHandler(this.buttonOrdenar_Click);
            // 
            // buttonMasPropiedades
            // 
            this.buttonMasPropiedades.Location = new System.Drawing.Point(670, 115);
            this.buttonMasPropiedades.Name = "buttonMasPropiedades";
            this.buttonMasPropiedades.Size = new System.Drawing.Size(117, 51);
            this.buttonMasPropiedades.TabIndex = 3;
            this.buttonMasPropiedades.Text = "Propietario con mas Propiedades";
            this.buttonMasPropiedades.UseVisualStyleBackColor = true;
            this.buttonMasPropiedades.Click += new System.EventHandler(this.buttonMasPropiedades_Click);
            // 
            // labelPropietario
            // 
            this.labelPropietario.AutoSize = true;
            this.labelPropietario.Location = new System.Drawing.Point(670, 26);
            this.labelPropietario.Name = "labelPropietario";
            this.labelPropietario.Size = new System.Drawing.Size(57, 13);
            this.labelPropietario.TabIndex = 4;
            this.labelPropietario.Text = "Propietario";
            // 
            // labelPropiedades
            // 
            this.labelPropiedades.AutoSize = true;
            this.labelPropiedades.Location = new System.Drawing.Point(670, 54);
            this.labelPropiedades.Name = "labelPropiedades";
            this.labelPropiedades.Size = new System.Drawing.Size(66, 13);
            this.labelPropiedades.TabIndex = 5;
            this.labelPropiedades.Text = "Propiedades";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 450);
            this.Controls.Add(this.labelPropiedades);
            this.Controls.Add(this.labelPropietario);
            this.Controls.Add(this.buttonMasPropiedades);
            this.Controls.Add(this.buttonOrdenar);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.dataGridViewReporte);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReporte;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Button buttonOrdenar;
        private System.Windows.Forms.Button buttonMasPropiedades;
        private System.Windows.Forms.Label labelPropietario;
        private System.Windows.Forms.Label labelPropiedades;
    }
}

