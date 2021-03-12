export interface FullOrder {
  orderId: number;
  name: string;
  address: string;
  finalPrice: number;
  statusName: string;
  orderDateCreated: Date;
  comment: string;
  customerId: number;
  statusId: number;
}

