import { Student } from "./Student";

export interface Selection{
    id: number,
    name:string,
    startDate: Date,
    endDate: Date,
    status: number,
    jap:string,
    japId:number,
    students:Student[]

}