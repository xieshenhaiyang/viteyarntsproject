import { createRouter, createWebHashHistory, createWebHistory, RouteRecordRaw } from 'vue-router'
import Home from '../views/Home.vue'
import {getRouter} from '../http/loginapi'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    // children:[
  //     {
  //       path: 'order',//子路由不要/
  //       name: 'order',
  //       meta:{
  //         title : "订单列表",
  //         isShow : 'true'
  //       },
  //       component: () => import(/* webpackChunkName: "login" */ '../views/Order.vue')
  //     },
  //     {
  //       path: 'user',
  //       name: 'user',
  //       meta:{
  //         title : "用户列表",
  //         isShow : 'true'
  //       },
  //       component: () => import(/* webpackChunkName: "login" */ '../views/UserList.vue')
  //     }
  //   ]
   },
  {
    path: '/login',
    name: 'Login',
    component: () => import(/* webpackChunkName: "login" */ '../views/Login.vue')
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

// 路由拦截
router.beforeEach(async to =>{
  // 如果没有登录则只能进入登录界面
  let token:string | null = localStorage.getItem("token");
  if (!token && to.path != "/login")
  {
    return "/login";
  }else if(to.path !== "/login" && token)
  {
    // 动态添加路由 每一次都会跳转到这里，判断是否已经存在
    if(router.getRoutes().length === 3)
    {
    let routeData:any = await getRouter();
    routeData = routeData.data.data
    console.log(routeData)
    routeData.forEach((v:any) => {
      let routerObj:RouteRecordRaw = {
        name:v.name,
        path:v.path,
        meta:v.meta,
        component: () => import(/* webpackChunkName: "[request]" */ `../views/${v.path}.vue`)
      }
      router.addRoute("Home", routerObj);
    });
    router.replace(to.path)
  }
}
})

export default router
