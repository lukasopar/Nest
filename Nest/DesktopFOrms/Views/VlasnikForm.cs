using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopForms.Views
{
    public partial class VlasnikForm : Form, IVlasnikView
    {
    
        public VlasnikPresenter Presenter { private get; set; }

        
        public VlasnikForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            var vlasnik = new Vlasnik();
            if (textBox1.Text.Equals(""))
            {
                label7.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label7.Text = " ";
            if (textBox2.Text.Equals(""))
            {
                label8.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label8.Text = " ";
            if (textBox3.Text.Equals(""))
            {
                label9.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label9.Text = " ";
            if (textBox4.Text.Equals(""))
            {
                label10.Text = "Ovo polje je obavezno";
                valid = false;
            }
            else label10.Text = " ";
            if (!valid) return;

            vlasnik.Ime = textBox1.Text;
            vlasnik.Prezime = textBox2.Text;
            vlasnik.KorisnickoIme = textBox3.Text;
            vlasnik.Lozinka = textBox4.Text;
            vlasnik.DatumRod = dateTimePicker1.Value;
            
            Presenter.registrirajVlasnika(vlasnik);

            this.Close();

            GlavniForm form = new GlavniForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            GlavniForm form = new GlavniForm();
            form.Show();
        }
    }
}
