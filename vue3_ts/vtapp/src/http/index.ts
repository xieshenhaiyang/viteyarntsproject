import axios from 'axios';
import {ElMessage} from 'element-plus'

// 封装错误
enum MSGS{
    "操作成功" = 200,
    "token错误" = 401,
    "未授权" = 403,
    "请求异常"
}

const $http = axios.create({
    baseURL:"/api",
    timeout:203300,
    headers:{
        "Content-Type":"application/json;charset=utf-8",
        // "Access-Control-Allow-Origin":"*"
        // config.headers['Content-Type'] = 'application/json;charset=utf-8';
    }
})

// 请求拦截
$http.interceptors.request.use(config =>{
    // 取不到赋值
    config.headers = config.headers || {}
    if(localStorage.getItem('token'))
    {
        config.headers.Authorization  = 'bearer '+(localStorage.getItem('token')||'')
    }
    return config;
})
// 拦截器
$http.interceptors.response.use(res => {
    // {
    //     code:200,
    //     data:{},
    //     msg:"请求成功"
    // }
    const code:number = res.data.code
    if (code !== 200){
        ElMessage.error(MSGS[code])
        return Promise.reject(res.data)
    }
    return res;
}, err=>{
    const code:number = err.response.data.Code
    ElMessage.error(MSGS[code])
})

export default $http