<template>
 <div class="login-box">
  <el-form :model="loginForm" status-icon
   :rules="rules" ref="loginFormRef" 
   label-width="70px" class="loginForm">
    <el-form-item label="账号" prop="userName">
     <el-input v-model="loginForm.userName" autocomplete="off"></el-input>
    </el-form-item>
    <el-form-item label="密码" prop="passWord">
     <el-input type="password"  v-model="loginForm.passWord" autocomplete="off"></el-input>
    </el-form-item>
    <el-form-item>
    <el-button type="primary" @click="submitForm(loginFormRef)">提交</el-button>
    <el-button @click="resetForm(loginFormRef)">重置</el-button>
    </el-form-item>
</el-form>
</div>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs } from 'vue'
import { InitData } from '../types/login'
import type {FormInstance} from 'element-plus'
import {login} from '../http/loginapi'

import {useRoute} from 'vue-router'
import router from '@/router'

export default defineComponent({
    setup(){
        const data = reactive(new InitData())
        const rules = {
                userName: [
                    {required:true,message:'请输入账号',triger:blur},
                    {
                        min:1,
                        max:24,
                        message:"账号长度需要在1-24之间",
                        triger:blur,
                    }
                ],
                passWord: [
                    {required:true,message:'请输入密码',triger:blur},
                    {
                        min:1,
                        max:24,
                        message:"密码长度需要在1-24之间",
                        triger:blur,
                    }
                ]
            }
        const submitForm = (loginFormRef:FormInstance)=>{
            loginFormRef.validate((valid:boolean) => {
            if (valid) {
                login(data.loginForm).then(res=>{
                    localStorage.setItem("token",res.data.data.token);
                    router.push("/");
                });
            } else {
                console.log('error submit!!');
                return false;
            }});
        }
        const resetForm = (loginFormRef:FormInstance)=>{
            loginFormRef.resetFields();
        }
        
        return {
            ...toRefs(data),
            rules,
            submitForm,
            resetForm
        }
    }
}

) 
</script>

<style lang='less' scoped>
.login-box{
    width: 100%;
    height: 100%;
    padding-top: 200px;
    box-sizing: border-box;

    .loginForm{
    width: 450px;
    height: 20px;
    background: #fff;
    border-radius: 20px;
    margin: 0 auto;
  }
}


</style>