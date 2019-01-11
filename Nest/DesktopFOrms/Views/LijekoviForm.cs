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
        public IList<Tuple<string, string>> Lijekovi
        {
            get {
                var l = new List<Tuple<string, string>>();
                foreach(var item in listView1.Items)
                {
                    var tup = new Tuple<string, string>(item.ToString(), "test");
                    l.Add(tup);

                }
                return l;
            }
            set
            {
                foreach (var tup in value)
                {
                    ListViewItem it = new ListViewItem(tup.Item1);
                    it.SubItems.Add(tup.Item2);
                    listView1.Items.Add(it);
                }
            }
        }
        public IList<string> LijekoviIme { get { return null; } set { return; } }
        public IList<string> LijekoviOpis { get { return null; } set { return; } }
    }
}
