import {Product} from './product.model';

export default interface Order{
  orderId: number;
  orderDate: Date;
  customerId: number;
  statusId: number;
  totalCost: number;
  productsList: number[];
  comment: string;
  }

