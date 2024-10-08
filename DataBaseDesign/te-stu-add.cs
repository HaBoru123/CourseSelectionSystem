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
    public partial class te_stu_add : Form
    {
        public te_stu_add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string new_sno = textBox2.Text.Trim();
            string new_sname = textBox3.Text.Trim();
            string new_grade = textBox4.Text.Trim();
            string new_dept = textBox5.Text.Trim();
            string new_scredit = textBox6.Text.Trim();
            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                string sql = "insert into student values('" + new_sno + "','" + new_sname + "','" + new_grade + "','" + new_dept + "','" + new_scredit + "');";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();//执行插入操作
                con.Close();


            }
            this.Close();
        }
    }
}
