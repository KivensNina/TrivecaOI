namespace Presentacion
{
    partial class SeriesExcel
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
            this.dgvListarExcel = new System.Windows.Forms.DataGridView();
            this.btnCargarDatos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListarExcel
            // 
            this.dgvListarExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarExcel.Location = new System.Drawing.Point(12, 12);
            this.dgvListarExcel.Name = "dgvListarExcel";
            this.dgvListarExcel.Size = new System.Drawing.Size(290, 345);
            this.dgvListarExcel.TabIndex = 0;
            // 
            // btnCargarDatos
            // 
            this.btnCargarDatos.Location = new System.Drawing.Point(315, 12);
            this.btnCargarDatos.Name = "btnCargarDatos";
            this.btnCargarDatos.Size = new System.Drawing.Size(88, 23);
            this.btnCargarDatos.TabIndex = 1;
            this.btnCargarDatos.Text = "Cargar Datos";
            this.btnCargarDatos.UseVisualStyleBackColor = true;
            this.btnCargarDatos.Click += new System.EventHandler(this.btnCargarDatos_Click);
            // 
            // SeriesExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 369);
            this.Controls.Add(this.btnCargarDatos);
            this.Controls.Add(this.dgvListarExcel);
            this.Name = "SeriesExcel";
            this.Text = "SeriesExcel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarExcel;
        private System.Windows.Forms.Button btnCargarDatos;
    }
}