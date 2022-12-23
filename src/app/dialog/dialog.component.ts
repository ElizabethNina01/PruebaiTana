
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Validators, FormGroup, FormBuilder, FormControl, FormGroupDirective,
   NgForm} from '@angular/forms';
import { Record } from 'src/models/data/data.model';
import { RecordService } from 'src/services/record/record.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
})
export class DialogComponent implements OnInit {
  opcion= '';
  recordModel: Record = new Record();
  id=0;
  year='';
  area='';
  rank=0.0;
  domestic='';
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: string, 
    private matDialogRef: MatDialogRef<DialogComponent>, 
    private service: RecordService) {
 
    this.opcion=data; 
  }

  ngOnInit(): void {
    
  }
  enviar(){
    
    switch(this.opcion){
      case 'Insertar':{
        this.recordModel.area=this.area;
        this.recordModel.rank=this.rank;
        this.recordModel.year=this.year;
        this.recordModel.domestic_exports=this.domestic;
        this.service.postRecord(this.recordModel).subscribe();
        this.reloadPage();
      };break;

      case 'Eliminar':{
        this.service.deleteRecord(this.id).subscribe();
        this.reloadPage();
      };break;
      
      default:{
        this.recordModel.area=this.area;
        this.recordModel.rank=this.rank;
        this.recordModel.year=this.year;
        this.recordModel.domestic_exports=this.domestic;
        var x = this.opcion;
        var y: number = +x;
        this.service.updateRecordbyId(y,this.recordModel).subscribe();

        console.log(y);this.reloadPage();
      };break;

      
    }
    this.matDialogRef.close();

  }
  reloadPage(){
    window.location.reload()
  }
}
