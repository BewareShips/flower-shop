import { CustomerService } from 'src/app/services/customer.service';
import { OrderService } from 'src/app/services/order.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/models/customer.model';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { OrderItemsComponent } from '../order-items/order-items.component';
import { OrderItem } from 'src/app/models/order-item.model';
import { Order } from 'src/app/models/order.model';
import { ConfirmDialogService } from 'src/app/services/confirm-dialog.service';


@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  customerList: Customer[];
  isValid: boolean = true;
  // OrderId=100;
  constructor(public service: OrderService,
    private customerService: CustomerService,
    private toastr: ToastrService,
    private router: Router,
    private currentRoute: ActivatedRoute,
    private dialog: MatDialog,
    private dialogService: ConfirmDialogService) { }

  ngOnInit(): void {
    let orderID = this.currentRoute.snapshot.paramMap.get('id');
    if (orderID == null)
      this.resetForm();
    else {
      this.service.getOrderByID(parseInt(orderID)).then((res: { order: Order; orderDetails: OrderItem[]; }) => {
        this.service.formData = res.order;
        this.service.orderItems = res.orderDetails;
      });
    }
    this.customerService.getCustomerList().then((res) => {
      this.customerList = res as Customer[];
    });


  }

  resetForm(form?: NgForm) {
    // if (form = null)
    //   form.resetForm();
    this.service.formData = {
      orderID: 0,
      orderNo: Math.floor(100000 + Math.random() * 900000).toString(),
      customerID: 0,
      pMethod: '',
      gTotal: 0,
      deletedOrderItemIDs: ''
    };
    this.service.orderItems = [];
  }

  AddOrEditOrderItem(orderItemIndex: any, OrderID: any, e: any) {

    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.disableClose = true;
    dialogConfig.width = "50%";
    dialogConfig.data = { orderItemIndex, OrderID };
    this.dialog.open(OrderItemsComponent, dialogConfig).afterClosed().subscribe(res => {
      this.updateGrandTotal();
    });
  }

  onDeleteOrderItem(orderItemID: number, i: number) {

    this.dialogService.openConfirmDialog('Are you sure to delete').afterClosed().subscribe(res => {
      if (res) {
        if (orderItemID != null)
          this.service.formData.deletedOrderItemIDs += orderItemID + ",";
        this.service.orderItems.splice(i, 1);
        this.updateGrandTotal();
      }
    });
  }

  updateGrandTotal() {
    this.service.formData.gTotal = this.service.orderItems.reduce((prev, curr) => {
      return prev + curr.Total;
    }, 0);
    this.service.formData.gTotal = parseFloat(this.service.formData.gTotal.toFixed(2));
  }

  validateForm() {
    this.isValid = true;
    if (this.service.formData.customerID == 0)
      this.isValid = false;
    else if (this.service.orderItems.length == 0)
      this.isValid = false;
    return this.isValid;
  }

  onSubmitValue(form: NgForm) {

    if (this.validateForm()) {
      this.dialogService.openConfirmDialog('Are you sure to sumbit order ?').afterClosed().subscribe(res => {
        if (res) {

          this.service.saveOrUpdateOrder().subscribe(res => {
            this.resetForm();
            this.toastr.success('Submitted Successfully', 'Bouquet App.');
            this.router.navigate(['/orders']);
          });
        }
      });
    }
  }
}
