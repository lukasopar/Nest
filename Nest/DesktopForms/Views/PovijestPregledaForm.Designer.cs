namespace DesktopForms.Views
{
    partial class PovijestPregledaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PovijestPregledaForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Postupak = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Životinja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelPostupak = new System.Windows.Forms.Label();
            this.labelZiv = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.listBoxDijagnoza = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxTerapija = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonIzvjestaj = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Datum,
            this.Postupak,
            this.Životinja});
            this.listView1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(39, 113);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(412, 460);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            this.Datum.Width = 88;
            // 
            // Postupak
            // 
            this.Postupak.Text = "Postupak";
            this.Postupak.Width = 120;
            // 
            // Životinja
            // 
            this.Životinja.Text = "Životinja";
            this.Životinja.Width = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(87, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Povijest pregleda";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelPostupak);
            this.groupBox1.Controls.Add(this.labelZiv);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.listBoxDijagnoza);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.listBoxTerapija);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(480, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 469);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji";
            this.groupBox1.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(133, 102);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(222, 55);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Opis postupka:";
            // 
            // labelPostupak
            // 
            this.labelPostupak.AutoSize = true;
            this.labelPostupak.Location = new System.Drawing.Point(100, 73);
            this.labelPostupak.Name = "labelPostupak";
            this.labelPostupak.Size = new System.Drawing.Size(51, 18);
            this.labelPostupak.TabIndex = 9;
            this.labelPostupak.Text = "label8";
            this.labelPostupak.Visible = false;
            // 
            // labelZiv
            // 
            this.labelZiv.AutoSize = true;
            this.labelZiv.Location = new System.Drawing.Point(100, 39);
            this.labelZiv.Name = "labelZiv";
            this.labelZiv.Size = new System.Drawing.Size(51, 18);
            this.labelZiv.TabIndex = 8;
            this.labelZiv.Text = "label7";
            this.labelZiv.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(133, 170);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(222, 110);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // listBoxDijagnoza
            // 
            this.listBoxDijagnoza.FormattingEnabled = true;
            this.listBoxDijagnoza.ItemHeight = 18;
            this.listBoxDijagnoza.Location = new System.Drawing.Point(191, 322);
            this.listBoxDijagnoza.Name = "listBoxDijagnoza";
            this.listBoxDijagnoza.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxDijagnoza.Size = new System.Drawing.Size(131, 130);
            this.listBoxDijagnoza.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Dijagnoza";
            // 
            // listBoxTerapija
            // 
            this.listBoxTerapija.FormattingEnabled = true;
            this.listBoxTerapija.ItemHeight = 18;
            this.listBoxTerapija.Location = new System.Drawing.Point(19, 322);
            this.listBoxTerapija.Name = "listBoxTerapija";
            this.listBoxTerapija.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxTerapija.Size = new System.Drawing.Size(130, 130);
            this.listBoxTerapija.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Terapija:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Napomena:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Postupak:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Životinja:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(767, 620);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Zatvori";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.Enabled = false;
            this.buttonDodaj.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDodaj.Location = new System.Drawing.Point(660, 621);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(101, 28);
            this.buttonDodaj.TabIndex = 4;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Visible = false;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePicker1.Location = new System.Drawing.Point(39, 616);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(236, 28);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // buttonIzvjestaj
            // 
            this.buttonIzvjestaj.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonIzvjestaj.Location = new System.Drawing.Point(325, 608);
            this.buttonIzvjestaj.Name = "buttonIzvjestaj";
            this.buttonIzvjestaj.Size = new System.Drawing.Size(126, 42);
            this.buttonIzvjestaj.TabIndex = 6;
            this.buttonIzvjestaj.Text = "Preuzimanje izvještaja";
            this.buttonIzvjestaj.UseVisualStyleBackColor = true;
            this.buttonIzvjestaj.Click += new System.EventHandler(this.buttonIzvjestaj_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 83);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DesktopForms.Properties.Resources.stethoscope;
            this.pictureBox1.Location = new System.Drawing.Point(10, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PovijestPregledaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 672);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonIzvjestaj);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonDodaj);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PovijestPregledaForm";
            this.Text = "VetMan - Povijest pregleda";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Postupak;
        private System.Windows.Forms.ColumnHeader Životinja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listBoxDijagnoza;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxTerapija;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPostupak;
        private System.Windows.Forms.Label labelZiv;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonIzvjestaj;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}