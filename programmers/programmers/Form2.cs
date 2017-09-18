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
<<<<<<< HEAD
=======
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using O2S.Components.PDFRender4NET;
using System.IO;
using System.Drawing.Imaging;
using BK.Util;
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf

namespace programmers
{
    public partial class Form2 : Form
    {
<<<<<<< HEAD
=======
        //form2是试卷管理系统
        //修改两处地方，①和②
        //新建主路径下Cimage、Ctable、Cnoise、Cdigit四个文件夹
        //----------------------------------------------------------------------------------------------------------------------------------------------------
        //①修改输出主路径
        public string folderPath = @"C:\SongYue\project\image\";//输出总路径

>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“student_examination_informationDataSet1.classNo”中。您可以根据需要移动或删除它。
            this.classNoTableAdapter.Fill(this.student_examination_informationDataSet1.classNo);
            // TODO: 这行代码将数据加载到表“student_examination_informationDataSet.courseNo”中。您可以根据需要移动或删除它。
            this.courseNoTableAdapter.Fill(this.student_examination_informationDataSet.courseNo);
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            //选择文件后，用openFileDialog1的FileName属性获取文件的绝对路径
            this.textBox2.Text = this.openFileDialog1.FileName;
            //this.textBox2.Text = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
            //this.textBox2.Text = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            axAcroPDF1.src = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
=======
            //-------------------------------------------------------------------------------------------------------------------------
            //②注意修改str
            string str = @"Data Source=.\MSSQLSERVER2012;Initial catalog=student examination information;integrated Security=True";
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "insert into ses (班级,课程号,学号,文件名) values('" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            conn.Close();
<<<<<<< HEAD
            MessageBox.Show("添加成功!", "【成功】"); textBox1.Text = ""; textBox2.Text = ""; comboBox2.Text = ""; comboBox1.Text = "";
            //UpdataForm udform = new UpdataForm();  
            // this.DialogResult = System.Windows.Forms.DialogResult.OK;
=======
            //UpdataForm udform = new UpdataForm();  
            // this.DialogResult = System.Windows.Forms.DialogResult.OK;
            MessageBox.Show("添加成功!", "【成功】");


            //************************************pdf转jpg*****************************************************************************
            //-------------------------------------------------------------------------------------------------------------------------
            //设置pdf转jpg图片输出位置,此处我将pdf所有页面都转成jpg了，可在下面转换函数参数中设置转换页数
            //string folderPath = @"C:\SongYue\project\image\";//输出总路径

