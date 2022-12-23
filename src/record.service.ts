import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {EMPTY, EmptyError, Observable} from 'rxjs';
import { Record } from './models/data/data.model';
@Injectable({
  providedIn: 'root'
})
export class RecordService {
  private Path = 'https://localhost:7173/record';

  constructor(private http: HttpClient) {}
  
 

  getAll(): Observable<Record[]>{
    return this.http.get<Record[]>(this.Path);
  }

  
}
