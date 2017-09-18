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
namespace programmers
{
    public partial class Form5 : Form
    {
=======
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing.Imaging;
using O2S.Components.PDFRender4NET;
using System.IO;
using Emgu.CV.OCR;


namespace programmers
{

    public partial class Form5 : Form
    {
        //form5是附件管理系统：附件即为空白试卷
        int quesNum = 0;
        private Tesseract _ocr;

>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
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
<<<<<<< HEAD
            string str = @"Data Source=localhost;Initial catalog=student examination information;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "insert into file2 (班级,课程号,附件文件) values('" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "')";
=======

            //textBox1.Text = "";  comboBox2.Text = ""; comboBox1.Text = "";textBox2.Text = "" ;
            //UpdataForm udform = new UpdataForm();  
            // this.DialogResult = System.Windows.Forms.DialogResult.OK;

            string filePath = this.textBox1.Text;
            MessageBox.Show(filePath);
            string outputPath = @"C:\SongYue\project\image\Simage\";
            StringBuilder sName = new StringBuilder();
            sName.Append(comboBox1.Text);
            sName.Append('_');
            sName.Append(comboBox2.Text);
            string sname = sName.ToString();

            List<string> imgList = ConvertPdf2Image(filePath, outputPath, sname, ImageFormat.Jpeg, Definition.Ten);
            string firstPagePath = imgList[0].Replace(@"\", @"\\");

            Image<Rgb, byte> firstPage = new Image<Rgb, byte>(firstPagePath);//图片是bgr格式的话会报错


            Image<Rgb, byte> scoreTable = scoreTableCut(firstPage);
            StringBuilder sb = new StringBuilder(); // 声明一个字符串构造器实例
            //------------------------------------------------------------------------------------------------------------------------------------------
            //注意修改路径
            string scoreTableFolderPath = "C:\\SongYue\\project\\image\\Stable\\";
            sb.Append(scoreTableFolderPath);
            sb.Append(sname);
            sb.Append(".jpg");
            scoreTable.Save(sb.ToString());

            //CvInvoke.AdaptiveThreshold();
            fullMarkCut(scoreTable);

            //-------------------------------------------------------------------------------------------------------------------------------------------
            //注意修改str
            string str = @"Data Source=.\MSSQLSERVER2012;Initial catalog=student examination information;integrated Security=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "insert into file2 (班级,课程号,附件文件,大题总数) values('" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "','" + quesNum + "')";
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            conn.Close();
<<<<<<< HEAD
            MessageBox.Show("添加成功!", "【成功】"); textBox1.Text = "";  comboBox2.Text = ""; comboBox1.Text = "";
            //UpdataForm udform = new UpdataForm();  
            // this.DialogResult = System.Windows.Forms.DialogResult.OK;
=======
            MessageBox.Show("添加成功!", "【成功】");
            textBox1.Text = ""; comboBox2.Text = ""; comboBox1.Text = ""; textBox2.Text = "";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

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
                catch (Exception e)
                {
                    try
                    {
                        Bitmap pageImage = pdfFile.GetPageImage(i - 1, 49 * (int)definition);//清晰度值过高会使部分pdf转换时出现参数错误的报错信息
                        pageImage.Save(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                        imgList.Add(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString());
                        pageImage.Dispose();
                    }
                    catch (Exception f)
                    {
                        Bitmap pageImage = pdfFile.GetPageImage(i - 1, 40 * (int)definition);//清晰度值过高会使部分pdf转换时出现参数错误的报错信息
                        pageImage.Save(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                        imgList.Add(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString());
                        pageImage.Dispose();
                    }

                }
                //pageImage.Save(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString(), imageFormat);
                //imgList.Add(imageOutputPath + imageName + "_" + i.ToString() + "." + imageFormat.ToString());
                //pageImage.Dispose();
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

        #region 对分数表格进行处理
        public Image<Rgb, byte> fullMarkCut(Image<Rgb, byte> scoreTable)
        {
            Mat gray = new Mat();
            Mat threshold = new Mat();
            CvInvoke.CvtColor(scoreTable, gray, ColorConversion.Rgb2Gray);
            CvInvoke.Threshold(gray, threshold, 100, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);
            //CvInvoke.AdaptiveThreshold(gray, threshold, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 15, 5);            

            //使用二值化后的图像来获取表格横纵的线
            Mat horizontal = threshold.Clone();

            int scale = 20; //这个值越大，检测到的直线越多
            int horizontalsize = horizontal.Cols / scale;

            // 为了获取横向的表格线，设置腐蚀和膨胀的操作区域为一个比较大的横向直条
            Mat horizontalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(horizontalsize, 1), new Point(-1, -1));

            // 先腐蚀再膨胀            
            CvInvoke.Erode(horizontal, horizontal, horizontalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));
            CvInvoke.Dilate(horizontal, horizontal, horizontalStructure, new Point(-1, -1), 5, BorderType.Constant, new MCvScalar(255));
            //imageBox1.Image = horizontal;

            int sampleX = horizontal.Width / 2;
            int count = 0;
            int flag = 0;
            List<int> border = new List<int>();//border储存每行的y坐标
            Image<Gray, byte> horizontalImage = horizontal.ToImage<Gray, byte>();
            for (int i = 0; i < horizontalImage.Height; i++)
            {
                int flagSample = 0;
                //Console.WriteLine(horizontalImage.Data[i, sampleX, 0]);
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
            //int horizontalLine = count / 2;
            int horizontalLine = count;
            Console.WriteLine("表格行数：{0}", horizontalLine - 1);
            int scoreRow = horizontalLine - 1;

            for (int i = 0; i < border.Count; i++)
            {
                Console.WriteLine(border[i]);
            }
            int above = border[1];
            Image<Rgb, byte> scoreCut = new Image<Rgb, byte>(scoreTable.Width, scoreTable.Height - above);
            Rectangle scoreRec = new Rectangle(new Point(0, above), new Size(scoreTable.Width, scoreTable.Height - above));
            CvInvoke.cvSetImageROI(scoreTable, scoreRec);
            CvInvoke.cvCopy(scoreTable, scoreCut, IntPtr.Zero);
            imageBox2.Image = scoreCut;

            //检测轮廓
            VectorOfVectorOfPoint horizontalCon = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(horizontal, horizontalCon, null, RetrType.Ccomp, ChainApproxMethod.ChainApproxSimple);
            Console.WriteLine(horizontalCon.Size);


            Mat grayVertical = new Mat();
            Mat thresholdVertical = new Mat();
            CvInvoke.CvtColor(scoreCut, grayVertical, ColorConversion.Rgb2Gray);
            CvInvoke.AdaptiveThreshold(grayVertical, thresholdVertical, 255, AdaptiveThresholdType.MeanC, ThresholdType.BinaryInv, 15, 5);

            Mat vertical = thresholdVertical.Clone();

            int scale1 = 10;
            int verticalsize = vertical.Rows / scale1;
            Mat verticalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(1, verticalsize), new Point(-1, -1));
            CvInvoke.Erode(vertical, vertical, verticalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));
            CvInvoke.Dilate(vertical, vertical, verticalStructure, new Point(-1, -1), 5, BorderType.Constant, new MCvScalar(255));
            //imageBox1.Image = vertical;

            int sampleY = vertical.Height / 2;
            int count1 = 0;
            int flag1 = 0;
            List<int> borderCol = new List<int>();//border储存每行的y坐标

            Image<Gray, byte> verticalImage = vertical.ToImage<Gray, byte>();
            for (int i = 0; i < verticalImage.Width; i++)
            {
                int flagSample = 0;
                //Console.WriteLine(horizontalImage.Data[sampleY, i, 0]);
                if (verticalImage.Data[sampleY, i, 0] == 255)
                {
                    flagSample = 1;
                }
                //if (flagSample != flag1)
                //{
                //    count1++;
                //}
                if (flagSample == 1 && flag1 == 0)
                {
                    count1++;
                    borderCol.Add(i);
                }

                flag1 = flagSample;
            }
            int verticalLine = count1;
            Console.WriteLine("表格列数：{0}", verticalLine - 1);

            int scoreCol = verticalLine - 1;

            List<Mat> rowLabel = new List<Mat>();
            rowLabel = rowLabelCut(scoreTable, border, borderCol);
            for (int i = 0; i < borderCol.Count; i++)
            {
                Console.WriteLine(borderCol[i]);
            }
            int fullMarkRowNum = recognizeFullMarkRow(rowLabel);
            if (fullMarkRowNum != -1)
            {
                recognizeFullMark(scoreTable, fullMarkRowNum, border, borderCol);
            }

            return scoreTable;
        }

