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
    public partial class te_class : Form
    {
        public te_class()
        {
            InitializeComponent();
            populate();
        }
        private void populate()
        {
            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            MySqlConnection con = new MySqlConnection(conStr);//mysql连接对象

            con.Open();
            string sqlstr = "select * from student;";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlstr, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Dispose();//释放
        }

       

        //搜索学生
        static string searchsql;
        private void button1_Click(object sender, EventArgs e)
        {
            //查询方式
            string way = comboBox1.Text.Trim();
            //输入的信息
            string infor = textBox3.Text.Trim();
            
            if (way.Equals("按学号查询"))
            {
                searchsql = "select * from student where sno='" + infor + "';";
            }
            else if (way.Equals("按姓名查询"))
            {
                searchsql = "select * from student where sname='" + infor + "';";
            }
            else
            {
                searchsql = "select * from course where cname like '" + infor + "%' or cno like '" + infor + "%'";
            }

            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter(searchsql, con);//创建一个数据的批量抓取
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
                var ds = new DataSet();//创建一个虚拟数据库
                sda.Fill(ds);//将搜索到的sda信息存到ds库中
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
        }

        //添加学生
        private void button2_Click(object sender, EventArgs e)
        {
            te_stu_add te_Stu_Add = new te_stu_add();
            te_Stu_Add.Show();
        }
        public string dlt_sno()
        {
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("select* from student;", con);//创建一个数据的批量抓取
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
                var ds = new DataSet();//创建一个虚拟数据库
                sda.Fill(ds);//将搜索到的sda信息存到ds库中
               dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            //行数
            int a =dataGridView1.CurrentCell.RowIndex;
            string s = dataGridView1.Rows[a].Cells[0].Value.ToString().Trim();
            return s;
        }
        
        //删除学生
        private void button3_Click(object sender, EventArgs e)
        {
            te_stu_delete te_Stu_Delete = new te_stu_delete(dataGridView1.CurrentRow.Cells[0].Value.ToString());//用选中行创建下一个视图
            te_Stu_Delete.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            te_c a = new te_c();
            a.Show();
        }
    }
}
