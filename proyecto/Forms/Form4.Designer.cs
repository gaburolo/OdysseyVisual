﻿namespace proyecto
{
    partial class Reproductor
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
            this.components = new System.ComponentModel.Container();
            this.BarraProgreso = new System.Windows.Forms.ProgressBar();
            this.Pause = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BarraProgreso.ForeColor = System.Drawing.Color.White;
            this.BarraProgreso.Location = new System.Drawing.Point(11, 109);
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(321, 10);
            this.BarraProgreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BarraProgreso.TabIndex = 0;
            // 
            // Pause
            // 
            this.Pause.FlatAppearance.BorderSize = 0;
            this.Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pause.Image = global::proyecto.Properties.Resources.Pausa;
            this.Pause.Location = new System.Drawing.Point(173, 29);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(96, 60);
            this.Pause.TabIndex = 3;
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Play
            // 
            this.Play.FlatAppearance.BorderSize = 0;
            this.Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play.Image = global::proyecto.Properties.Resources.Play;
            this.Play.Location = new System.Drawing.Point(78, 21);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(74, 77);
            this.Play.TabIndex = 2;
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Reproductor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 147);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.BarraProgreso);
            this.Name = "Reproductor";
            this.Text = "Reproductor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar BarraProgreso;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}