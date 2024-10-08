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
    public partial class @class : Form
    {
        public @class()
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
            string sqlstr = "select * from course ;";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlstr, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void textBox3_TextChanged(object sender, EventArgs e)//课名输入
        {

        }
        //按课名查询按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //获取课名
            string cid = textBox3.Text.Trim();
          
            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();
                string sqlsearch_by_no = "select * from course where cno=" + cid + ";";
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlsearch_by_no, con);//创建一个数据的批量抓取
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
                var ds = new DataSet();//创建一个虚拟数据库
                sda.Fill(ds);//将搜索到的sda信息存到ds库中
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }


        }

        private void textBox4_TextChanged(object sender, EventArgs e)//课序号输入
        {

        }
        //按课序号查询按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //获取课名
            string cclass = textBox4.Text.Trim();
            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                con.Open();
                string sqlsearch_by_name = "select * from course where cname='" + cclass + "';";
                MySqlDataAdapter sda = new MySqlDataAdapter(sqlsearch_by_name, con);//创建一个数据的批量抓取
                MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
                var ds = new DataSet();//创建一个虚拟数据库
                sda.Fill(ds);//将搜索到的sda信息存到ds库中
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void class_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            stu_addclass stu_Addclass = new stu_addclass();
            stu_Addclass.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            stu_deleteclass stu_Deleteclass = new stu_deleteclass();
            stu_Deleteclass.Show();
        }
    }
}
