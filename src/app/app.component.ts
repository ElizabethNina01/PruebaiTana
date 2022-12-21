import { Component } from '@angular/core';
import { Data } from 'src/models/data/data.model';
import { DataService } from 'src/data.service';
import { Format } from 'src/models/format/format.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'prueba-crud';
  busqueda = '';
  allData: Data[];

  constructor(
    private dataService: DataService,
  ) { this.allData=[] as Data[]}

  ngOnInit(): void {
      this.dataService.getAllData().subscribe(
        response=>{
          this.allData=response?.result.records;
        }
      )
  }

}
