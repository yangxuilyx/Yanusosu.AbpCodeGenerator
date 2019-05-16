using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using RazorEngine;
using Yanusosu.AbpCodeGenerator.WPF.Models;

namespace Yanusosu.AbpCodeGenerator.WPF.Forms
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolutionModel _solutionModel;
        private GeneratorModule _generatorModule = null;
        private List<string> ControlTypes = new List<string>()
        {
            "Text",
            "Textarea",
            "Hidden",
            "DatePicker",
            "DateTimePicker"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(SolutionModel model)
        {
            InitializeComponent();

            _solutionModel = model;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _generatorModule = GeneratorModule.GenerateModel(_solutionModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }

            this.MetaGrid.ItemsSource = _generatorModule.MetaColumnInfos;

            this.ModelGrid.DataContext = _generatorModule;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var result = 

            //try
            {
                var templateViewModels = TemplateViewModel.GetNormalViewModels(_solutionModel, _generatorModule);

                foreach (var templateViewModel in templateViewModels)
                {
                    var template = File.ReadAllText(templateViewModel.TemplatePath,
                        new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

                    templateViewModel.GenerateCode = Razor.Parse(template, _generatorModule);
                }

                foreach (var templateViewModel in templateViewModels)
                {
                    if (!Directory.Exists(templateViewModel.SavePath))
                    {
                        Directory.CreateDirectory(templateViewModel.SavePath);
                    }

                    using (FileStream fileStream =
                        new FileStream(templateViewModel.FilePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] bytes =
                            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false).GetBytes(templateViewModel
                                .GenerateCode);
                        fileStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}

            MessageBox.Show("生成完成");

            this.Close();
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
