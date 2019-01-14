using DatabaseBootstrap.Repositories;
using DesktopFOrms.Presenters;
using System;
using System.Windows.Forms;

namespace DesktopFOrms.Views
{
    public partial class GlavniForm : Form
    {
        public GlavniForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();

            LijekoviForm view = new LijekoviForm();

            var presenter = new LijekoviPresenter(view, new LijekoviRepository());

            this.Close();

            view.Show();
        }
    }
}
