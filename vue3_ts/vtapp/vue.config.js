module.exports = {
    devServer: {     
            open: false, // 是否自动弹出浏览器页面    
            host: '127.0.0.1',
            port: '8080',
            https: false, // 是否使用https协议  
            hotOnly: true, // 是否开启热更新
            disableHostCheck: true,
            proxy: {
                   '/api': {  //这个名字与 interceptors.ts 中的 baseURL 一定要一致，切记！
                         target: 'http://127.0.0.1:8082/api',
                         changeOrigin: true,
                         ws: true,
                         pathRewrite: {
                               '^/api': ''
                             }
                       }
                 }
           }
}