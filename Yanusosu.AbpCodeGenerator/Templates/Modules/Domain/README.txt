## 权限配置
在@(Model.ConstName)ApplicationModule的PreInitialize方法中添加如下代码：
```
  Configuration.Authorization.Providers.Add<@(Model.Name)AppAuthorizationProvider>();
```
## 本地化
将以下内容剪切到CORE类库的Localization/SourceFiles/Platform-zh-Hans.xml
```
	<text name="Pages.@(Model.ModuleName).@(Model.Name)" value="@(Model.DisplayName)" />
	<text name="Pages.@(Model.ModuleName).@(Model.Name).Create" value="添加@(Model.DisplayName)" />
	<text name="Pages.@(Model.ModuleName).@(Model.Name).Update" value="编辑@(Model.DisplayName)" />
	<text name="Pages.@(Model.ModuleName).@(Model.Name).Delete" value="删除@(Model.DisplayName)" />
   
   @{
	   foreach(var item in Model.MetaColumnInfos){
		      @:<text name="@(Model.Name).@(item.Name)" value="@(item.DisplayName)" />
	   }
   }

```

## 数据映射配置
将以下内容剪切到EntityFrameworkCore类库的Context中
```
    public DbSet<@(Model.Name)> @(Model.Names) { get; set; }

	// modelBuilder
	modelBuilder.ApplyConfiguration(new @(Model.Name)Cfg());
```

