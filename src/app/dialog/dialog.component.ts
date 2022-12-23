
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Validators, FormGroup, FormBuilder, FormControl, FormGroupDirective,
   NgForm} from '@angular/forms';
import { Record } from 'src/models/data/data.model';
import { RecordService } from 'src/record.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
})
export class DialogComponent implements OnInit {
  opcion= '';
  itemModel: Record = new Record();
  id=0;
  year='';
  area='';
  rank=0.0;
  domestic=0;
  constructor(@Inject(MAT_DIALOG_DATA) public data: string, 
    private matDialogRef: MatDialogRef<DialogComponent>, private service: RecordService) {

    this.opcion=data; 
    
  }

  ngOnInit(): void {
    
  }
  enviar(){
    
    switch(this.opcion){
      case 'Insertar':{
       
        this.reloadPage();
      };break;

      case 'Modificar':{
        this.reloadPage();
      };break;

      case 'Eliminar':{
        this.reloadPage();
      };break;
    }
    this.matDialogRef.close();

  }
  reloadPage(){
    window.location.reload()
  }
}
