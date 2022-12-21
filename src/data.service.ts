import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {EMPTY, EmptyError, Observable} from 'rxjs';
import { Data } from './models/data/data.model';
import { Format } from './models/format/format.model';
import { ResultModel } from './models/resultModel/result-model.model';
@Injectable({
  providedIn: 'root'
})
export class DataService {
  private Path = 'https://data.gov.sg/api/action/datastore_search?resource_id=f5542e9d-58d5-48dc-b8c6-4ba692318b41';

  nnn: ResultModel;
  constructor(private http: HttpClient) {this.nnn={} as ResultModel}
  
  getDataById(Id: number): Observable<Data> {
    return this.http.get<Data>(this.Path +Id.toString());
  }

  getAllData(): Observable<Format>{
    return this.http.get<Format>(this.Path);
  }

 
}