        #endregion

        public List<Mat> rowLabelCut(Image<Rgb, byte> table, List<int> borderRow, List<int> borderCol)
        {
            List<Mat> rowLabel = new List<Mat>();
            for (int i = 0; i < borderRow.Count - 1; i++)
            {
                int width = borderCol[1] - borderCol[0];
                int height = borderRow[i + 1] - borderRow[i];
                int x = borderCol[0];
                int y = borderRow[i];
                Rectangle cutRec = new Rectangle(x, y, width, height);
                Image<Rgb, byte> tableCut = new Image<Rgb, byte>(new Size(width, height));
                CvInvoke.cvSetImageROI(table, cutRec);
                CvInvoke.cvCopy(table, tableCut, IntPtr.Zero);

                Mat invert = new Mat();
                CvInvoke.BitwiseAnd(tableCut, tableCut, invert);
                rowLabel.Add(invert);
            }
            return rowLabel;
        }

        public int recognizeFullMarkRow(List<Mat> rowLabel)
        {
            int fullMarkRowNum = -1;
            int count = 0;
            InitOcr("", "chi_sim", OcrEngineMode.TesseractLstmCombined);
            for (int i = 1; i < rowLabel.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                //---------------------------------------------------------------------------------------------------------------------------
                //注意修改路径 此处为每行表头截图
                string scoreTableFolderPath = "C:\\SongYue\\project\\image\\ScoreCut\\";
                sb.Append(scoreTableFolderPath);
                sb.Append(i);
                sb.Append(".jpg");
                rowLabel[i].Save(sb.ToString());

                string str = OcrImage(rowLabel[i]);
                Console.WriteLine(str);
                if (str.Contains("满"))
                {
                    count++;
                    fullMarkRowNum = i;
                    Console.WriteLine("fullMarkRow:{0}",i);
                }
            }
            _ocr.Dispose();

            return fullMarkRowNum;
            
        }

