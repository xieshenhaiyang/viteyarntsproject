import { ref,reactive } from "vue"; // 方法
import type { ITodList } from '../type/todoList' // 类型

interface IData {
    list:ITodList[],
    addList:ITodList
}

// 参数类型约束
const data = reactive<IData>({
    list:[],
    addList:{
      title:"",
      type:false,
      id:0
    }
  })
const addFun = () => {
    // data.list.push(data.addList);
    data.list.push({...data.addList, id: data.list.length + 1})
}

export default ()=>({
    data,
    addFun
})
// hooks是一个函数
