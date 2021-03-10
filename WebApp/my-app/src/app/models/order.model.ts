import {ChosenProductModel} from './chosen-product.model';

export default interface Order{
  orderId: number;
  orderDate: Date;
  customerId: number;
  statusId: number;
  totalCost: number;
  productsList: ChosenProductModel[];
  comment: string;
  }

