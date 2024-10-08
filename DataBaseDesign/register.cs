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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text.Trim();//取出用户名
            string password = textBox4.Text.Trim();//获取密码

            //链接数据库(链接字符串)
            string conStr = "server = localhost; user = root; database = db_1; port = 3306; password =root";
       

            if (radioButton1.Checked || radioButton2.Checked)
            {
                if (radioButton1.Checked)//注册管理员
                {
                    MySqlDataReader dr;
                    using (MySqlConnection con = new MySqlConnection(conStr))
                    {
                        string querystr = "select manid,mpassword from sysmanager where manid = '" + username + "'";
                        MySqlCommand cmd = new MySqlCommand(querystr, con);
                        con.Open();
                        dr = cmd.ExecuteReader();//读出查询结果
                        if(dr.HasRows)
                        {
                            message m = new message();
                            m.showdialog("该用户已存在");
                            return;
                        }
                        con.Close();
                    }
                    if (textBox2.Text.Equals("") || textBox4.Text.Equals(""))
                    {
                        message m = new message();
                        m.showdialog("用户名或密码不能为空");
                        return;
                    }
                    else //原表格中没有
                    {
                        using (MySqlConnection con = new MySqlConnection(conStr))
                        {
                            string sql = "insert into sysmanager(manid,mpassword) values('" + username + "','" + password + "');";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            con.Open();
                            cmd.ExecuteNonQuery();//执行插入操作
                            con.Close();
                        }
                        message m = new message();
                        m.showdialog("注册成功");
                        return;
                    }
                    
                }

                else
                {
                   
                    using (MySqlConnection con = new MySqlConnection(conStr))
                    {
                        string querystr = "select stuid,upassword from sysstudent where stuid=  '" + username + "'";
                       //string querystr = "select stuid,upassword from sysstudent where stuid = 1;";
                        MySqlCommand cmd = new MySqlCommand(querystr, con);
                        con.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();//读出查询结果
                       
                        if (dr.HasRows)
                        {
                            message m = new message();
                            m.showdialog("该用户已存在");
                            
                            return;
                        }
                        con.Close();
                    }
                    if (textBox2.Text.Equals("") || textBox4.Text.Equals(""))
                    {
                        message m = new message();
                        m.showdialog("用户名或密码不能为空");
                        return;
                    }
                   
                    else //原表格中没有
                    {
                        using (MySqlConnection con = new MySqlConnection(conStr))
                        {
                            string sql = "insert into sysstudent(stuid,upassword) values('" + username + "','" + password + "');";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            con.Open();
                            cmd.ExecuteNonQuery();//执行插入操作
                            con.Close();
                        }
                        message m = new message();
                        m.showdialog("注册成功");
                       // this.Close();//退出
                        return;
                    }
                    
                }

            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
