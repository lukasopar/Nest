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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostupakForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPovijest = new System.Windows.Forms.Button();
            this.buttonOdaberi = new System.Windows.Forms.Button();
            this.labelZivotinja = new System.Windows.Forms.Label();
            this.labelVlasnik = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOpisPostupka = new System.Windows.Forms.TextBox();
            this.labelCIjena = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxVrstePostupaka = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonObrisiBolest = new System.Windows.Forms.Button();
            this.buttonDodajBolest = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelUpozorenje = new System.Windows.Forms.Label();
            this.buttonObrisiLijek = new System.Windows.Forms.Button();
            this.buttonLijek = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listViewBolesti = new System.Windows.Forms.ListView();
            this.listViewLijekovi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(75, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Novi postupak";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonPovijest);
            this.groupBox1.Controls.Add(this.buttonOdaberi);
            this.groupBox1.Controls.Add(this.labelZivotinja);
            this.groupBox1.Controls.Add(this.labelVlasnik);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(30, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Životinja";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(452, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(280, 68);
            this.textBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Napomena";
            // 
            // buttonPovijest
            // 
            this.buttonPovijest.Enabled = false;
            this.buttonPovijest.Location = new System.Drawing.Point(158, 111);
            this.buttonPovijest.Name = "buttonPovijest";
            this.buttonPovijest.Size = new System.Drawing.Size(139, 32);
            this.buttonPovijest.TabIndex = 5;
            this.buttonPovijest.Text = "Povijest";
            this.buttonPovijest.UseVisualStyleBackColor = true;
            this.buttonPovijest.Click += new System.EventHandler(this.buttonPovijest_Click);
            // 
            // buttonOdaberi
            // 
            this.buttonOdaberi.Location = new System.Drawing.Point(9, 111);
            this.buttonOdaberi.Name = "buttonOdaberi";
            this.buttonOdaberi.Size = new System.Drawing.Size(134, 32);
            this.buttonOdaberi.TabIndex = 4;
            this.buttonOdaberi.Text = "Odaberi ";
            this.buttonOdaberi.UseVisualStyleBackColor = true;
            this.buttonOdaberi.Click += new System.EventHandler(this.buttonOdaberi_Click);
            // 
            // labelZivotinja
            // 
            this.labelZivotinja.AutoSize = true;
            this.labelZivotinja.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelZivotinja.Location = new System.Drawing.Point(117, 65);
            this.labelZivotinja.Name = "labelZivotinja";
            this.labelZivotinja.Size = new System.Drawing.Size(168, 17);
            this.labelZivotinja.TabIndex = 3;
            this.labelZivotinja.Text = "Niste odabrali životinju";
            // 
            // labelVlasnik
            // 
            this.labelVlasnik.AutoSize = true;
            this.labelVlasnik.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelVlasnik.Location = new System.Drawing.Point(117, 33);
            this.labelVlasnik.Name = "labelVlasnik";
            this.labelVlasnik.Size = new System.Drawing.Size(168, 17);
            this.labelVlasnik.TabIndex = 2;
            this.labelVlasnik.Text = "Niste odabrali životinju";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ime životinje";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vlasnik";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxOpisPostupka);
            this.groupBox2.Controls.Add(this.labelCIjena);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxVrstePostupaka);
            this.groupBox2.Location = new System.Drawing.Point(30, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vrsta postupka";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Opis";
            // 
            // textBoxOpisPostupka
            // 
            this.textBoxOpisPostupka.Location = new System.Drawing.Point(446, 18);
            this.textBoxOpisPostupka.Multiline = true;
            this.textBoxOpisPostupka.Name = "textBoxOpisPostupka";
            this.textBoxOpisPostupka.ReadOnly = true;
            this.textBoxOpisPostupka.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOpisPostupka.Size = new System.Drawing.Size(268, 39);
            this.textBoxOpisPostupka.TabIndex = 3;
            // 
            // labelCIjena
            // 
            this.labelCIjena.AutoSize = true;
            this.labelCIjena.Location = new System.Drawing.Point(301, 24);
            this.labelCIjena.Name = "labelCIjena";
            this.labelCIjena.Size = new System.Drawing.Size(48, 17);
            this.labelCIjena.TabIndex = 2;
            this.labelCIjena.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cijena";
            // 
            // comboBoxVrstePostupaka
            // 
            this.comboBoxVrstePostupaka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVrstePostupaka.FormattingEnabled = true;
            this.comboBoxVrstePostupaka.Location = new System.Drawing.Point(9, 21);
            this.comboBoxVrstePostupaka.Name = "comboBoxVrstePostupaka";
            this.comboBoxVrstePostupaka.Size = new System.Drawing.Size(197, 24);
            this.comboBoxVrstePostupaka.TabIndex = 0;
            this.comboBoxVrstePostupaka.SelectedIndexChanged += new System.EventHandler(this.comboBoxVrstePostupaka_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewBolesti);
            this.groupBox3.Controls.Add(this.buttonObrisiBolest);
            this.groupBox3.Controls.Add(this.buttonDodajBolest);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(30, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(363, 173);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dijagnoza";
            // 
            // buttonObrisiBolest
            // 
            this.buttonObrisiBolest.Enabled = false;
            this.buttonObrisiBolest.Location = new System.Drawing.Point(206, 105);
            this.buttonObrisiBolest.Name = "buttonObrisiBolest";
            this.buttonObrisiBolest.Size = new System.Drawing.Size(119, 34);
            this.buttonObrisiBolest.TabIndex = 2;
            this.buttonObrisiBolest.Text = "Obriši";
            this.buttonObrisiBolest.UseVisualStyleBackColor = true;
            this.buttonObrisiBolest.Click += new System.EventHandler(this.buttonObrisiBolest_Click);
            // 
            // buttonDodajBolest
            // 
            this.buttonDodajBolest.Location = new System.Drawing.Point(206, 56);
            this.buttonDodajBolest.Name = "buttonDodajBolest";
            this.buttonDodajBolest.Size = new System.Drawing.Size(119, 35);
            this.buttonDodajBolest.TabIndex = 1;
            this.buttonDodajBolest.Text = "Dodaj";
            this.buttonDodajBolest.UseVisualStyleBackColor = true;
            this.buttonDodajBolest.Click += new System.EventHandler(this.buttonDodajBolest_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listViewLijekovi);
            this.groupBox4.Controls.Add(this.labelUpozorenje);
            this.groupBox4.Controls.Add(this.buttonObrisiLijek);
            this.groupBox4.Controls.Add(this.buttonLijek);
            this.groupBox4.Location = new System.Drawing.Point(399, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(369, 173);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Terapija";
            // 
            // labelUpozorenje
            // 
            this.labelUpozorenje.AutoSize = true;
            this.labelUpozorenje.ForeColor = System.Drawing.Color.Red;
            this.labelUpozorenje.Location = new System.Drawing.Point(6, 153);
            this.labelUpozorenje.Name = "labelUpozorenje";
            this.labelUpozorenje.Size = new System.Drawing.Size(250, 17);
            this.labelUpozorenje.TabIndex = 3;
            this.labelUpozorenje.Text = "Neki lijekovi međusobno reagiraju!";
            this.labelUpozorenje.Visible = false;
            // 
            // buttonObrisiLijek
            // 
            this.buttonObrisiLijek.Enabled = false;
            this.buttonObrisiLijek.Location = new System.Drawing.Point(212, 105);
            this.buttonObrisiLijek.Name = "buttonObrisiLijek";
            this.buttonObrisiLijek.Size = new System.Drawing.Size(119, 34);
            this.buttonObrisiLijek.TabIndex = 2;
            this.buttonObrisiLijek.Text = "Obriši";
            this.buttonObrisiLijek.UseVisualStyleBackColor = true;
            this.buttonObrisiLijek.Click += new System.EventHandler(this.buttonObrisiLijek_Click);
            // 
            // buttonLijek
            // 
            this.buttonLijek.Location = new System.Drawing.Point(212, 56);
            this.buttonLijek.Name = "buttonLijek";
            this.buttonLijek.Size = new System.Drawing.Size(119, 34);
            this.buttonLijek.TabIndex = 1;
            this.buttonLijek.Text = "Dodaj";
            this.buttonLijek.UseVisualStyleBackColor = true;
            this.buttonLijek.Click += new System.EventHandler(this.buttonLijek_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox5.Location = new System.Drawing.Point(30, 523);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(738, 135);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Napomena";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(714, 103);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(508, 682);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Spremi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 81);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DesktopForms.Properties.Resources.stethoscope;
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(645, 682);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "Zatvori";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listViewBolesti
            // 
            this.listViewBolesti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewBolesti.FullRowSelect = true;
            this.listViewBolesti.GridLines = true;
            this.listViewBolesti.Location = new System.Drawing.Point(14, 40);
            this.listViewBolesti.MultiSelect = false;
            this.listViewBolesti.Name = "listViewBolesti";
            this.listViewBolesti.Size = new System.Drawing.Size(166, 113);
            this.listViewBolesti.TabIndex = 3;
            this.listViewBolesti.UseCompatibleStateImageBehavior = false;
            this.listViewBolesti.View = System.Windows.Forms.View.Details;
            // 
            // listViewLijekovi
            // 
            this.listViewLijekovi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewLijekovi.FullRowSelect = true;
            this.listViewLijekovi.GridLines = true;
            this.listViewLijekovi.Location = new System.Drawing.Point(9, 40);
            this.listViewLijekovi.MultiSelect = false;
            this.listViewLijekovi.Name = "listViewLijekovi";
            this.listViewLijekovi.Size = new System.Drawing.Size(172, 113);
            this.listViewLijekovi.TabIndex = 4;
            this.listViewLijekovi.UseCompatibleStateImageBehavior = false;
            this.listViewLijekovi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bolest";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lijek";
            // 
            // PostupakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 756);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PostupakForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VetMan - novi postupak";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxVrstePostupaka;
        private System.Windows.Forms.Label labelCIjena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOpisPostupka;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonObrisiBolest;
        private System.Windows.Forms.Button buttonDodajBolest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonObrisiLijek;
        private System.Windows.Forms.Button buttonLijek;
        private System.Windows.Forms.Label labelUpozorenje;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listViewBolesti;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewLijekovi;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}