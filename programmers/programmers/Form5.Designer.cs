namespace programmers
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.courseNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_examination_informationDataSet5 = new programmers.student_examination_informationDataSet5();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.classNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student_examination_informationDataSet6 = new programmers.student_examination_informationDataSet6();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.courseNoTableAdapter = new programmers.student_examination_informationDataSet5TableAdapters.courseNoTableAdapter();
            this.classNoTableAdapter = new programmers.student_examination_informationDataSet6TableAdapters.classNoTableAdapter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.courseNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程号：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "班级号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "文件位置：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.courseNoBindingSource;
            this.comboBox1.DisplayMember = "课程号";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(146, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(132, 26);
            this.comboBox1.TabIndex = 3;
            // 
            // courseNoBindingSource
            // 
            this.courseNoBindingSource.DataMember = "courseNo";
            this.courseNoBindingSource.DataSource = this.student_examination_informationDataSet5;
            // 
            // student_examination_informationDataSet5
            // 
            this.student_examination_informationDataSet5.DataSetName = "student_examination_informationDataSet5";
            this.student_examination_informationDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.classNoBindingSource;
            this.comboBox2.DisplayMember = "班级号";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(146, 111);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(132, 26);
            this.comboBox2.TabIndex = 4;
            // 
            // classNoBindingSource
            // 
            this.classNoBindingSource.DataMember = "classNo";
            this.classNoBindingSource.DataSource = this.student_examination_informationDataSet6;
            // 
            // student_examination_informationDataSet6
            // 
            this.student_examination_informationDataSet6.DataSetName = "student_examination_informationDataSet6";
            this.student_examination_informationDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 191);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 28);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "添加附件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(330, -1);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(614, 639);
            this.axAcroPDF1.TabIndex = 8;
            // 
            // courseNoTableAdapter
            // 
            this.courseNoTableAdapter.ClearBeforeFill = true;
            // 
            // classNoTableAdapter
            // 
            this.classNoTableAdapter.ClearBeforeFill = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 650);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "插入附件";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_examination_informationDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private student_examination_informationDataSet5 student_examination_informationDataSet5;
        private System.Windows.Forms.BindingSource courseNoBindingSource;
        private student_examination_informationDataSet5TableAdapters.courseNoTableAdapter courseNoTableAdapter;
        private student_examination_informationDataSet6 student_examination_informationDataSet6;
        private System.Windows.Forms.BindingSource classNoBindingSource;
        private student_examination_informationDataSet6TableAdapters.classNoTableAdapter classNoTableAdapter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}