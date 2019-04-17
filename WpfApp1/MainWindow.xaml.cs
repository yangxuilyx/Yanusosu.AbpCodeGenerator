using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RazorEngine;
using Yanusosu.AbpCodeGenerator.Models;
using FullPathTemplateKey = RazorEngine.Templating.FullPathTemplateKey;
using Path = System.Windows.Shapes.Path;
using ResolveType = RazorEngine.Templating.ResolveType;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _controlTypes = new List<string>()
        {
            "Text",
            "Textarea",
            "Hidden",
            "DatePicker",
            "DateTimePicker"
        };

        private readonly GeneratorModule _generatorModule;

        public MainWindow()
        {
            InitializeComponent();

            ControlTypeCombox.ItemsSource = _controlTypes;
            _generatorModule = new GeneratorModule()
            {
                EntityKeyName = "long",
                Name = "Student",
                DisplayName = "学生",
                CamelCaseName = "student",
                SplitName = "student",
                Namespace = "Yanusosu.Platform.Schools.Students",
                SolutionNameSpace = "Yanusosu.Platform",
                CompanyName = "Yanusosu",
                ConstName = "Platform",
                ModuleName = "Schools",
                MetaColumnInfos = new List<MetaColumnInfo>()
                {
                    new MetaColumnInfo()
                    {
                        StrDataType = "string",
                        Name="Name",
                        DisplayName = "姓名",
                        CamelCaseName="name",
                        IsSimpleProperty=true,
                        ControlType="text",
                        IsDtoVisible=true,
                        IsCreateVisible=true,
                        IsUpdateVisible=true,
                        Required=true,
                        MaxLength = 64
                    },
                    new MetaColumnInfo()
                    {
                        StrDataType = "Sex",
                        Name="Sex",
                        DisplayName = "性别",
                        CamelCaseName="sex",
                        IsSimpleProperty=true,
                        ControlType="checkbox",
                        IsDtoVisible=true,
                        IsCreateVisible=true,
                        IsUpdateVisible=true,
                        Required=true,
                        MaxLength = 64
                    },
                    new MetaColumnInfo()
                    {
                        StrDataType = "string",
                        Name="StudentNo",
                        DisplayName = "学号",
                        CamelCaseName="studentNo",
                        IsSimpleProperty=true,
                        ControlType="text",
                        IsDtoVisible=true,
                        IsCreateVisible=true,
                        IsUpdateVisible=true,
                        Required=true,
                        MaxLength = 64
                    },
                    new MetaColumnInfo()
                    {
                        StrDataType = "int",
                        Name="Grade",
                        DisplayName = "年纪",
                        CamelCaseName="grade",
                        IsSimpleProperty=true,
                        ControlType="text",
                        IsDtoVisible=true,
                        IsCreateVisible=true,
                        IsUpdateVisible=true,
                        Required=true,
                        MaxLength = 64
                    },
                    new MetaColumnInfo()
                    {
                        StrDataType = "int",
                        Name="Class",
                        DisplayName = "班级",
                        CamelCaseName="class",
                        IsSimpleProperty=true,
                        ControlType="text",
                        IsDtoVisible=true,
                        IsCreateVisible=true,
                        IsUpdateVisible=true,
                        Required=true,
                        MaxLength = 512
                    },
                    new MetaColumnInfo()
                    {
                        StrDataType = "bool",
                        Name="IsGoodStudent",
                        DisplayName = "是否好学生",
                        CamelCaseName="isGoodStudent",
                        IsSimpleProperty=true,
                        ControlType="text",
                        IsDtoVisible=true,
                        IsCreateVisible=false,
                        IsUpdateVisible=false,
                        Required=true,
                        MaxLength = 64
                    },
                    new MetaColumnInfo()
                    {
                        StrDataType = "decimal",
                        Name="LastScore",
                        DisplayName = "最后考试成绩",
                        CamelCaseName="lastScore",
                        IsSimpleProperty=true,
                        ControlType="text",
                        IsDtoVisible=true,
                        IsCreateVisible=false,
                        IsUpdateVisible=false,
                        Required=true,
                        MaxLength = 64
                    },
                }
            };
            this.MetaGrid.ItemsSource = _generatorModule.MetaColumnInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var result = 

            var templateViewModels = TemplateViewModel.GetNormalViewModels(new SolutionModel()
            {
                SelectedFilePath = @"E:\code\github\Yanusosu.Platform\aspnet-core\src\Yanusosu.Platform.Core\Schools\Students\Student.cs",
                SelectFileName = "Student.cs"
            },_generatorModule);

            foreach (var templateViewModel in templateViewModels)
            {
                var template = File.ReadAllText(templateViewModel.TemplatePath, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

                templateViewModel.GenerateCode = Razor.Parse(template, _generatorModule);
            }

            foreach (var templateViewModel in templateViewModels)
            {
                if (!Directory.Exists(templateViewModel.SavePath))
                {
                    Directory.CreateDirectory(templateViewModel.SavePath);
                }

                using (FileStream fileStream = new FileStream(templateViewModel.FilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false).GetBytes(templateViewModel.GenerateCode);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }

            MessageBox.Show("生成完成");
        }

        public static void GenerateCode(GeneratorModule generatorModule)
        {

        }
    }
}
