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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String str = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            axAcroPDF1.src = str;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form1 = new Form4();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select 班级,ses.课程号,课程名,ses.学号,学生姓名,文件名 from ses,course,student where course.课程号 = ses.课程号 and student.学号 = ses.学号", conn);
            DataSet dds = new DataSet();
            sqlDap.Fill(dds);
            DataTable _table = dds.Tables[0];
            int count = _table.Rows.Count;
            dataGridView1.DataSource = _table;
            conn.Close();
            //dataGridView1.DataBind();//在网上找的方法中有这一句，在这里这一句可以不要，不然报错  
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            //string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();  

            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["学号"] == null) return;//可以进行快速监视   
            string bd = Convert.ToString(row["学号"]); string tp = Convert.ToString(row["课程号"]);
            string selectsql = "delete from ses where 学号="+ bd +" and 课程号 ="+ tp+ "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;  
            //sdr = cmd.ExecuteReader();  
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）  
            if (ret == -1)
            {
                MessageBox.Show("删除失败！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");
            }
            conn.Close();
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }
    }
}
