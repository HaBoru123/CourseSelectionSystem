using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//可以在程序中使用sql语句
namespace db1
{
    public partial class te_class_add : Form
    {
        public te_class_add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; user = root; database = db_1; port = 3306; password =root");//mysql连接对象
            string new_cno = textBox3.Text.Trim();
            string new_came = textBox2.Text.Trim();
            string new_ccredit = textBox4.Text.Trim();
            string new_cweeks = textBox7.Text.Trim();
            string new_clessons = textBox6.Text.Trim();
            string new_period = textBox5.Text.Trim();
            string sqladd = "insert into course values ('" + new_cno + "','" + new_came + "','" + new_ccredit + "','" + new_cweeks + "','" + new_clessons + "','" + new_period + "')";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sqladd, con);
            
            try
            {
                cmd.ExecuteNonQuery();//执行插入操作
                con.Close();
                message a = new message();
                a.showdialog("添加课程成功！");
                
            }
            catch
            {
                message a = new message();
                a.showdialog("输入信息不合法！");
            }
        }
    }
}
