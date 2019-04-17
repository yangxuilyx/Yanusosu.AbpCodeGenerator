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
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain","EntityManager.txt"),
                //    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Modules\Domain\",module.Names),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}",$"{module.Name}Manager.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain","ReadMe.txt"),
                //    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Modules\Domain\",module.Names),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}","ReadMe.md"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain\Authorization","EntityAppPermissions.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization",$"{model.ClassName}AppPermissions.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain\Authorization","EntityAuthorizationProvider.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization",$"{model.ClassName}AuthorizationProvider.cs"),
                //},
                //// Application 
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","PagedEntityResultRequestDto.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"Paged{model.ClassName}ResultRequestDto.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","EntityDto.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"{model.ClassName}Dto.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","CreateEntityDto.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"Create{model.ClassName}Dto.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","UpdateEntityDto.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"Update{model.ClassName}Dto.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application","IEntityAppService.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}",$"I{model.ClassName}AppService.cs"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application","EntityAppService.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}",$"{model.ClassName}AppService.cs"),
                //},
                //// EntityFrameworkCore
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\EntityFrameworkCore\Configurations","EntityCfg.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\EntityFrameworkCore\Configurations\{module.Names}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\EntityFrameworkCore\Configurations\{module.Names}",$"{model.ClassName}cfg.cs"),
                //},

                // vue
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\vue\store\entities","entity.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\store\entities\"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\store\entities\",$"{module.SplitName}.ts"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\vue\store\modules","entity.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\store\modules\"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\store\modules\",$"{module.SplitName}.ts"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","entity.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleName}\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleName}\{module.Names}",$"{module.SplitName}.vue"),
                },
            };
        }
    }


}