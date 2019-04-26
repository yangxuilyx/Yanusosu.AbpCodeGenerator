using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Yanusosu.AbpCodeGenerator.Extensions;
using Yanusosu.AbpCodeGenerator.WPF.Forms;
using Yanusosu.AbpCodeGenerator.WPF.Models;

namespace Yanusosu.AbpCodeGenerator.WPF
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                MessageBox.Show("启动参数错误");
                return;
            }
            new App().Run(new MainWindow(new SolutionModel()
                {
                    SelectedFilePath =
                        args[0],
                    SelectFileName = args[1]
                }));
        }
    }
}
