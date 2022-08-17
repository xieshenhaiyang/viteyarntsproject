function Person(name){
    this.name = name
    this.age = 18
    console.log(this)//Person 构造函数本身。
    this.sayHi = ()=>{
        console.log(this.name+",早上好！")
    }
}
export default Person