        private static void TesseractDownloadLangFile(String folder, String lang)
        {
            String subfolderName = "tessdata";
            String folderName = System.IO.Path.Combine(folder, subfolderName);
            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }
            String dest = System.IO.Path.Combine(folderName, String.Format("{0}.traineddata", lang));
            if (!System.IO.File.Exists(dest))
                using (System.Net.WebClient webclient = new System.Net.WebClient())
                {
                    String source =
                        String.Format("https://github.com/tesseract-ocr/tessdata/blob/4592b8d453889181e01982d22328b5846765eaad/{0}.traineddata?raw=true", lang);

                    Console.WriteLine(String.Format("Downloading file from '{0}' to '{1}'", source, dest));
                    webclient.DownloadFile(source, dest);
                    Console.WriteLine(String.Format("Download completed"));
                }
        }

        private void InitOcr(String path, String lang, OcrEngineMode mode)
        {
            try
            {
                if (_ocr != null)
                {
                    _ocr.Dispose();
                    _ocr = null;
                }

                if (String.IsNullOrEmpty(path))
                    path = ".";

                TesseractDownloadLangFile(path, lang);
                TesseractDownloadLangFile(path, "osd"); //script orientation detection
                String pathFinal = path.Length == 0 || path.Substring(path.Length - 1, 1).Equals(Path.DirectorySeparatorChar.ToString())
                    ? path
                    : String.Format("{0}{1}", path, System.IO.Path.DirectorySeparatorChar);

                _ocr = new Tesseract(pathFinal, lang, mode);

                //languageNameLabel.Text = String.Format("{0} : {1}", lang, mode.ToString());
            }
            catch (Exception e)
            {
                _ocr = null;
                MessageBox.Show(e.Message, "Failed to initialize tesseract OCR engine", MessageBoxButtons.OK);
                //languageNameLabel.Text = "Failed to initialize tesseract OCR engine";
            }
        }

        private string OcrImage(Mat source)
        {
            imageBox1.Image = null;
            ocrTextBox.Text = String.Empty;
            //hocrTextBox.Text = String.Empty;
#if !DEBUG
         try
#endif
            {

                Mat result = new Mat();
                String ocredText = OcrImage(_ocr, source, result);
                imageBox1.Image = result;
                ocrTextBox.Text = ocredText;
                //if (Mode == OCRMode.FullPage)
                //{
                //hocrTextBox.Text = _ocr.GetHOCRText();
                //}
            }
#if !DEBUG
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message);
         }
#endif
            return ocrTextBox.Text;
        }

