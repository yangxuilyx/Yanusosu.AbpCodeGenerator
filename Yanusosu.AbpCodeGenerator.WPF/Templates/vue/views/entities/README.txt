## api

export const @(Model.CamelCaseName)Service = new @(Model.Name)Service();

## 路由
复制以下代码到模块路由中

```
{
      path: '@(Model.SplitName)',
      name: '@(Model.Name)',
      component: () => import('/@@/views/@(Model.ModuleSplitName)/@(Model.SplitName)/index.vue'),
      meta: {
        title: '@(Model.DisplayName)管理',
         @if(Model.EnableAuthorization){
         @: roles:[@(Model.Name)]
        }
      },
    },

```

模块路由：
// @(Model.ModuleSplitName).ts

```

import { AppRouteModule } from '/@/router/types';
import { LAYOUT } from '/@/router/constant';

const @(Model.ModuleSplitName): AppRouteModule = {
  path: '/@(Model.ModuleSplitName)',
  name: '@(Model.ModuleName)',
  component: LAYOUT,
  meta: {
    // icon: 'ant-design:tool-outlined',
    title: '@(Model.ModuleName)',
     @if(Model.EnableAuthorization){
    @:roles: ["@(Model.ModuleName)"]
	}
  },
  children: [
   
  ]
};

export default @(Model.ModuleSplitName);


```

