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
    public partial class stu_addclass : Form
    {
        public stu_addclass()
        {
            InitializeComponent();
            populate();
           
        }

      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        MySqlConnection con = new MySqlConnection("server = localhost; user = root; database = db_1; port = 3306; password =root");//mysql连接对象
        public void populate()
        {
            //链接数据库(链接字符串)
            con.Open();
            string sqlstr = "select * from course where cno not in(select cno from sc where sno ='" + Login.getusername() + "');";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlstr, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

           
        }
        //搜索课程
        string searchsql;
        private void button1_Click(object sender, EventArgs e)
        {
            

            //查询方式
            string way = comboBox1.Text.Trim();
            //输入的信息
            string infor = textBox3.Text.Trim();

            if (way.Equals("按课序号查询"))
            {
                searchsql = "select * from course where cno not in (select cno from sc where sno='" + Login.getusername() + " ') and cno='" + infor + "';";
            }
            else if (way.Equals("按课名查询"))
            {
                searchsql = "select * from course where cno not in (select cno from sc where sno = '" + Login.getusername() + " ') and cname='" + infor + "';";
            }
            else
            {
                searchsql = "select * from course where cno not in (select cno from sc where sno = '" + Login.getusername() + " ') and cname like '" + infor + "%' or cno like '" + infor + "%'";
            }
            con.Open();
            string sqlstr = "select * from course where cno not in(select cno from sc where sno ='" + Login.getusername() + "');";
            MySqlDataAdapter sda = new MySqlDataAdapter(searchsql, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
           

        }


        
        
        //添加课程
        private void button3_Click(object sender, EventArgs e)
        {
            
            con.Open();
            int a = dataGridView1.CurrentCell.RowIndex;

            string select_cno = dataGridView1.Rows[a].Cells[0].Value.ToString();
            string sql = "insert into sc values('" + Login.getusername() + "','" + select_cno + "');";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                //cmd.ExecuteNonQuery();
                //con.Close();
                message m = new message();
                m.showdialog("添加成功");
                con.Close();

                return;
            }
            catch
            {
                message m = new message();
                m.showdialog("课程冲突");
                con.Close();
                
                return;
           }
            
        }


        

        private void label2_Click(object sender, EventArgs e)
        {
            @class @class = new @class();
            @class.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //stu_deleteclass stu_Deleteclass = new stu_deleteclass();
            //stu_Deleteclass.Show();
        } 
    }
}
