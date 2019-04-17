﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Yanusosu.AbpCodeGenerator.Extensions;

namespace Yanusosu.AbpCodeGenerator.Models
{
    public class GeneratorModule
    {
        public string EntityKeyName { get; set; }

        public string Name { get; set; }

        public string Names => Name.ToPlural();

        public string DisplayName { get; set; }

        public string CamelCaseName { get; set; }

        public string Namespace { get; set; }

        /// <summary>
        /// 解决方案命名空间：命名空间第0第1段
        /// </summary>
        public string SolutionNameSpace { get; set; }

        /// <summary>
        /// 公司名称：命名空间第0段
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 项目名称：命名空间第1段
        /// </summary>
        public string ConstName { get; set; }

        /// <summary>
        /// 模块名称：命名空间第2段
        /// </summary>
        public string ModuleName { get; set; }

        #region  vue字段

        public string ModuleSplitName => ModuleName.ConvertLowerSplitArray().JoinStringArray("-");

        public string SplitName { get; set; }

        public string TsEntityKeyName => GetTsEntityKeyName(EntityKeyName);

        #endregion

        /// <summary>
        /// 启用权限
        /// </summary>
        public bool EnableAuthorization { get; set; }

        public List<MetaColumnInfo> MetaColumnInfos { get; set; }

        public static string GetTsEntityKeyName(string entityKeyName)
        {
            switch (entityKeyName)
            {
                case "int":
                case "long":
                case "float":
                case "double":
                case "decimal":
                    return "number";

                case "string":
                    return "string";

                case "bool":
                    return "boolean";

                default:
                    return entityKeyName.ToCamelCase();
            }
        }
    }
}