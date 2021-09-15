using System.Collections.Generic;
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
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain","README.txt"),
                //    SavePath = Path.Combine(model.FilePath,@"_GenerateCode\Modules\Domain\",module.Names),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}","README.md"),
                //},
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain\Permissions","EntityPermissions.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Permissions"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Permissions",$"{model.ClassName}Permissions.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Domain\Permissions","EntityPermissionDefinitionProvider.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Permissions"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Domain\{module.Names}\Permissions",$"{model.ClassName}PermissionDefinitionProvider.cs"),
                },
                // Application 
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dtos","PagedEntityInput.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos",$"Paged{model.ClassName}Input.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dtos","EntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos",$"{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dtos","CreateEntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos",$"Create{model.ClassName}Dto.cs"),
                },
                new TemplateViewModel()
                {
                    TemplatePath = Path.Combine(basePath,@"Templates\Modules\Application\Dtos","UpdateEntityDto.txt"),
                    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos"),
                    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\Application\{module.Names}\Dtos",$"Update{model.ClassName}Dto.cs"),
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
                //// EntityFrameworkCore
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\Modules\EntityFrameworkCore\Configurations","EntityCfg.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\EntityFrameworkCore\Configurations\{module.Names}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\Modules\EntityFrameworkCore\Configurations\{module.Names}",$"{model.ClassName}cfg.cs"),
                //},

                //// vue
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\vue\api","entity.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\api\{module.ModuleSplitName}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\api\{module.ModuleSplitName}",$"{module.SplitName}.ts"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","entity.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"index.vue"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","create-entity.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"create-{module.SplitName}.vue"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","update-entity.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"update-{module.SplitName}.vue"),
                //},
                //new TemplateViewModel()
                //{
                //    TemplatePath = Path.Combine(basePath,@"Templates\vue\views\entities","README.txt"),
                //    SavePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}"),
                //    FilePath = Path.Combine(model.FilePath,$@"_GenerateCode\vue\views\{module.ModuleSplitName}\{module.SplitName}",$"README.md"),
                //},
            };
        }
    }


}