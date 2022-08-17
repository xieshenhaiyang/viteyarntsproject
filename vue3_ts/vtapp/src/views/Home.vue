<template>
<div class="common-layout">
    <el-container>
      <el-header>
        <el-row :gutter="20">
          <el-col :span="4"><img class="logo" src="../assets/logo.png" alt="" />
          </el-col>
          <el-col :span="16"><h2>后台管理系统</h2></el-col>
          <el-col class="btn-text" :span="4"> 
            <el-button  type="text">XHS</el-button>
          </el-col>
          </el-row>
      </el-header>

      <el-container>
     <el-aside width="200px">
      <el-menu
        router
        active-text-color="#ffd04b"
        background-color="#545c64"
        class="el-menu-vertical-demo"
        default-active="2"
        text-color="#fff"
        @open="handleOpen"
        @close="handleClose"
      >
        <el-menu-item v-for="i in list" :key="i.path" :index="i.path">
          <el-icon><location /></el-icon>
            <span>{{i.meta.title}}</span>
        </el-menu-item>
      </el-menu>

        </el-aside>
        <el-container>
          <el-main>
            <router-view />
          </el-main>
          <!-- <el-footer>Footer</el-footer> -->
        </el-container>
      </el-container>
    </el-container>
  </div>
</template>

<script lang="ts">
import { defineComponent,toRefs } from 'vue';
// import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src
import { useRouter } from 'vue-router';

export default defineComponent({
  name: 'Home',
  components: {
    //HelloWorld,
  },
  setup(){
    const router = useRouter();
    const list = router.getRoutes().filter(v => v.meta.isShow);
    console.log(router)
    console.log(list)
    return {
      list
    }
  },
 
});
</script>

<style lang="less" scoped>
  .logo{
    height: 80px;
  }
  h2{
    text-align:center;
    color: #fff;
    height: 80px;
    line-height: 80px;
  }
  .el-header{
    background: pink;
  }
  .btn-text{
    height: 80px;
    line-height: 80px;
    .el-button{
      color: #fff;
    }
  }
  .el-aside{
    .el-menu{
      height: calc(100vh - 80px);
    }
  } 
</style>
