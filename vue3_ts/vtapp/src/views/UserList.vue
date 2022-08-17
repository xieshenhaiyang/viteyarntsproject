<!-- 用户管理 dyb -->
<template>
  <div>333</div>
</template>

<script lang='ts'>
import { reactive,toRefs,onBeforeMount,onMounted,defineComponent} from 'vue'
interface DataProps {}
export default defineComponent ({
      setup() {
          console.log('1-开始创建组件-setup')
          const data: DataProps = reactive({

          })
          onBeforeMount(() => {
              console.log('2.组件挂载页面之前执行----onBeforeMount')
          })
          onMounted(() => {
              console.log('3.-组件挂载到页面之后执行-------onMounted')
          })
          const refData = toRefs(data);
          return {
              ...refData,
          }
      }
  })
</script>
<style lang='less' scoped>
</style>
