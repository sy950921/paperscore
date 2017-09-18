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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“student_examination_informationDataSet6.classNo”中。您可以根据需要移动或删除它。
            this.classNoTableAdapter.Fill(this.student_examination_informationDataSet6.classNo);
            // TODO: 这行代码将数据加载到表“student_examination_informationDataSet5.courseNo”中。您可以根据需要移动或删除它。
            this.courseNoTableAdapter.Fill(this.student_examination_informationDataSet5.courseNo);
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            //选择文件后，用openFileDialog1的FileName属性获取文件的绝对路径
            this.textBox1.Text = this.openFileDialog1.FileName;
            //this.textBox2.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            //this.textBox2.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            axAcroPDF1.src = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "insert into file2 (班级,课程号,附件文件) values('" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "')";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            conn.Close();
            MessageBox.Show("添加成功!", "【成功】"); textBox1.Text = "";  comboBox2.Text = ""; comboBox1.Text = "";
            //UpdataForm udform = new UpdataForm();  
            // this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
