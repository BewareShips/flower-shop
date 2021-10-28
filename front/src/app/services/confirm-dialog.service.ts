import { Injectable } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../assets/confirm-dialog/confirm-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmDialogService {

  constructor(private dialog: MatDialog) {
    
   }

   openConfirmDialog( msg: string){
      return this.dialog.open(ConfirmDialogComponent,{
        // width: '30%',
        panelClass:'confirm-dialog-container',
        disableClose: true,
        data:{message: msg}
      })
  }
}
