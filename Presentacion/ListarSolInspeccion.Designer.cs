namespace Presentacion
{
    partial class ListarSolInspeccion
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
            this.dgwListar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwListar
            // 
            this.dgwListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListar.Location = new System.Drawing.Point(12, 110);
            this.dgwListar.Name = "dgwListar";
            this.dgwListar.ReadOnly = true;
            this.dgwListar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwListar.Size = new System.Drawing.Size(660, 239);
            this.dgwListar.TabIndex = 2;
            this.dgwListar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwListar_CellDoubleClick);
            // 
            // ListarSolInspeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.dgwListar);
            this.Name = "ListarSolInspeccion";
            this.Text = "ListarSolInspeccion";
            this.Load += new System.EventHandler(this.ListarSolInspeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwListar;
    }
}