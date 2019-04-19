## 路由


复制以下代码到模块路由children中

```
appRouters:

 {
        path: "@(Model.CamelCaseName)",
        meta: { title: "@(Model.DisplayName)", dontOpenNew: false },
        name: "@(Model.CamelCaseName)",
        component: () =>
          import("../views/@(Model.ModuleName)/@(Model.SplitName)/@(Model.SplitName).vue")
      }

```

```
otherRouters:
{
      path: "create-@(Model.SplitName)",
      meta: { title: "创建@(Model.DisplayName)", dontOpenNew: true },
      name: "create@(Model.Name)",
      component: () =>
        import("../views/@(Model.ModuleName)/@(Model.SplitName)/create-@(Model.SplitName).vue")
}
```