        private static String OcrImage(Tesseract ocr, Mat image, Mat imageColor)
        {
            Bgr drawCharColor = new Bgr(Color.Red);

            if (image.NumberOfChannels == 1)
                CvInvoke.CvtColor(image, imageColor, ColorConversion.Gray2Bgr);
            else
                image.CopyTo(imageColor);

            ocr.SetImage(imageColor);

            int recResult = ocr.Recognize();
            Tesseract.Character[] characters = ocr.GetCharacters();
            if (characters.Length == 0)
            {
                Mat imgGrey = new Mat();
                CvInvoke.CvtColor(image, imgGrey, ColorConversion.Bgr2Gray);
                Mat imgThresholded = new Mat();
                CvInvoke.Threshold(imgGrey, imgThresholded, 65, 255, ThresholdType.Binary);
                ocr.SetImage(imgThresholded);
                characters = ocr.GetCharacters();
                imageColor = imgThresholded;
                if (characters.Length == 0)
                {
                    CvInvoke.Threshold(image, imgThresholded, 190, 255, ThresholdType.Binary);
                    ocr.SetImage(imgThresholded);
                    characters = ocr.GetCharacters();
                    imageColor = imgThresholded;
                }
            }
            foreach (Tesseract.Character c in characters)
            {
                CvInvoke.Rectangle(imageColor, c.Region, drawCharColor.MCvScalar);
            }

            string result = ocr.GetUTF8Text();
            ocr.Dispose();

            return result;
        }

        private string OcrImageFullMark(Mat source)
        {
            imageBox1.Image = null;
            ocrTextBox.Text = String.Empty;
            //hocrTextBox.Text = String.Empty;
#if !DEBUG
         try
#endif
            {

                Mat result = new Mat();
                String ocredText = OcrImageFullMark(_ocr, source, result);
                imageBox1.Image = result;
                ocrTextBox.Text = ocredText;
                //if (Mode == OCRMode.FullPage)
                //{
                //hocrTextBox.Text = _ocr.GetHOCRText();
                //}
            }
#if !DEBUG
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message);
         }
