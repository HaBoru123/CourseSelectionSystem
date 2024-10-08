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
    public partial class te_c : Form
    {
        public te_c()
        {
            InitializeComponent();
            populate();
        }
       // string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
        MySqlConnection con = new MySqlConnection("server = localhost; user = root; database = db_1; port = 3306; password =root");//mysql连接对象
        public void populate()
        {
            string sql = "select* from course;";
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            te_class_add te_Class_Add = new te_class_add();
            te_Class_Add.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //点击“修改课程学分”
        private void button2_Click(object sender, EventArgs e)
        {
            string cn = textBox3.Text.ToString();
            string cc = textBox2.Text.ToString();
            string sql = "call gengxin(" + cn + "," + cc + ");";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();//执行存储过程
            }
            catch (Exception ex)
            {
                message a = new message();
            a.showdialog("修改不合法！");
            }
            con.Close();
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
