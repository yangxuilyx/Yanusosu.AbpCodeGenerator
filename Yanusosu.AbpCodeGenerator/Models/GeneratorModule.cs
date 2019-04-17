﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Yanusosu.AbpCodeGenerator.CodeAnalysis;
using Yanusosu.AbpCodeGenerator.Extensions;

namespace Yanusosu.AbpCodeGenerator.Models
{
    public class GeneratorModule
    {
        public string EntityKeyName { get; set; }

        public string Name { get; set; }

        public string CamelCaseName { get; set; }

        public string SplitName { get; set; }

        public string Namespace { get; set; }

        /// <summary>
        /// 解决方案命名空间：命名空间第一第二段
        /// </summary>
        public string SolutionNameSpace { get; set; }

        /// <summary>
        /// 公司名称：命名空间第一段
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 项目名称：命名空间第二段
        /// </summary>
        public string ConstName { get; set; }

        /// <summary>
        /// 模块名称：命名空间第四段
        /// </summary>
        public string ModuleName { get; set; }

        public List<MetaColumnInfo> MetaColumnInfos { get; set; }

        public static GeneratorModule GenerateModel(SolutionModel solution)
        {
            /**
           * 需要获取：
           * 1.实体主键 √
           * 2.实体类名 
           * 5.模型命名空间 √
           * 6.模块名称 
           * 7.Meta数据
           */

            GeneratorModule entityModel = new GeneratorModule();

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(solution.SelectedFilePath, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false)));
            var firstNode = syntaxTree.GetFirstClassNode();

            entityModel.EntityKeyName = GetEntityKeyName(firstNode);
            entityModel.Namespace = syntaxTree.GetNameSpace().Result;
            entityModel.Name = solution.SelectFileName.Replace(".cs", "");
            entityModel.CamelCaseName = entityModel.Name.ToCamelCase();
            entityModel.ModuleName = GetModuleName(entityModel.Namespace, entityModel.Name);

            var convertLowerSplitArray = entityModel.Name.ConvertLowerSplitArray();
            entityModel.SplitName = string.Join("-", convertLowerSplitArray);

            // 获取属性
            GetProperties(entityModel, firstNode);

            return entityModel;
        }


        private static void GetProperties(GeneratorModule entityModel, ClassDeclarationSyntax classNode)
        {
            entityModel.MetaColumnInfos = (from p in classNode.GetProperties()
                                           select new MetaColumnInfo()
                                           {
                                               StrDataType = p.Type.ToString(),
                                               Name = p.Identifier.Text,
                                               DisplayName = p.GetAnnotationStr(),
                                               CamelCaseName = p.Identifier.Text.ToCamelCase(),
                                               IsSimpleProperty = p.IsSimpleProperty(),
                                               IsRelation = p.IsRelation(),
                                               IsCollection = p.IsCollection(),
                                               AttributesList = p.AttributeLists.GetFilteredAttributeStringList(),

                                               IsCreateVisible = true,
                                               IsDtoVisible = true,
                                               IsUpdateVisible = true,
                                           }).ToList();
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