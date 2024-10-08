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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
        //静态变量，为之后的绑定页面提供变量
        private static string username;
        public static string getusername()
        {
            return username;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)//退出的叉
        {
            Application.Exit();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //点击登录
        private void login_button_Click(object sender, EventArgs e)
        {
            username = log_username.Text.Trim();//取出用户名
            string password = log_code.Text.Trim();//获取密码

            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
            MySqlConnection con = new MySqlConnection(conStr);//mysql连接对象
            MySqlCommand cmd = null;//mysql命令对象


            if (radioButton1.Checked || radioButton2.Checked)
            {
                if (username.Equals("") || password.Equals(""))
                {
                    message m = new message();
                    m.showdialog("用户名或密码不能为空");
                    return;
                }
                if (radioButton1.Checked)//管理员登录
                {

                    con.Open();//打开数据库
                    //查询操作
                    string querystr = "select manid,mpassword from sysmanager where manid = '" + username + "' and mpassword = '" + password + "'";
                    cmd = new MySqlCommand(querystr, con);//创建命令
                    MySqlDataReader dr = cmd.ExecuteReader();//读出查询结果
                    if (dr.HasRows)//若查询结果不为空
                    {
                        //打开管理员界面
                        te_class te = new te_class();
                        te.Show();
                    }
                    else
                    {
                        message m = new message();
                        m.showdialog("用户名或密码不正确");
                        return;
                    }
                    con.Close();//关闭数据库
                }
                else
                {
                    con.Open();//打开数据库
                               //查询操作

                    string querystr = "select stuid,upassword from sysstudent where stuid = '" + username + "' and upassword = '" + password + "'";
                    cmd = new MySqlCommand(querystr, con);//创建命令
                    MySqlDataReader dr = cmd.ExecuteReader();//读出查询结果
                    if (dr.HasRows)//若查询结果不为空
                    {
                        //打开学生界面
                        @class se = new @class();
                        se.Show();
                    }

                    else
                    {
                        message m = new message();
                        m.showdialog("用户名或密码不正确");
                        return;
                    }
                    con.Close();//关闭数据库
                }
            }
        }

        //点击注册按钮
        private void registerbtn_Click(object sender, EventArgs e)
        {
            register Reg = new register();
            Reg.Show();//进入注册界面
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
