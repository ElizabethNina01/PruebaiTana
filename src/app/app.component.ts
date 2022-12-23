import { Component } from '@angular/core';
import { Record } from 'src/models/data/data.model';
import { DataService } from 'src/data.service';
import { Format } from 'src/models/format/format.model';
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import { DialogComponent } from './dialog/dialog.component';
import { RecordService } from 'src/record.service';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'prueba-crud';
  busqueda = '';
  allData: Record[];
  allRecords: Record[];
  constructor(
    private dataService: DataService,
    private recordService: RecordService,
    private dialog: MatDialog,
  ) { this.allData=[] as Record[];
  this.allRecords=[] as Record[]}

  ngOnInit(): void {
      this.dataService.getAllData().subscribe(
        response=>{
          this.allData=response?.result.records;
        }
      );
      this.recordService.getAll().subscribe(
        response=>{
          this.allRecords=response;
        }
      )
  }

  buscar(){
    this.dataService.getByWord(this.busqueda).subscribe(
      response=>{
        this.allData=response?.result.records;
      }
    );
  
  }

  openDialog(opcion: string) {
    
    this.dialog.open(DialogComponent,{data: opcion});
    
  }
}
