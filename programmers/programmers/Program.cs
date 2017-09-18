using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programmers
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            //Application.Run(new mainform());
          Form1 fl = new Form1();
            fl.ShowDialog();
           if (fl.DialogResult == DialogResult.OK)
            {
               Application.Run(new mainform());
           }
            else
           {
                return;
            }
=======
            Application.Run(new Form5());

            //正式运行时要去掉注释
          //Form1 fl = new Form1();
          //  fl.ShowDialog();
          // if (fl.DialogResult == DialogResult.OK)
          //  {
          //     Application.Run(new mainform());
          // }
          //  else
          // {
          //      return;
          //  }


>>>>>>> 1922bc26acf50d440c0102bf9993a0274e62c8cf
        }
    }
}
