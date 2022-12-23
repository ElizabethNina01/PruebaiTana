import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {EMPTY, EmptyError, Observable} from 'rxjs';
import { Record } from './models/data/data.model';
import { Format } from './models/format/format.model';
import { ResultModel } from './models/resultModel/result-model.model';
@Injectable({
  providedIn: 'root'
})
export class DataService {
  private Path = 'https://data.gov.sg/api/action/datastore_search?resource_id=f5542e9d-58d5-48dc-b8c6-4ba692318b41';

  constructor(private http: HttpClient) {}
  
  getDataById(Id: number): Observable<Record> {
    return this.http.get<Record>(this.Path +Id.toString());
  }

  getAllData(): Observable<Format>{
    return this.http.get<Format>(this.Path);
  }

  getByWord(word: string): Observable<Format>{
    return this.http.get<Format>(this.Path+"&q="+word);
  }
}
