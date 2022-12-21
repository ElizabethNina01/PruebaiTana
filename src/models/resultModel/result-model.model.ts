import { Data } from "../data/data.model";

export class ResultModel {
    resource_id!:string;
    fields!:any[];
    q!:string;
    records!:Data[];
    _links!:any;
    total!:number;

 
}
