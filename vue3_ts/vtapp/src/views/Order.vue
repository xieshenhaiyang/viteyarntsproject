<template>
  <div>
    <div class="select-box">
     <el-form :inline="true" :model="selectData" class="demo-form-inline">
      <el-form-item label="标题">
       <el-input v-model="selectData.title" placeholder="请输入关键字" />
      </el-form-item>
     <el-form-item label="内容">
       <el-input v-model="selectData.body" placeholder="请输入关键字" />
     </el-form-item>
     <el-form-item>
      <el-button type="primary" @click="onSubmit">查询</el-button>
     </el-form-item>
     </el-form>
    </div>

    <el-table border :data="list" style="width: 100%">
      <el-table-column prop="id" label="ID" width="180" />
      <el-table-column prop="title" label="标题" width="180" />
      <el-table-column prop="body" label="详情" />
  </el-table>
  <el-pagination @current-change="currentChage" layout="prev,pager,next" :total="selectData.cout" />
  </div>
</template>

<script lang="ts">
import { reactive,toRefs,onBeforeMount,onMounted,defineComponent, toRef} from 'vue'
import { InitData } from '../types/order'
import { getOrderList } from '../http/loginapi'

export default defineComponent({
    setup(){
      const data = reactive(new InitData())
      onMounted(()=>{
        getOrderList(data.selectData).then(res=>{
          data.selectData.cout = res.data.count;
          data.list = res.data.data;
        })
      })
      const currentChage = (page:number)=>{
        data.selectData.page=page
      }
      const onSubmit = ()=>
      {
          getOrderList(data.selectData).then(res=>{
            data.selectData.cout = res.data.count;
             data.selectData.page=res.data.page
            data.list = res.data.data;
        })
      }
      return {
        ...toRefs(data),
        currentChage,
        onSubmit
      }
    }
})
</script>

<style lang='less' scoped>

</style>