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
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        MySqlConnection con = new MySqlConnection("server = localhost; user = root; database = db_1; port = 3306; password =root");//mysql连接对象
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string sqlstr = "select * from log ;";
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlstr, con);//创建一个数据的批量抓取
            MySqlCommandBuilder builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将搜索到的sda信息存到ds库中
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();


        }
    }
}
