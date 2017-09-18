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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“student_examination_informationDataSet3.file2”中。您可以根据需要移动或删除它。
            this.file2TableAdapter.Fill(this.student_examination_informationDataSet3.file2);
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }

        private void button3_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
=======
            string str = @"Data Source=.\MSSQLSERVER2012;Initial catalog=student examination information;integrated Security=True";
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            SqlConnection conn = new SqlConnection(str);
            conn.Open();

            SqlDataAdapter sqlDap = new SqlDataAdapter("Select 班级, file2.课程号, 课程名, 附件文件 from file2,course where file2.课程号=course.课程号", conn);
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
<<<<<<< HEAD
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
=======
            string str = @"Data Source=.\MSSQLSERVER2012;Initial catalog=student examination information;integrated Security=True";
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            //string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();  

            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["课程号"] == null) return;//可以进行快速监视   
            string bd = Convert.ToString(row["课程号"]); string tp = Convert.ToString(row["班级"]);
            string selectsql = "delete from file2 where 课程号 = " + bd + " and 班级 ="+ tp +"";
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

        private void button4_Click(object sender, EventArgs e)
        {
            String str = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            axAcroPDF1.src = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form2 = new Form5();
            form2.Show();
        }
    }
}
