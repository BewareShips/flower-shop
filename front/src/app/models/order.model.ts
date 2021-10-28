// export class Order {
//   OrderID: number | null = null;
//   OrderNo: string ='';
//   CustomerID: number | null = null;
//   PMethod: string = '';
//   GTotal: number | null = null;
//   DeletedOrderItemIDs: string = '';
// }

export class Order {
  orderID: number  = 0;
  orderNo: string ='';
  customerID: number  = 0;
  customer?: string;
  pMethod: string = '';
  gTotal: number  = 0;
  deletedOrderItemIDs: string = '';
}

