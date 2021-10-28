import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Order } from '../models/order.model';
import { ConfirmDialogService } from '../services/confirm-dialog.service';
import { OrderService } from '../services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orderList: Order[];

  constructor(private service: OrderService,
    private router: Router,
    private toastr: ToastrService,
    private dialogService: ConfirmDialogService
    ) { }

  ngOnInit(): void {
    this.refreshList();
  }



  refreshList() {
    this.service.getOrderList().then(res => this.orderList = res as Order[]);
  }



  onOrderDelete(id: number) {
    // if (confirm('Are you sure to delete this record?')) {
    //   this.service.deleteOrder(id).then(res => {
    //     console.log(res)
    //     this.refreshList();
    //     this.toastr.warning("Deleted Successfully", "Restaurent App.");
        
    //   }).catch(err=>console.log(err));
    // }

    this.dialogService.openConfirmDialog('Are you sure to delete').afterClosed().subscribe(res =>{
      if(res){
        this.service.deleteOrder(id).then(res => {
          this.refreshList();
          this.toastr.warning("Deleted Successfully", "Restaurent App.");
          
        }).catch(err=>console.log(err));
      }
      
    });
  }

}
