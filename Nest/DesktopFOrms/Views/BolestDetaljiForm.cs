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
    public partial class BolestDetaljiForm : Form, IBolestiDetaljiView
    {
        public BolestDetaljiForm()
        {
            InitializeComponent();
        }

        public Bolest Bolest { get => (Bolest)label2.Tag;
            set
            {
                label2.Text = value.Naziv;
                label2.Tag = value;

                if (value.Opis == null)
                    textBox1.Text = "Nema opisa.";
                else
                    textBox1.Text = value.Opis;
                foreach(var lijek in Bolest.Lijeks)
                {
                    var item = new ListViewItem(lijek.Naziv);
                    item.Tag = lijek;
                    listView1.Items.Add(item);
                }
            }
        }
        public BolestiPresenter Presenter { private get; set; }
    }
}
