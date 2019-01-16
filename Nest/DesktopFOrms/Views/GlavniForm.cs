using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using System;
using System.Windows.Forms;

namespace DesktopForms.Views
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

            view.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();

            VlasnikForm view = new VlasnikForm();

            var presenter = new VlasnikPresenter(view, new VlasnikRepository());

            view.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();

            ZivotinjaForm view = new ZivotinjaForm();

            var presenter = new ZivotinjaPresenter(view, new ZivotinjaRepository(), new VlasnikRepository());

            view.Show();
        }
    }
}