            string filePath = this.textBox2.Text;
            //-------------------------------------------------------------------------------------------------------------------------
            //③设置pdf转jpg输出文件夹，此处新建Cimage文件夹
            string pdf2imageFolder = "Cimage";
            StringBuilder sbPdf2Image = new StringBuilder();
            sbPdf2Image.Append(folderPath);
            sbPdf2Image.Append(pdf2imageFolder);
            sbPdf2Image.Append(@"\");
            //string outputPath = @"C:\SongYue\project\image\Cimage\";
            string outputPath = sbPdf2Image.ToString();

            //读取pdf文件名以命名图片，变量pdfName为pdf名
            string[] filePathSplit = filePath.Split('\\');
            string fileName = filePathSplit[filePathSplit.Count() - 1];
            string[] pdfNameSplit = fileName.Split('.');
            string pdfName = pdfNameSplit[0];

            List<string> imgList = ConvertPdf2Image(filePath, outputPath, pdfName, ImageFormat.Jpeg, Definition.Ten);
            string firstPagePath = imgList[0].Replace(@"\", @"\\");

            //**************************************截取分数表格************************************************************************
            Image<Rgb, byte> firstPage = new Image<Rgb, byte>(firstPagePath);//图片是bgr格式的话会报错（黑白试卷）

            Image<Rgb, byte> scoreTable = scoreTableCut(firstPage);
            StringBuilder sb = new StringBuilder();
            //--------------------------------------------------------------------------------------------------------------------------
            //④设置截取表格输出文件夹，此处我新建Ctable文件夹
            string scoreTableFolder = @"Ctable\";
            sb.Append(folderPath);
            sb.Append(scoreTableFolder);
            sb.Append(pdfName);
            sb.Append(".jpg");
            scoreTable.Save(sb.ToString());

            //*************************************找到表格每条竖线的x坐标******************************************************************
            List<int> borderCol = findCol(scoreTable);
            for (int i = 0; i < borderCol.Count; i++)
            {
                Console.WriteLine(borderCol[i]);
            }

            //**************************************识别数字********************************************************************************
            //提取红色通道
            Image<Gray, byte> score = extractRed(scoreTable);
            //降噪
            Image<Gray, byte> scoreNoise = noiseReduce(score);

            string noiseFolder = @"Cnoise\";
            StringBuilder sbNoise = new StringBuilder();
            sbNoise.Append(folderPath);
            sbNoise.Append(noiseFolder);
            sbNoise.Append(pdfName);
            sbNoise.Append("_noise.jpg");
            scoreNoise.Save(sbNoise.ToString());
            //scoreNoise.Save(@"C:\SongYue\project\image\CredTable\0911test_scorenoise.jpg");

            //识别            
            scoreReco(scoreNoise, borderCol);

            textBox1.Text = ""; textBox2.Text = ""; comboBox2.Text = ""; comboBox1.Text = "";

>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD
=======

        #region pdf转换成jpeg
        public enum Definition
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
        }

        /// <summary>
        /// 将PDF文档转换为图片的方法
        /// </summary>
        /// <param name="pdfInputPath">PDF文件路径</param>
        /// <param name="imageOutputPath">图片输出路径</param>
        /// <param name="imageName">生成图片的名字</param>
        /// <param name="startPageNum">从PDF文档的第几页开始转换</param>
        /// <param name="endPageNum">从PDF文档的第几页开始停止转换</param>
        /// <param name="imageFormat">设置所需图片格式</param>
        /// <param name="definition">设置图片的清晰度，数字越大越清晰</param>
        /// 

        public List<string> ConvertPdf2Image(string pdfInputPath, string imageOutputPath,
            string imageName, int startPageNum, int endPageNum, ImageFormat imageFormat, Definition definition)
        {
            List<string> imgList = new List<string>();
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);
            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }
            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }
            if (endPageNum > pdfFile.PageCount)
            {
                endPageNum = pdfFile.PageCount;
            }
            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }
            // start to convert each page
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                Bitmap pageImage = pdfFile.GetPageImage(i - 1, 50 * (int)definition);
                //Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                pageImage.Save(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                imgList.Add(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString());
                pageImage.Dispose();
            }
            pdfFile.Dispose();

            return imgList;
        }

        public List<string> ConvertPdf2Image(string pdfInputPath, string imageOutputPath,
            string imageName, ImageFormat imageFormat, Definition definition)
        {
            List<string> imgList = new List<string>();
            PDFFile pdfFile = PDFFile.Open(pdfInputPath);
            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }

            int endPageNum = pdfFile.PageCount;
            // start to convert each page
            for (int i = 1; i <= endPageNum; i++)
            {
                try
                {
                    Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);//清晰度值过高会使部分pdf转换时出现参数错误的报错信息
                                                                                         //Bitmap pageImage = pdfFile.GetPageImage(i - 1, 56 * (int)definition);
                    pageImage.Save(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                    imgList.Add(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString());
                    pageImage.Dispose();
                }
                catch(Exception e)
                {
                    Bitmap pageImage = pdfFile.GetPageImage(i - 1, 25 * (int)definition);//清晰度值过高会使部分pdf转换时出现参数错误的报错信息
                    pageImage.Save(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                    imgList.Add(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString());
                    pageImage.Dispose();

                }
            }
            pdfFile.Dispose();
            return imgList;
        }
        #endregion


        #region 截取分数表格
        private Image<Rgb, byte> scoreTableCut(Image<Rgb, byte> img)
        {
            Mat horizontal = extractLine(img, "horizontal", 20, 1);
            Mat vertical = extractLine(img, "vertical", 20, 1);

            Mat mask = new Mat();//保存表格横线和竖线
            CvInvoke.Add(horizontal, vertical, mask);

            Mat mask1 = new Mat();//保存表格交叉点
            CvInvoke.BitwiseAnd(horizontal, vertical, mask1);

            List<Rectangle> boxList = new List<Rectangle>();
            List<Rectangle> result_boxList = new List<Rectangle>();
            int top_result = img.Height;
            int bottom_result = 0;
            int left_result = img.Width;
            int right_result = 0;

            VectorOfVectorOfPoint cons = new VectorOfVectorOfPoint();
            VectorOfPoint approxCon = new VectorOfPoint();
            VectorOfMat rois = new VectorOfMat();
            CvInvoke.FindContours(mask, cons, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            Console.WriteLine(cons.Size);

            for (int i = 0; i < cons.Size; i++)
            {
                //获取区域的面积，如果小于某个值就忽略，代表是杂线不是表格
                double area = CvInvoke.ContourArea(cons[i]);
                if (area < 100)
                    continue;
                VectorOfPoint con = new VectorOfPoint();
                con = cons[i];
                CvInvoke.ApproxPolyDP(con, approxCon, CvInvoke.ArcLength(con, true) * 0.05, true);

                boxList.Add(CvInvoke.BoundingRectangle(approxCon));
            }

            Mat src = new Mat();
            Mat src_rec = new Mat();
            Console.WriteLine(boxList.Count);
            for (int i = 0; i < boxList.Count; i++)
            {
                // find the number of joints that each table has
                Mat roi = new Mat(mask1, boxList[i]);

                VectorOfVectorOfPoint joints_contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(roi, joints_contours, null, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);

                //从表格的特性看，如果这片区域的点数小于4，那就代表没有一个完整的表格，忽略掉
                if (joints_contours.Size <= 4)
                    continue;

                int top = boxList[i].Top;
                int bottom = boxList[i].Bottom;
                int left = boxList[i].Left;
                int right = boxList[i].Right;
                int box_height = boxList[i].Height;
                int box_width = boxList[i].Width;
                int box_area = box_height * box_width;

                int width = img.Width;
                int height = img.Height;
                int area = width * height;

                if (box_area <= area / 4)
                {
                    if ((top >= height * 0.15) && (bottom <= height * 0.7) && (left >= width * 0.05) && (right <= width * 0.6))
                    {
                        result_boxList.Add(boxList[i]);

                        if (top_result > boxList[i].Top)
                        {
                            top_result = boxList[i].Top;
                        }
                        if (bottom_result < boxList[i].Bottom)
                        {
                            bottom_result = boxList[i].Bottom;
                        }
                        if (left_result > boxList[i].Left)
                        {
                            left_result = boxList[i].Left;
                        }
                        if (right_result < boxList[i].Right)
                        {
                            right_result = boxList[i].Right;
                        }
                    }
                }
            }        

            Console.WriteLine(top_result + " " + bottom_result + " " + left_result + " " + right_result);

            Image<Rgb, byte> img_cut = new Image<Rgb, byte>(right_result - left_result, bottom_result - top_result);
            Point pt = new Point(left_result, top_result);
            Rectangle result_rec = new Rectangle(pt, new Size(right_result - left_result, bottom_result - top_result));
            CvInvoke.cvSetImageROI(img, result_rec);
            CvInvoke.cvCopy(img, img_cut, IntPtr.Zero);

            return img_cut;
        }
        #endregion


        #region 提取红色通道
        private Image<Gray, byte> extractRed(Image<Rgb, byte> img)
        {
            Image<Hsv, byte> hsv = new Image<Hsv, byte>(img.Size);
            CvInvoke.CvtColor(img, hsv, ColorConversion.Rgb2Hsv);

            Image<Rgb, byte> mask = new Image<Rgb, byte>(img.Size);

            Mat h = new Mat();
            Mat s = new Mat();

            CvInvoke.ExtractChannel(hsv, h, 0);//提取h通道
            CvInvoke.ExtractChannel(hsv, s, 1);//提取s通道

            using (ScalarArray low = new ScalarArray(10))
            using (ScalarArray up = new ScalarArray(165))
                CvInvoke.InRange(h, low, up, h);//提取h在low和up之间的部分
            CvInvoke.BitwiseNot(h, h);

            CvInvoke.Threshold(s, s, 30, 255, ThresholdType.Binary);//提取s在30到255之间的部分
            CvInvoke.BitwiseAnd(h, s, h, null);
            CvInvoke.BitwiseNot(h, h);

            var kernal = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(4, 4), new Point(1, 1));

            CvInvoke.Threshold(h, h, 100, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);//二值化
            CvInvoke.Erode(h, h, kernal, new Point(0, 2), 1, BorderType.Default, new MCvScalar());
            CvInvoke.Dilate(h, h, kernal, new Point(0, 2), 1, BorderType.Default, new MCvScalar());//开运算（先腐蚀后膨胀）去除噪点

            Image<Rgb, byte> h1 = h.ToImage<Rgb, byte>();
            Image<Gray, byte> h2 = new Image<Gray, byte>(h1.Size);
            CvInvoke.CvtColor(h1, h2, ColorConversion.Rgb2Gray);
            return h2;
        }
        #endregion


        #region 图片预处理
        private Image<Gray, byte> noiseReduce(Image<Gray, byte> h2)
        {            
            Image<Gray, byte> img_gray = new Image<Gray, byte>(h2.Size);
            Image<Gray, byte> threshold = new Image<Gray, byte>(h2.Size);
            CvInvoke.cvCopy(h2, img_gray, IntPtr.Zero);
            CvInvoke.Threshold(img_gray, threshold, 100, 255, ThresholdType.Binary | ThresholdType.Otsu);//二值化
            var kernal = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(4, 4), new Point(1, 1));
            CvInvoke.Erode(threshold, threshold, kernal, new Point(0, 2), 1, BorderType.Default, new MCvScalar());

            return threshold;
        }
        #endregion


        #region 识别各大题分数
        private void scoreReco(Image<Gray, byte> img, List<int> borderCol)
        {
            //------------------------------------------------------------------------------------------------------------------------------------------
            //⑤新建Cdigit文件夹
            string digitFolder = @"Cdigit\";
            StringBuilder sbDigit = new StringBuilder();
            sbDigit.Append(folderPath);
            sbDigit.Append(digitFolder);
            string pathS = sbDigit.ToString();

            Image<Gray, byte> imgCopy = new Image<Gray, byte>(img.Size);//imgCopy储存膨胀后图片
            CvInvoke.cvCopy(img, imgCopy, IntPtr.Zero);
            Mat horizontalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(30, 1), new Point(-1, -1));
            //横向膨胀以解决断笔问题（例如5最上面的横线与字符分离）
            CvInvoke.Dilate(imgCopy, imgCopy, horizontalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

            Image<Rgb, byte> h_temp = new Image<Rgb, byte>(img.Size);
            CvInvoke.CvtColor(img, h_temp, ColorConversion.Gray2Rgb);

            List<Rectangle> boundingBox = new List<Rectangle>();
            Point pointZero = new Point(0, 0);
            
            Image<Gray, byte> segmented = new Image<Gray, byte>(0, 0);

            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.FindContours(imgCopy, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);//在膨胀后的图片寻找连通域
                for (int i = 0; i < contours.Size; i++)
                {
                    using (VectorOfPoint contour = contours[i])
                    using (VectorOfPoint approxContour = new VectorOfPoint())
                    {
                        CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.01, true);
                        Rectangle boundingRec = CvInvoke.BoundingRectangle(approxContour);

                        #region 数字检测
                        if (boundingRec.Height > 50 && boundingRec.Height < img.Height / 3)
                        {
                            h_temp.Draw(boundingRec, new Rgb(0, 255, 0), 1);//h_temp即为界面中显示的图片
                            boundingBox.Add(boundingRec);
                        }
                        #endregion

                        #region 去除噪点
                        if (boundingRec.Height < 50 && boundingRec.Width < 50)
                        {
                            for (int j = boundingRec.Top; j < boundingRec.Top + boundingRec.Height; j++)
                            {
                                for (int k = boundingRec.Left; k < boundingRec.Left + boundingRec.Width; k++)
                                {
                                    h_temp.Data[j, k, 0] = 0;
                                    img.Data[j, k, 0] = 0;
                                }
                            }
                        }
                        #endregion

                        imageBox1.Image = h_temp;
                    }

                }

                #region 各大题分数分割
                //string pathS = @"C:\SongYue\project\image\CredTable\";

                List<int> scoreEvery = new List<int>();
                SortedDictionary<float, Image<Gray, byte>> sortedDigitImage = new SortedDictionary<float, Image<Gray, byte>>();//按从左到右顺序保存字符
                SortedDictionary<int, SortedDictionary<float, Image<Gray, byte>>> scoreSplit = new SortedDictionary<int, SortedDictionary<float, Image<Gray, byte>>>();

                for (int i = 0; i < boundingBox.Count; i++)
                {
                    Rectangle boundingRec = boundingBox[i];
                    float digitXcentroid = boundingRec.Left + boundingRec.Width / 2;
                    int length = boundingRec.Right - boundingRec.Left + 50;
                    int width = boundingRec.Bottom - boundingRec.Top + 70;
                    segmented = new Image<Gray, byte>(length, width);
                    

                    for (int i1 = boundingRec.Top - 15, k = 20; i1 <= boundingRec.Bottom + 15; i1++, k++)
                    {
                        for (int j1 = boundingRec.Left - 5, l = 20; j1 <= boundingRec.Right + 5; j1++, l++)
                        {
                            segmented.Data[k, l, 0] = img.Data[i1, j1, 0];
                        }
                    }
                    sortedDigitImage.Add(digitXcentroid, segmented);

                }
                #endregion

                //检查分割出来的图片
                //string pathS = @"C:\SongYue\project\image\CredTable\";
                foreach (int i in sortedDigitImage.Keys)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(pathS);
                    sb.Append(i);
                    sb.Append(".jpg");
                    sortedDigitImage[i].Save(sb.ToString());
                }

                //SortedDictionary<int, SortedDictionary<float, Image<Gray, byte>>> scoreSplit = new SortedDictionary<int, SortedDictionary<float, Image<Gray, byte>>>();
                for (int j = 0; j < borderCol.Count - 1; j++)
                {
                    SortedDictionary<float, Image<Gray, byte>> colImg = new SortedDictionary<float, Image<Gray, byte>>();

                    foreach (int i in sortedDigitImage.Keys)
                    {
                        if (i >= borderCol[j] && i <= borderCol[j + 1])
                        {
                            colImg.Add(i, sortedDigitImage[i]);
                        }
                    }
                    scoreSplit.Add(j, colImg);
                }

                foreach (int i in sortedDigitImage.Keys)
                {
                    Image<Gray, byte> sortImagePre = sortedDigitImage[i];
                    Mat horStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 1), new Point(-1, -1));
                    //纵向腐蚀以分割粘连字符
                    CvInvoke.Erode(sortImagePre, sortImagePre, horStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

                    StringBuilder sb = new StringBuilder();
                    sb.Append(pathS);
                    sb.Append(i);
                    sb.Append("_erode.jpg");
                    sortImagePre.Save(sb.ToString());
                }

                //粘连字符分割：还未实现
                foreach (int i in scoreSplit.Keys)
                {
                    SortedDictionary<float, Image<Gray, byte>> colImg = scoreSplit[i];
                    foreach (int j in colImg.Keys)
                    {
                        Image<Gray, byte> sortImageCopy = sortedDigitImage[j];
                        Image<Gray, byte> sortImagePre = sortedDigitImage[j];
                        Mat horStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(5, 1), new Point(-1, -1));

                        //纵向腐蚀以分割粘连字符
                        CvInvoke.Erode(sortImagePre, sortImagePre, horStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

                        List<int> pixel = new List<int>();
                        for (int col = 0; col < sortImagePre.Cols; col++)
                        {
                            int pix = 0;
                            for (int row = 0; row < sortImagePre.Rows; row++)
                            {
                                if (sortImagePre.Data[row, col, 0] == 255)
                                {
                                    pix++;
                                }
                            }
                            pixel.Add(pix);
                        }                        
                        
                    }
                }

                

            }
        }

        private List<int> findCol(Image<Rgb, byte> scoreTable)
        {
            Mat horizontalLineImg = extractLine(scoreTable, "horizontal", 20, 1);
            //horizontalLineImg.Save(@"C:\SongYue\project\image\h.jpg");
            List<int> border = getLineCoordinate(horizontalLineImg, "row");
  
            Console.WriteLine("表格行数：{0}", border.Count - 1);

            for (int i = 0; i < border.Count; i++)
            {
                Console.WriteLine(border[i]);
            }
            int above = border[1];
            Image<Rgb, byte> scoreCut = new Image<Rgb, byte>(scoreTable.Width, scoreTable.Height - above);
            Rectangle scoreRec = new Rectangle(new Point(0, above), new Size(scoreTable.Width, scoreTable.Height - above));
            CvInvoke.cvSetImageROI(scoreTable, scoreRec);
            CvInvoke.cvCopy(scoreTable, scoreCut, IntPtr.Zero);//把除了第一行的表格截取出来（一般第一行都是考试须知）

            Mat verticalLineImg = extractLine(scoreCut, "vertical", 10, 1);
            //verticalLineImg.Save(@"C:\SongYue\project\image\h.jpg");
            List<int> borderCol = getLineCoordinate(verticalLineImg, "col");

            for (int i = 0; i < borderCol.Count; i++)
            {
                Console.WriteLine(borderCol[i]);
            }
            Console.WriteLine("表格列数：{0}", borderCol.Count - 1);

            return borderCol;

        }
        #endregion

        //提取表格横线或竖线
        public Mat extractLine(Image<Rgb, byte> image, string mode, int scale, int level)
        {
            ///<param name="mode">提取横线或竖线：横线："horizontal"；竖线："vertical"</param>
            ///<param name="scale">这个值越大，检测到的直线越多</param>
            ///<param name="level">开运算中腐蚀膨胀的程度</param>

            //图片二值化
            Mat result = new Mat();
            Mat gray = new Mat();
            Mat threshold = new Mat();
            CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
            CvInvoke.AdaptiveThreshold(gray, threshold, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 15, 5);

            if (mode == "horizontal")
            {
                Mat horizontal = threshold.Clone();
                //int scale = 20; //这个值越大，检测到的直线越多
                int horizontalsize = horizontal.Cols / scale;

                // 为了获取横向的表格线，设置腐蚀和膨胀的操作区域为一个比较大的横向直条
                Mat horizontalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(horizontalsize, 1), new Point(-1, -1));

                // 先腐蚀再膨胀            
                CvInvoke.Erode(horizontal, horizontal, horizontalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));
                CvInvoke.Dilate(horizontal, horizontal, horizontalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

                result = horizontal.Clone();
            }

            if (mode == "vertical")
            {
                Mat vertical = threshold.Clone();

                //int scale = 10;
                int verticalsize = vertical.Rows / scale;
                Mat verticalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(1, verticalsize), new Point(-1, -1));
                CvInvoke.Erode(vertical, vertical, verticalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));
                CvInvoke.Dilate(vertical, vertical, verticalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

                result = vertical.Clone();
            }

            return result;
        }

        //直方图查找竖线或横线坐标
        public List<int> getLineCoordinate(Mat image, string mode)
        {
            ///<param name="mode">提取横线或竖线的坐标：横线："row"；竖线："col"</param>

            List<int> pixel = new List<int>();
            Image<Gray, byte> img = image.ToImage<Gray, byte>();
            List<int> border = new List<int>();
            if (mode == "col")
            {
                for (int col = 0; col < img.Cols; col++)
                {
                    int pixelNum = 0;
                    for (int row = 0; row < img.Rows; row++)
                    {
                        if (img.Data[row, col, 0] == 0)
                        {
                            pixelNum++;
                        }
                    }
                    pixel.Add(pixelNum);
                }

                int flag = 0;

                for (int i = 0; i < pixel.Count; i++)
                {
                    int flag1 = 0;
                    if (pixel[i] <= 5)
                    {
                        flag1 = 1;
                    }
                    if (flag == 0 && flag1 == 1)
                    {
                        border.Add(i);
                    }
                    flag = flag1;
                }
            }

            if (mode == "row")
            {
                int sampleX = image.Width / 2;//在宽的中点处遍历像素，记录横线所在位置
                int count = 0;
                int flag = 0;
                Image<Gray, byte> horizontalImage = image.ToImage<Gray, byte>();
                for (int i = 0; i < horizontalImage.Height; i++)
                {
                    int flagSample = 0;
                    if (horizontalImage.Data[i, sampleX, 0] == 255)
                    {
                        flagSample = 1;
                    }
                    if (flagSample == 1 && flag == 0)
                    {
                        count++;
                        border.Add(i);
                    }
                    flag = flagSample;
                }
                int horizontalLine = count / 2;
                Console.WriteLine("表格行数：{0}", horizontalLine - 1);
                int scoreRow = horizontalLine - 1;
            }

            return border;
        }
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
    }
}
