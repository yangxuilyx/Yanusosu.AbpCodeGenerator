using System.Collections.Generic;
using System.Windows;
using Yanusosu.AbpCodeGenerator.Models;

namespace Yanusosu.AbpCodeGenerator.Forms
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
            _generatorModule = GeneratorModule.GenerateModel(_solutionModel);

            this.MetaGrid.ItemsSource = _generatorModule.MetaColumnInfos;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var generatorModuleMetaColumnInfos = _generatorModule.MetaColumnInfos;
        }
    }
}
