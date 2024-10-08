using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db1
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
        }
        public void showdialog(string a)//输出不同的对话
        {
            label1.Text = a.ToString();
            this.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)//按确定按钮退出
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
