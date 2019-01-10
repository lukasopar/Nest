using DesktopFOrms.Presenters;
using DesktopFOrms.ViewInterfaces;
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

namespace DesktopFOrms.Views
{
    public partial class LijekoviForm : Form, ILijekoviView
    {
        public LijekoviForm()
        {
            InitializeComponent();

        }


        public LijekoviPresenter Presenter { private get; set; }

        public IList<string> LijekoviIme { get { return null; } set { this.listView1.Items.Add("KOKO"); } }
        public IList<string> LijekoviOpis { get { return null; } set { this.listView1.Items.Add("KOKO"); } }
    }
}
