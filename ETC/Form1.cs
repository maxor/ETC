using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETC.Data;

namespace ETC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //AddDatatoDB dt = new AddDatatoDB();
            //dt.FillDB();
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            DataPresenter presenter = new DataPresenter();
            presenter.FillData(this.trVBase);
        }
    }
}
