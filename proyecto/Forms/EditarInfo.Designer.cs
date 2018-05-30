namespace proyecto
{
    partial class EditarInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarInfo));
            this.ComBoxEditar = new System.Windows.Forms.ComboBox();
            this.BoxEditar = new System.Windows.Forms.TextBox();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComBoxEditar
            // 
            this.ComBoxEditar.FormattingEnabled = true;
            this.ComBoxEditar.Items.AddRange(new object[] {
            "Cancion",
            "Artista",
            "Album",
            "Año",
            "Letra"});
            this.ComBoxEditar.Location = new System.Drawing.Point(12, 42);
            this.ComBoxEditar.Name = "ComBoxEditar";
            this.ComBoxEditar.Size = new System.Drawing.Size(121, 21);
            this.ComBoxEditar.TabIndex = 0;
            // 
            // BoxEditar
            // 
            this.BoxEditar.Location = new System.Drawing.Point(139, 42);
            this.BoxEditar.Multiline = true;
            this.BoxEditar.Name = "BoxEditar";
            this.BoxEditar.Size = new System.Drawing.Size(195, 20);
            this.BoxEditar.TabIndex = 1;
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(259, 89);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(75, 23);
            this.BtnEnviar.TabIndex = 2;
            this.BtnEnviar.Text = "Guardar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // EditarInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 134);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.BoxEditar);
            this.Controls.Add(this.ComBoxEditar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarInfo";
            this.Text = "Editar Informacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComBoxEditar;
        private System.Windows.Forms.TextBox BoxEditar;
        private System.Windows.Forms.Button BtnEnviar;
    }
}