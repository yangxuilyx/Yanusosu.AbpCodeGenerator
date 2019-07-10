## 路由


复制以下代码到模块路由中

```
{
      path: "@(Model.SplitName)",
      name: "@(Model.Name)",
      component: () =>
        import(
          /* webpackChunkName: "@(Model.CamelCaseName)" */ "@@/views/@(Model.ModuleSplitName)/@(Model.SplitName)/index.vue"
        ),
      meta: {
        title: "@(Model.DisplayName)管理",
        permission: "Pages.@(Model.ModuleName).@(Model.Name)"
      }
    },
    {
      path: "@(Model.SplitName)/create",
      name: "Create@(Model.Name)",
      component: () =>
        import(
          /* webpackChunkName: "create-@(Model.SplitName)" */ "@@/views/@(Model.ModuleSplitName)/@(Model.SplitName)/create-@(Model.SplitName).vue"
        ),
      meta: {
        title: "添加@(Model.DisplayName)",
        hidden: true,
        permission: "Pages.@(Model.ModuleName).@(Model.Name).Create"
      }
    },
    {
      path: "@(Model.SplitName)/update/:id",
      name: "Update@(Model.Name)",
      component: () =>
        import(
          /* webpackChunkName: "update-@(Model.SplitName)" */ "@@/views/@(Model.ModuleSplitName)/@(Model.SplitName)/update-@(Model.SplitName).vue"
        ),
      meta: {
        title: "修改@(Model.DisplayName)",
        hidden: true,
        permission: "Pages.@(Model.ModuleName).@(Model.Name).Update"
      }
    },

```

