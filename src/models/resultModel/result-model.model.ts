import { Record } from "../data/data.model";

export class ResultModel {
    resource_id!:string;
    fields!:any[];
    q!:string;
    records!:Record[];
    _links!:any;
    total!:number;

 
}
