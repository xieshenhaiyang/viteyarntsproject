import type {FormInstance} from 'element-plus'
import {ref} from 'vue'

export interface iLofinFormInt {
    userName:string,
    passWord:string
}

export class InitData{
    loginForm:iLofinFormInt = {
        userName:'',
        passWord:''
    }
    loginFormRef = ref<FormInstance>()
}