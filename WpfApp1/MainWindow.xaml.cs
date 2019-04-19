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

            //ControlTypeCombox.ItemsSource = _controlTypes;
            _generatorModule = new GeneratorModule()
            {
                EntityKeyName = "long",
                Name = "Student",
                DisplayName = "学生",
                Namespace = "Yanusosu.Platform.Schools.Students",
                EnableAuthorization = true,
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

            ModelGrid.DataContext = _generatorModule;
            this.MetaGrid.ItemsSource = _generatorModule.MetaColumnInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var result = 

            var templateViewModels = TemplateViewModel.GetNormalViewModels(new SolutionModel()
            {
                SelectedFilePath = @"E:\code\github\Yanusosu.Platform\aspnet-core\src\Yanusosu.Platform.Core\Schools\Students\Student.cs",
                SelectFileName = "Student.cs"
            }, _generatorModule);

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

        private void MetaGrid_OnGotFocus(object sender, RoutedEventArgs e)
        {
            // Lookup for the source to be DataGridCell
            if (e.OriginalSource.GetType() == typeof(DataGridCell))
            {
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);

                Control control = GetFirstChildByType<Control>(e.OriginalSource as DataGridCell);
                if (control != null)
                {
                    control.Focus();
                }
            }
        }

        private T GetFirstChildByType<T>(DependencyObject prop) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(prop); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild((prop), i) as DependencyObject;
                if (child == null)
                    continue;

                T castedProp = child as T;
                if (castedProp != null)
                    return castedProp;

                castedProp = GetFirstChildByType<T>(child);

                if (castedProp != null)
                    return castedProp;
            }
            return null;
        }
    }
}
