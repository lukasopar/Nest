using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
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
    public partial class PrijavaForm : Form, IPrijavaView
    {
        public PrijavaForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        public string KorisnickoIme { get => textBoxUsername.Text; set => textBoxUsername.Text = value; }
        public string Lozinka { get => textBoxPassword.Text; set => textBoxPassword.Text = value; }
        public PrijavaPresenter Presenter { private get; set; }
        public bool PogrešnaPrijava { get => labelKrivaPrijava.Visible; set => labelKrivaPrijava.Visible = value; }
        public void CloseForm() => Close();
        private void button1_Click(object sender, EventArgs e){
            Cursor.Current = Cursors.WaitCursor;
            Presenter.PokusajPrijave();
            Cursor.Current = Cursors.Arrow;
        }


    }
}
