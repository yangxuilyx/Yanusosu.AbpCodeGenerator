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
		  @if(Model.EnableAuthorization){
        permission: "Pages.@(Model.ModuleName).@(Model.Name)"
		}
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
		  @if(Model.EnableAuthorization){
        permission: "Pages.@(Model.ModuleName).@(Model.Name).Create"
		}
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
		  @if(Model.EnableAuthorization){
        permission: "Pages.@(Model.ModuleName).@(Model.Name).Update"
		}
      }
    },

```

模块路由：
// @(Model.ModuleSplitName).ts

```
import { RouteConfig } from "vue-router";

import Layout from "@@/layout/index.vue";

const @(Model.ModuleSplitName)Router: RouteConfig = {
  path: "/@(Model.ModuleSplitName)",
  name: "@(Model.ModuleName)",
  component: Layout,
  meta: {
    title: "@(Model.ModuleName)",
    icon: "@(Model.ModuleSplitName)",
	  @if(Model.EnableAuthorization){
    permission: "Pages.@(Model.ModuleName)"
	}
  },
  children: []
};

export default @(Model.ModuleSplitName)Router;

```

