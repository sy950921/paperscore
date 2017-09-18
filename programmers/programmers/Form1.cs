using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace programmers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            pictureBox1.Image = Image.FromFile(@"C:\Users\孟2K\Pictures\北邮.jpg");//动态添加图片  
=======
            //-----------------------------------------------------------------------------------------------------------------
            //修改文件路径
            pictureBox1.Image = Image.FromFile(@"C:\SongYue\大学学习\大四暑假\阅卷系统\北邮.jpg");//动态添加图片，改成相应路径  
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;  //是图片的大小适应控件PictureBox的大小  
        }

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
=======
            //-------------------------------------------------------------------------------------------------------------------
            //Data Source = localhost; Initial Catalog = cms_keleyi_com; Integrated Security = True; MultipleActiveResultSets = True
            string str = @"Data Source=.\MSSQLSERVER2012;Initial Catalog=student examination information;Integrated Security=True; MultipleActiveResultSets = True";
            //此处我的电脑有两个版本的SQL，给这两个数据库的登录用户名不同，因此语句里使用.\MSSQLSERVER2012，如果一个数据库就用上面注释的一行
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "Select * from login where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);//SqlCommand对象允许你指定在数据库上执行的操作的类型。  
            cmd.CommandType = CommandType.Text;
            //这就是告诉cmd执行的sql是你赋给CommandText的值里写出的sql语句，  
            //如果是存储过程的话cmd.CommandType = CommandType.StoredProcedure;  
            //然后CommandText='存储过程的名字'，这就是告诉cmd执行的是存储过程，  
            //存储过程的名字就是CommandText的值  

            //CommandType是SqlCommand对象的一个属性，用于指定执行动作的形式，  
            //它告诉.net接下来执行的是一个文本(text)、  
            //存储过程(StoredProcedure)还是表名称(TableDirect).  
            //而CommandType是一个枚举类型。  
            //有三个值：text、StoredProcedure、TableDirect  
            //用于表示SqlCommand对象CommandType的执行形式。  

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                MessageBox.Show("登陆成功!", "【成功】");

                this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
                this.Close();    //关闭登录窗口
            }
            else
            {
                MessageBox.Show("用户名密码匹配错误，登录失败", "【警告】"); textBox2.Text = ""; textBox1.Text = "";
                //label3在界面没有显示，因为我设置了显示为一个空格，这个可以自己随意在登陆界面的某个位置添加一个label控件用以显示提示信息  
                return;
            }
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
