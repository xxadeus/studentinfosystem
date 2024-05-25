namespace studentinfosystem
{
    public partial class FrmMain : Form
    {
        
        public FrmMain()
        {
            InitializeComponent();
        }
        private bool BringForm(Form frm)
        {
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(frm);
            frm.Show();
            return true;
        }

        private void ClearPanel()
        {
            if (panel2.HasChildren)
            {
                panel2.Controls.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e) //brings student adding screen
        {
            ClearPanel();
            FrmAddNew add = new FrmAddNew();
            BringForm(add);
        }

        private void button2_Click(object sender, EventArgs e) //brings all student records
        {
            ClearPanel();
            FrmShow show = new FrmShow();
            BringForm(show);
        }

        private void button3_Click(object sender, EventArgs e) //brings update screen so that we can update a record
        {
            ClearPanel();
            FrmUpdate update = new FrmUpdate();
            BringForm(update);
        }

        private void button4_Click(object sender, EventArgs e) //help or frequently asked questions
        {
            ClearPanel();
            FrmHelp help = new FrmHelp();
            BringForm(help);
        }
    }
}
