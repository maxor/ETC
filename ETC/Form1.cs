using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Первоначальное заполнение таблицы
            //AddDatatoDB dt = new AddDatatoDB();
            //dt.FillDB();
            InitializeComponent();
        }
        private void btnFill_Click(object sender, EventArgs e)
        {
            Task<TreeNode[]> t = new Task<TreeNode[]>(() =>
            {
                DataPresenter presenter = new DataPresenter();
                return presenter.FillData();
            });
            t.Start();
            trVBase.Nodes.AddRange(t.Result);
            if(trVBase.Nodes != null)
            {
                btnFill.Enabled = false;
            }
        }
    }
}
