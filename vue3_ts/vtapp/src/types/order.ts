export interface IListInt{
    userId:number,
    id:number,
    title:string,
    body:string
}

interface SelectDataInt{
    title:string,
    body:string,
    page:number,
    cout:number
}

export class InitData{
    selectData:SelectDataInt = {
        title:'',
        body:'',
        page:1,
        cout:10
    }
    list:IListInt[] = []
}