namespace programmers
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.courseNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_examination_informationDataSet = new programmers.student_examination_informationDataSet();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.classNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_examination_informationDataSet1 = new programmers.student_examination_informationDataSet1();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.courseNoTableAdapter = new programmers.student_examination_informationDataSetTableAdapters.courseNoTableAdapter();
            this.classNoTableAdapter = new programmers.student_examination_informationDataSet1TableAdapters.classNoTableAdapter();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
<<<<<<< HEAD
=======
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            ((System.ComponentModel.ISupportInitialize)(this.courseNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
<<<<<<< HEAD
=======
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(60, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
=======
            this.label1.Location = new System.Drawing.Point(40, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.label1.TabIndex = 0;
            this.label1.Text = "课程号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(60, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
=======
            this.label2.Location = new System.Drawing.Point(40, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.label2.TabIndex = 1;
            this.label2.Text = "班级号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
<<<<<<< HEAD
            this.label3.Location = new System.Drawing.Point(78, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
=======
            this.label3.Location = new System.Drawing.Point(52, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.label3.TabIndex = 2;
            this.label3.Text = "学号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
<<<<<<< HEAD
            this.label4.Location = new System.Drawing.Point(47, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
=======
            this.label4.Location = new System.Drawing.Point(31, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.label4.TabIndex = 3;
            this.label4.Text = "文件位置：";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.courseNoBindingSource;
            this.comboBox1.DisplayMember = "课程号";
            this.comboBox1.FormattingEnabled = true;
<<<<<<< HEAD
            this.comboBox1.Location = new System.Drawing.Point(168, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 26);
=======
            this.comboBox1.Location = new System.Drawing.Point(112, 30);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(125, 20);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // courseNoBindingSource
            // 
            this.courseNoBindingSource.DataMember = "courseNo";
            this.courseNoBindingSource.DataSource = this.student_examination_informationDataSet;
            // 
            // student_examination_informationDataSet
            // 
            this.student_examination_informationDataSet.DataSetName = "student_examination_informationDataSet";
            this.student_examination_informationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.classNoBindingSource;
            this.comboBox2.DisplayMember = "班级号";
            this.comboBox2.FormattingEnabled = true;
<<<<<<< HEAD
            this.comboBox2.Location = new System.Drawing.Point(168, 95);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(186, 26);
=======
            this.comboBox2.Location = new System.Drawing.Point(112, 63);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(125, 20);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // classNoBindingSource
            // 
            this.classNoBindingSource.DataMember = "classNo";
            this.classNoBindingSource.DataSource = this.student_examination_informationDataSet1;
            // 
            // student_examination_informationDataSet1
            // 
            this.student_examination_informationDataSet1.DataSetName = "student_examination_informationDataSet1";
            this.student_examination_informationDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
<<<<<<< HEAD
            this.textBox1.Location = new System.Drawing.Point(168, 160);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 28);
=======
            this.textBox1.Location = new System.Drawing.Point(112, 101);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
<<<<<<< HEAD
            this.textBox2.Location = new System.Drawing.Point(168, 209);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 28);
=======
            this.textBox2.Location = new System.Drawing.Point(112, 139);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(125, 21);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button1
            // 
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(257, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 40);
=======
            this.button1.Location = new System.Drawing.Point(176, 234);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 27);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.button1.TabIndex = 8;
            this.button1.Text = "添加试卷";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
<<<<<<< HEAD
            this.button2.Location = new System.Drawing.Point(279, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 40);
=======
            this.button2.Location = new System.Drawing.Point(186, 173);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 27);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.button2.TabIndex = 9;
            this.button2.Text = "浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // courseNoTableAdapter
            // 
            this.courseNoTableAdapter.ClearBeforeFill = true;
            // 
            // classNoTableAdapter
            // 
            this.classNoTableAdapter.ClearBeforeFill = true;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(380, -17);
<<<<<<< HEAD
=======
            this.axAcroPDF1.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(653, 650);
            this.axAcroPDF1.TabIndex = 10;
            this.axAcroPDF1.OnError += new System.EventHandler(this.axAcroPDF1_OnError);
            // 
<<<<<<< HEAD
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 645);
=======
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(18, 290);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(129, 128);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // imageBox2
            // 
            this.imageBox2.Location = new System.Drawing.Point(186, 290);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(150, 128);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 430);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.imageBox1);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
<<<<<<< HEAD
=======
            this.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.Name = "Form2";
            this.Text = "插入试卷";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
<<<<<<< HEAD
=======
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private student_examination_informationDataSet student_examination_informationDataSet;
        private System.Windows.Forms.BindingSource courseNoBindingSource;
        private student_examination_informationDataSetTableAdapters.courseNoTableAdapter courseNoTableAdapter;
        private student_examination_informationDataSet1 student_examination_informationDataSet1;
        private System.Windows.Forms.BindingSource classNoBindingSource;
        private student_examination_informationDataSet1TableAdapters.classNoTableAdapter classNoTableAdapter;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
<<<<<<< HEAD
=======
        private Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox imageBox2;
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
    }
}