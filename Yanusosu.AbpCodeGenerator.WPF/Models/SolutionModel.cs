namespace Yanusosu.AbpCodeGenerator.WPF.Models
{
    public class SolutionModel
    {
        /// <summary>
        /// 所选文件路径
        /// </summary>
        public string SelectedFilePath { get; set; }

        /// <summary>
        /// 所选文件目录
        /// </summary>
        public string FilePath => SelectedFilePath.Replace(SelectFileName, "");

        /// <summary>
        /// 所选文件名称
        /// </summary>
        public string SelectFileName { get; set; }

        /// <summary>
        /// 所选文件className
        /// </summary>
        public string ClassName => SelectFileName.Replace(".cs", "");
    }
}