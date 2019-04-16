using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Yanusosu.AbpCodeGenerator.CodeAnalysis;
using Yanusosu.AbpCodeGenerator.Extensions;
using Yanusosu.AbpCodeGenerator.Models;

namespace Yanusosu.AbpCodeGenerator.Forms
{
    public partial class MainForm : Form
    {
        private SolutionModel _solutionModel;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(SolutionModel model)
        {
            InitializeComponent();

            _solutionModel = model;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GeneratorModuleViewModel.GenerateModel(_solutionModel);
        }
    }
}
