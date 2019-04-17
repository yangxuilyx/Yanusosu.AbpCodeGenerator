using System;
using System.Collections.Generic;
using System.IO;
using Yanusosu.AbpCodeGenerator.Models;

namespace WpfApp1
{
    public class TemplateViewModel
    {
        public string TemplatePath { get; set; }

        public string GenerateCode { get; set; }

        public string FilePath { get; set; }

        public string SavePath { get; set; }

        public static List<TemplateViewModel> GetNormalViewModels(SolutionModel model,GeneratorModule module)
        {
            var basePath = Environment.CurrentDirectory;
            return new List<TemplateViewModel>()
            {
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Domain","EntityManager.txt"),
                    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Domain\",module.Names),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Domain\{module.Names}",$"{module.Name}Manager.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Domain","ReadMe.txt"),
                    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Domain\",module.Names),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Domain\{module.Names}","ReadMe.md"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Domain\Authorization","EntityAppPermissions.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Domain\{module.Names}\Authorization"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Domain\{module.Names}\Authorization",$"{model.ClassName}AppPermissions.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Domain\Authorization","EntityAuthorizationProvider.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Domain\{module.Names}\Authorization"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Domain\{module.Names}\Authorization",$"{model.ClassName}AuthorizationProvider.cs"),
                },
                // Application 
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Application\Dto","PagedEntityResultRequestDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto",$"Paged{model.ClassName}ResultRequestDto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Application\Dto","EntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto",$"{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Application\Dto","CreateEntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto",$"Create{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Application\Dto","UpdateEntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}\Dto",$"Update{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Application","IEntityAppService.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}",$"I{model.ClassName}AppService.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Application","EntityAppService.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Application\{module.Names}",$"{model.ClassName}AppService.cs"),
                },
                // EntityFrameworkCore
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\EntityFrameworkCore\Configurations","EntityCfg.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\EntityFrameworkCore\Configurations\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\EntityFrameworkCore\Configurations\{module.Names}",$"{model.ClassName}cfg.cs"),
                },

            };
        }
    }


}