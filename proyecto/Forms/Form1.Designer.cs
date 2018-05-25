using System.Windows.Forms;

namespace proyecto
{
    partial class Form1
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
            this.BoxBuscar = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ColNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColArtista = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColAño = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDuracion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnAgregarInfo = new System.Windows.Forms.Button();
            this.BoxCategorias = new System.Windows.Forms.ComboBox();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnSincro = new System.Windows.Forms.Button();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoxBuscar
            // 
            this.BoxBuscar.Location = new System.Drawing.Point(206, 54);
            this.BoxBuscar.Name = "BoxBuscar";
            this.BoxBuscar.Size = new System.Drawing.Size(264, 20);
            this.BoxBuscar.TabIndex = 1;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(476, 55);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 20);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(723, 413);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(65, 25);
            this.BtnSalir.TabIndex = 3;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColNombre,
            this.ColArtista,
            this.ColAlbum,
            this.ColAño,
            this.ColDuracion});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(46, 123);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(697, 234);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Column_Click);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListaCanciones_SelectedIndexChanged);
            // 
            // ColNombre
            // 
            this.ColNombre.Text = "Nombre";
            this.ColNombre.Width = 223;
            // 
            // ColArtista
            // 
            this.ColArtista.Text = "Artista";
            this.ColArtista.Width = 154;
            // 
            // ColAlbum
            // 
            this.ColAlbum.Text = "Album";
            this.ColAlbum.Width = 136;
            // 
            // ColAño
            // 
            this.ColAño.Text = "Año";
            this.ColAño.Width = 86;
            // 
            // ColDuracion
            // 
            this.ColDuracion.Text = "Duracion";
            this.ColDuracion.Width = 92;
            // 
            // BtnAgregarInfo
            // 
            this.BtnAgregarInfo.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BtnAgregarInfo.FlatAppearance.BorderSize = 0;
            this.BtnAgregarInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAgregarInfo.Location = new System.Drawing.Point(658, 48);
            this.BtnAgregarInfo.Name = "BtnAgregarInfo";
            this.BtnAgregarInfo.Size = new System.Drawing.Size(110, 30);
            this.BtnAgregarInfo.TabIndex = 8;
            this.BtnAgregarInfo.Text = "Agregar Informacion";
            this.BtnAgregarInfo.UseVisualStyleBackColor = false;
            this.BtnAgregarInfo.Click += new System.EventHandler(this.BtnAgregarInfo_Click);
            // 
            // BoxCategorias
            // 
            this.BoxCategorias.FormattingEnabled = true;
            this.BoxCategorias.Items.AddRange(new object[] {
            "Cancion",
            "Artista",
            "Album"});
            this.BoxCategorias.Location = new System.Drawing.Point(79, 54);
            this.BoxCategorias.Name = "BoxCategorias";
            this.BoxCategorias.Size = new System.Drawing.Size(121, 21);
            this.BoxCategorias.TabIndex = 9;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Image = global::proyecto.Properties.Resources.eliminar;
            this.BtnEliminar.Location = new System.Drawing.Point(749, 123);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(35, 35);
            this.BtnEliminar.TabIndex = 10;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnSincro
            // 
            this.BtnSincro.FlatAppearance.BorderSize = 0;
            this.BtnSincro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSincro.Image = global::proyecto.Properties.Resources.syncroni1;
            this.BtnSincro.Location = new System.Drawing.Point(621, 363);
            this.BtnSincro.Name = "BtnSincro";
            this.BtnSincro.Size = new System.Drawing.Size(60, 65);
            this.BtnSincro.TabIndex = 7;
            this.BtnSincro.UseVisualStyleBackColor = true;
            // 
            // BtnPlay
            // 
            this.BtnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnPlay.FlatAppearance.BorderSize = 0;
            this.BtnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlay.Image = global::proyecto.Properties.Resources.Play;
            this.BtnPlay.Location = new System.Drawing.Point(61, 373);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(45, 45);
            this.BtnPlay.TabIndex = 4;
            this.BtnPlay.UseVisualStyleBackColor = false;
            this.BtnPlay.Click += new System.EventHandler(this.BtnReproducir_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.White;
            this.BtnAgregar.FlatAppearance.BorderSize = 0;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Image = global::proyecto.Properties.Resources.Agregar;
            this.BtnAgregar.Location = new System.Drawing.Point(597, 40);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(45, 45);
            this.BtnAgregar.TabIndex = 0;
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BoxCategorias);
            this.Controls.Add(this.BtnAgregarInfo);
            this.Controls.Add(this.BtnSincro);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.BtnPlay);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.BoxBuscar);
            this.Controls.Add(this.BtnAgregar);
            this.Name = "Form1";
            this.Text = "Oddyssey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox BoxBuscar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.ListView listView1;
        private ColumnHeader ColNombre;
        private ColumnHeader ColArtista;
        private ColumnHeader ColAlbum;
        private ColumnHeader ColAño;
        private ColumnHeader ColDuracion;
        private Button BtnSincro;
        private Button BtnAgregarInfo;
        private ComboBox BoxCategorias;
        private Button BtnEliminar;
    }
}

