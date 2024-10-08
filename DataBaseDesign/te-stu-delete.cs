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
    public partial class te_stu_delete : Form
    {
        public te_stu_delete()
        {
            InitializeComponent();
            populate();
        }
        
        public te_stu_delete(string s)
        {
            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            MySqlConnection con = new MySqlConnection(conStr);
            con.Open();
            string sqlstr = "select * from v1 where sno='" + s + "';";//从视图上提取数据
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlstr, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            InitializeComponent();
        }

        //private void DeleteTip_Load(object sender, EventArgs e)
        //{
        //    // TODO: 这行代码将数据加载到表“curricula_variable_systemDataSet13.SC”中。您可以根据需要移动或删除它。
        //    //this.sCTableAdapter.Fill(this.curricula_variable_systemDataSet13.SC);
        //    string sno = dataGridView1.SelectedRows[0].ToString();
        //    string conn = "server = localhost; user = root; database = db_1; port = 3306; password =root";
        //    MySqlConnection sqlConnection = new MySqlConnection(conn);
        //    sqlConnection.Open();

        //    string sql = "select * from SC where Sno = '" + sno + "'";
        //    MySqlCommand sqlCommand = new MySqlCommand(sql, sqlConnection);
        //    MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //    BindingSource bindingSource = new BindingSource();  //绑定 
        //    bindingSource.DataSource = sqlDataReader;
        //    dataGridView1.DataSource = bindingSource;
        //}
        private void populate()
        {
            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            MySqlConnection con = new MySqlConnection(conStr);//mysql连接对象

            con.Open();
            string sqlstr = "select * from v1 where sno=1";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlstr, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                string sql = "delete from student  where sno='" + dataGridView1.SelectedRows[0].ToString() + "';";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();//执行删除操作
                con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
