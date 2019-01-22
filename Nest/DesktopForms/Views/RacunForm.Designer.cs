namespace DesktopForms.Views
{
    partial class RacunForm
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
            this.groupBoxLijekovi = new System.Windows.Forms.GroupBox();
            this.buttonObrisiLijek = new System.Windows.Forms.Button();
            this.buttonDodajLijek = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxPostupci = new System.Windows.Forms.GroupBox();
            this.buttonObrisiPostupak = new System.Windows.Forms.Button();
            this.buttonDodajPostupak = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cijena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.labelUkupno = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxLijekovi.SuspendLayout();
            this.groupBoxPostupci.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Novi račun";
            // 
            // groupBoxLijekovi
            // 
            this.groupBoxLijekovi.Controls.Add(this.buttonObrisiLijek);
            this.groupBoxLijekovi.Controls.Add(this.buttonDodajLijek);
            this.groupBoxLijekovi.Controls.Add(this.listView1);
            this.groupBoxLijekovi.Location = new System.Drawing.Point(29, 91);
            this.groupBoxLijekovi.Name = "groupBoxLijekovi";
            this.groupBoxLijekovi.Size = new System.Drawing.Size(380, 276);
            this.groupBoxLijekovi.TabIndex = 1;
            this.groupBoxLijekovi.TabStop = false;
            this.groupBoxLijekovi.Text = "Lijekovi";
            // 
            // buttonObrisiLijek
            // 
            this.buttonObrisiLijek.Enabled = false;
            this.buttonObrisiLijek.Location = new System.Drawing.Point(224, 131);
            this.buttonObrisiLijek.Name = "buttonObrisiLijek";
            this.buttonObrisiLijek.Size = new System.Drawing.Size(104, 36);
            this.buttonObrisiLijek.TabIndex = 2;
            this.buttonObrisiLijek.Text = "Obriši";
            this.buttonObrisiLijek.UseVisualStyleBackColor = true;
            this.buttonObrisiLijek.Click += new System.EventHandler(this.buttonObrisiLijek_Click);
            // 
            // buttonDodajLijek
            // 
            this.buttonDodajLijek.Location = new System.Drawing.Point(219, 76);
            this.buttonDodajLijek.Name = "buttonDodajLijek";
            this.buttonDodajLijek.Size = new System.Drawing.Size(110, 33);
            this.buttonDodajLijek.TabIndex = 1;
            this.buttonDodajLijek.Text = "Dodaj";
            this.buttonDodajLijek.UseVisualStyleBackColor = true;
            this.buttonDodajLijek.Click += new System.EventHandler(this.buttonDodajLijek_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 43);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(185, 213);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lijek";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cijena";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Količina";
            // 
            // groupBoxPostupci
            // 
            this.groupBoxPostupci.Controls.Add(this.buttonObrisiPostupak);
            this.groupBoxPostupci.Controls.Add(this.buttonDodajPostupak);
            this.groupBoxPostupci.Controls.Add(this.listView2);
            this.groupBoxPostupci.Location = new System.Drawing.Point(435, 96);
            this.groupBoxPostupci.Name = "groupBoxPostupci";
            this.groupBoxPostupci.Size = new System.Drawing.Size(349, 270);
            this.groupBoxPostupci.TabIndex = 2;
            this.groupBoxPostupci.TabStop = false;
            this.groupBoxPostupci.Text = "Postupci";
            // 
            // buttonObrisiPostupak
            // 
            this.buttonObrisiPostupak.Location = new System.Drawing.Point(218, 121);
            this.buttonObrisiPostupak.Name = "buttonObrisiPostupak";
            this.buttonObrisiPostupak.Size = new System.Drawing.Size(89, 40);
            this.buttonObrisiPostupak.TabIndex = 2;
            this.buttonObrisiPostupak.Text = "Obriši";
            this.buttonObrisiPostupak.UseVisualStyleBackColor = true;
            this.buttonObrisiPostupak.Click += new System.EventHandler(this.buttonObrisiPostupak_Click);
            // 
            // buttonDodajPostupak
            // 
            this.buttonDodajPostupak.Location = new System.Drawing.Point(215, 77);
            this.buttonDodajPostupak.Name = "buttonDodajPostupak";
            this.buttonDodajPostupak.Size = new System.Drawing.Size(103, 26);
            this.buttonDodajPostupak.TabIndex = 1;
            this.buttonDodajPostupak.Text = "Dodaj";
            this.buttonDodajPostupak.UseVisualStyleBackColor = true;
            this.buttonDodajPostupak.Click += new System.EventHandler(this.buttonDodajPostupak_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.Cijena});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(16, 42);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(165, 208);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Postupak";
            this.columnHeader4.Width = 74;
            // 
            // Cijena
            // 
            this.Cijena.Text = "Cijena";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(523, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ukupno:";
            // 
            // labelUkupno
            // 
            this.labelUkupno.AutoSize = true;
            this.labelUkupno.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUkupno.Location = new System.Drawing.Point(638, 382);
            this.labelUkupno.Name = "labelUkupno";
            this.labelUkupno.Size = new System.Drawing.Size(68, 32);
            this.labelUkupno.TabIndex = 4;
            this.labelUkupno.Text = "0 kn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Spremi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RacunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 530);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelUkupno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxPostupci);
            this.Controls.Add(this.groupBoxLijekovi);
            this.Controls.Add(this.label1);
            this.Name = "RacunForm";
            this.Text = "RacunForm";
            this.groupBoxLijekovi.ResumeLayout(false);
            this.groupBoxPostupci.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxLijekovi;
        private System.Windows.Forms.Button buttonDodajLijek;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBoxPostupci;
        private System.Windows.Forms.Button buttonObrisiLijek;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonObrisiPostupak;
        private System.Windows.Forms.Button buttonDodajPostupak;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader Cijena;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelUkupno;
        private System.Windows.Forms.Button button1;
    }
}