#endif
            return ocrTextBox.Text;
        }

        private static String OcrImageFullMark(Tesseract ocr, Mat image, Mat imageColor)
        {
            Bgr drawCharColor = new Bgr(Color.Red);

            if (image.NumberOfChannels == 1)
                CvInvoke.CvtColor(image, imageColor, ColorConversion.Gray2Bgr);
            else
                image.CopyTo(imageColor);

            ocr.SetVariable("tessedit_char_whitelist", "0123456789");
            ocr.SetImage(imageColor);

            int recResult = ocr.Recognize();
            Tesseract.Character[] characters = ocr.GetCharacters();
            if (characters.Length == 0)
            {
                Mat imgGrey = new Mat();
                CvInvoke.CvtColor(image, imgGrey, ColorConversion.Bgr2Gray);
                Mat imgThresholded = new Mat();
                CvInvoke.Threshold(imgGrey, imgThresholded, 65, 255, ThresholdType.Binary);
                //CvInvoke.Threshold(h, h, 100, 255, ThresholdType.BinaryInv | ThresholdType.Otsu);//二值化

                ocr.SetImage(imgThresholded);
                characters = ocr.GetCharacters();
                imageColor = imgThresholded;
                if (characters.Length == 0)
                {
                    CvInvoke.Threshold(image, imgThresholded, 190, 255, ThresholdType.Binary);
                    ocr.SetImage(imgThresholded);
                    characters = ocr.GetCharacters();
                    imageColor = imgThresholded;
                }
            }
            foreach (Tesseract.Character c in characters)
            {
                CvInvoke.Rectangle(imageColor, c.Region, drawCharColor.MCvScalar);
            }

            string result = ocr.GetUTF8Text();
            ocr.Dispose();

            return result;
        }

        private List<string> recognizeFullMark(Image<Rgb,byte>scoreTable, int fullMarkRowNum, List<int> borderRow, List<int> borderCol)
        {
            List<string> fullMarkReco = new List<string>();
            List<Mat> fullMarkTable = new List<Mat>();
            List<Image<Gray, byte>> fullMarkTableGray = new List<Image<Gray, byte>>();
            int height = borderRow[fullMarkRowNum + 1] - borderRow[fullMarkRowNum];
            for (int i = 1; i < borderCol.Count - 2; i++)
            {
                int width = borderCol[i + 1] - borderCol[i];
                Point pt = new Point(borderCol[i], borderRow[fullMarkRowNum]);
                Rectangle rec = new Rectangle(pt, new Size(width, height));
                Image<Rgb, byte> fullMark = new Image<Rgb, byte>(width, height);
                Image<Gray, byte> fullMarkGray = new Image<Gray, byte>(width, height);
                CvInvoke.cvSetImageROI(scoreTable, rec);
                CvInvoke.cvCopy(scoreTable, fullMark, IntPtr.Zero);

                StringBuilder sb = new StringBuilder();
                //----------------------------------------------------------------------------------------------------------------------------------------------
                //修改路径
                string fullMarkTableFolderPath = "C:\\SongYue\\project\\image\\FullMark\\";
                sb.Append(fullMarkTableFolderPath);
                sb.Append(i);
                sb.Append(".jpg");
                fullMark.Save(sb.ToString());

                Mat invert = new Mat();
                CvInvoke.BitwiseAnd(fullMark, fullMark, invert);
                fullMarkTable.Add(invert);

                CvInvoke.CvtColor(fullMark, fullMarkGray, ColorConversion.Rgb2Gray);
                fullMarkTableGray.Add(fullMarkGray);
            }

            InitOcr("", "eng", OcrEngineMode.TesseractLstmCombined);
            //_ocr.SetVariable("tessedit_char_whitelist", "0123456789");

            for (int i = 0; i < fullMarkTable.Count; i++)
            {
                
                string result = OcrImageFullMark(fullMarkTable[i]);
                fullMarkReco.Add(result);
                Console.WriteLine(result);
            }

            Console.WriteLine("-------------------------------------------------------------------------");
            for (int i = 0; i < fullMarkTableGray.Count; i++)
            {
                Mat imggray = disTableLine(fullMarkTableGray[i], i);
                string result = OcrImageFullMark(imggray);
                fullMarkReco.Add(result);
                Console.WriteLine(result);
            }

            _ocr.Dispose();
            
            return fullMarkReco;
        }

        private Mat disTableLine(Image<Gray, byte> image, int count)
        {
            Mat img = new Mat();
            CvInvoke.BitwiseAnd(image, image, img);

            int width = img.Width;
            int height = img.Height;

            Mat horizontal = img.Clone();
            Mat vertical = img.Clone();

            int scale = 20;
            int horizontalsize = horizontal.Cols / scale;
            int verticalsize = horizontal.Rows / scale;

            Mat horizontalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(horizontalsize, 1), new Point(-1, -1));
            Mat verticalStructure = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(1, verticalsize), new Point(-1, -1));

            CvInvoke.Erode(horizontal, horizontal, horizontalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));
            CvInvoke.Dilate(horizontal, horizontal, horizontalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

            CvInvoke.Erode(vertical, vertical, verticalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));
            CvInvoke.Dilate(vertical, vertical, verticalStructure, new Point(-1, -1), 1, BorderType.Constant, new MCvScalar(255));

            VectorOfVectorOfPoint horizontalContours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(horizontal, horizontalContours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);
            for (int i = 0; i < horizontalContours.Size; i++)
            {
                Rectangle boundingRec = CvInvoke.BoundingRectangle(horizontalContours[i]);
                if (boundingRec.Width >= width * 2 / 3)
                {
                    for (int p = boundingRec.Top; p < boundingRec.Bottom + 1; p++)
                    {
                        for (int q = boundingRec.Left; q < boundingRec.Right + 1; q++)
                        {
                            image.Data[q, p, 0] = 255;
                        }
                    }
                }
                if (boundingRec.Height >= height * 2 / 3)
                {
                    for (int p = boundingRec.Top; p < boundingRec.Bottom + 1; p++)
                    {
                        for (int q = boundingRec.Left; q < boundingRec.Right + 1; q++)
                        {
                            image.Data[q, p, 0] = 255;
                        }
                    }
                }                
            }

            Mat resultPic = new Mat();
            CvInvoke.BitwiseAnd(image, image, resultPic);

            return resultPic;
        }

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
>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
        }
    }
}
