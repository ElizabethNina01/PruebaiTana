import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {EMPTY, EmptyError, Observable} from 'rxjs';
import { Record } from '../../models/data/data.model';
@Injectable({
  providedIn: 'root'
})
export class RecordService {
  private Path = 'https://localhost:7173/record';

  constructor(private http: HttpClient) {}
  
 

  getAll(): Observable<Record[]>{
    return this.http.get<Record[]>(this.Path);
  }

  deleteRecord(id: number): Observable<Record> {
    return this.http.delete<Record>(this.Path +  '/'+ id.toString());
  }
 
  updateRecordbyId(id: number, data: Record): Observable<Record>{
    return this.http.put<Record>(this.Path + '/'+id.toString(),data);
  }

  postRecord(data: any): Observable<Record> {
    return this.http.post<Record>(this.Path, data);
  }
}
