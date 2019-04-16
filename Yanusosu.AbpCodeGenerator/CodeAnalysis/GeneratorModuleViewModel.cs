using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.OLE.Interop;
using RazorEngine;
using Yanusosu.AbpCodeGenerator.Extensions;
using Yanusosu.AbpCodeGenerator.Models;

namespace Yanusosu.AbpCodeGenerator.CodeAnalysis
{
    public class GeneratorModuleViewModel
    {
        public string EntityKeyName { get; set; }

        public string Name { get; set; }

        public string CamelCaseName { get; set; }

        public string Namespace { get; set; }

        public string ModuleName { get; set; }

        public static GeneratorModuleViewModel GenerateModel(SolutionModel solution)
        {
            /**
           * 需要获取：
           * 1.实体主键 √
           * 2.实体类名 
           * 5.模型命名空间 √
           * 6.模块名称 
           * 7.Meta数据
           */

            GeneratorModuleViewModel entityModel = new GeneratorModuleViewModel();

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(solution.SelectedFilePath, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)));
            var firstNode = syntaxTree.GetFirstClassNode();

            entityModel.EntityKeyName = GetEntityKeyName(firstNode);
            entityModel.Namespace = syntaxTree.GetNameSpace().Result;
            entityModel.Name = solution.SelectFileName.Replace(".cs", "");
            entityModel.CamelCaseName = entityModel.Name.ToCamelCase();
            entityModel.ModuleName = GetModuleName(entityModel.Namespace, entityModel.Name);

            var razorEngineService = Engine.Razor;

            return entityModel;
        }

        private static string GetModuleName(string namespaceStr, string name)
        {
            var modules = namespaceStr.Split('.');

            // 4段或三段命名空间，则取中间或者末尾端
            if (modules.Length >= 4)
            {
                return modules[3];
            }
            else if (modules.Length == 3)
            {
                throw new NotSupportedException("当前解决方案命名不是标准结构，请检查");
            }

            return name.ToPlural();
        }

        private static string GetEntityKeyName(ClassDeclarationSyntax classNode)
        {
            if (classNode.BaseList == null || classNode.BaseList.Types.Count <= 0)
            {
                return "int";
            }
            List<string> list = (from a in classNode.BaseList.Types
                                 select a.ToString()).ToList();
            string text = list.First();
            list.RemoveRange(0, 1);
            if (text.Length <= 2 || !text.StartsWith("I") || !char.IsUpper(text[1]))
            {
                Match match = Regex.Match(text, ".*?<(.*?)>");
                string entityKeyName;
                if (match.Success)
                {
                    entityKeyName = match.Groups[1].Value;
                }
                else
                {
                    entityKeyName = "int";
                }

                return entityKeyName;
            }

            return "int";
        }


    }
}