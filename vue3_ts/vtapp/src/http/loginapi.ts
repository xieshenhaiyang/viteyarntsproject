import $http from './index'

interface loginData{
    userName:string,
    passWord:string
}

export const login = (data:loginData)=>$http({url:"/login",method:"post",data})
export const getOrderList = (data:any)=>$http({url:"/orders",method:"post",data})
export const getRouter = ()=>$http({url:"/menus",method:"get"})