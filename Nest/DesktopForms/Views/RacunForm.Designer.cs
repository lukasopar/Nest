namespace DesktopFOrms.Views
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
            this.groupBoxPostupci = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxLijekovi.SuspendLayout();
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
            this.groupBoxLijekovi.Controls.Add(this.button1);
            this.groupBoxLijekovi.Controls.Add(this.listView1);
            this.groupBoxLijekovi.Location = new System.Drawing.Point(29, 91);
            this.groupBoxLijekovi.Name = "groupBoxLijekovi";
            this.groupBoxLijekovi.Size = new System.Drawing.Size(380, 276);
            this.groupBoxLijekovi.TabIndex = 1;
            this.groupBoxLijekovi.TabStop = false;
            this.groupBoxLijekovi.Text = "Lijekovi";
            // 
            // groupBoxPostupci
            // 
            this.groupBoxPostupci.Location = new System.Drawing.Point(435, 96);
            this.groupBoxPostupci.Name = "groupBoxPostupci";
            this.groupBoxPostupci.Size = new System.Drawing.Size(349, 270);
            this.groupBoxPostupci.TabIndex = 2;
            this.groupBoxPostupci.TabStop = false;
            this.groupBoxPostupci.Text = "Postupci";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 43);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(185, 213);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lijek";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cijena";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(219, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RacunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxPostupci);
            this.Controls.Add(this.groupBoxLijekovi);
            this.Controls.Add(this.label1);
            this.Name = "RacunForm";
            this.Text = "RacunForm";
            this.groupBoxLijekovi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxLijekovi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBoxPostupci;
    }
}