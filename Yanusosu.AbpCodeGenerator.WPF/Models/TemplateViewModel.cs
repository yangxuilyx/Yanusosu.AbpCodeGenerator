﻿using System.Collections.Generic;
using System.IO;

namespace Yanusosu.AbpCodeGenerator.WPF.Models
{
    public class TemplateViewModel
    {
        public string TemplatePath { get; set; }

        public string GenerateCode { get; set; }

        public string FilePath { get; set; }

        public string SavePath { get; set; }

        public static List<TemplateViewModel> GetNormalViewModels(SolutionModel model, GeneratorModule module)
        {
            var basePath = Path.GetDirectoryName(typeof(TemplateViewModel).Assembly.Location);

            return new List<TemplateViewModel>()
            {
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain","EntityManager.txt"),
                    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Modules\Domain\",module.Names),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}",$"{module.Name}Manager.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain","README.txt"),
                    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Modules\Domain\",module.Names),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}","README.md"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain\Authorization","EntityAppPermissions.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization",$"{model.ClassName}AppPermissions.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain\Authorization","EntityAuthorizationProvider.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Authorization",$"{model.ClassName}AuthorizationProvider.cs"),
                },
                // Application 
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","PagedEntityResultRequestDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"Paged{model.ClassName}ResultRequestDto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","EntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","CreateEntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"Create{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dto","UpdateEntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dto",$"Update{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application","IEntityAppService.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}",$"I{model.ClassName}AppService.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application","EntityAppService.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}",$"{model.ClassName}AppService.cs"),
                },
                // EntityFrameworkCore
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\EntityFrameworkCore\Configurations","EntityCfg.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\EntityFrameworkCore\Configurations\{module.Names}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\EntityFrameworkCore\Configurations\{module.Names}",$"{model.ClassName}cfg.cs"),
                },

                // vue
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","entity.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"{module.SplitName}.vue"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","create-entity.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"create-{module.SplitName}.vue"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","README.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"README.md"),
                },
            };
        }
    }


}