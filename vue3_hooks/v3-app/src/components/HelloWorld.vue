<script setup lang="ts">
import { ref, reactive } from 'vue'
import  todoList from './todoList'
const {data,addFun} = todoList()

interface dataType{
  title:string,
  type:boolean,
  id:number
}


 
</script>

<template>
  <div>
    <div class="add-box">
        <input type="text" v-model="data.addList.title" />
        <button @click="addFun">添加</button>
    </div>
    <div>
      <table> 
        <tr>
          <th> id</th>
          <th>标题</th>
          <th>种类</th>
        </tr>
        <tr v-for="i in data.list" :key="i.id">
          <td>{{i.id}}</td>
          <td>{{i.title}}</td>
          <td>{{i.type}}</td>
        </tr>
      </table>
    </div>
  </div>
</template>

<style scoped>
 
</style>
