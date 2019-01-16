namespace DesktopForms.Views
{
    partial class PostupakForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVlasnik = new System.Windows.Forms.Label();
            this.labelZivotinja = new System.Windows.Forms.Label();
            this.buttonOdaberi = new System.Windows.Forms.Button();
            this.buttonPovijest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Novi postupak";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPovijest);
            this.groupBox1.Controls.Add(this.buttonOdaberi);
            this.groupBox1.Controls.Add(this.labelZivotinja);
            this.groupBox1.Controls.Add(this.labelVlasnik);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(28, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Životinja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vlasnik";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ime životinje";
            // 
            // labelVlasnik
            // 
            this.labelVlasnik.AutoSize = true;
            this.labelVlasnik.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelVlasnik.Location = new System.Drawing.Point(117, 33);
            this.labelVlasnik.Name = "labelVlasnik";
            this.labelVlasnik.Size = new System.Drawing.Size(150, 17);
            this.labelVlasnik.TabIndex = 2;
            this.labelVlasnik.Text = "Niste odabrali životinju";
            // 
            // labelZivotinja
            // 
            this.labelZivotinja.AutoSize = true;
            this.labelZivotinja.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelZivotinja.Location = new System.Drawing.Point(117, 65);
            this.labelZivotinja.Name = "labelZivotinja";
            this.labelZivotinja.Size = new System.Drawing.Size(150, 17);
            this.labelZivotinja.TabIndex = 3;
            this.labelZivotinja.Text = "Niste odabrali životinju";
            // 
            // buttonOdaberi
            // 
            this.buttonOdaberi.Location = new System.Drawing.Point(6, 111);
            this.buttonOdaberi.Name = "buttonOdaberi";
            this.buttonOdaberi.Size = new System.Drawing.Size(134, 32);
            this.buttonOdaberi.TabIndex = 4;
            this.buttonOdaberi.Text = "Odaberi životinju";
            this.buttonOdaberi.UseVisualStyleBackColor = true;
            // 
            // buttonPovijest
            // 
            this.buttonPovijest.Location = new System.Drawing.Point(146, 111);
            this.buttonPovijest.Name = "buttonPovijest";
            this.buttonPovijest.Size = new System.Drawing.Size(139, 32);
            this.buttonPovijest.TabIndex = 5;
            this.buttonPovijest.Text = "Povijest";
            this.buttonPovijest.UseVisualStyleBackColor = true;
            // 
            // PostupakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "PostupakForm";
            this.Text = "Postupak";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonPovijest;
        private System.Windows.Forms.Button buttonOdaberi;
        private System.Windows.Forms.Label labelZivotinja;
        private System.Windows.Forms.Label labelVlasnik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}