import {Product} from './product.model';
import Status from './status.model';

export default interface OrderShort{
  orderId: number;
  name: string;
  address: string;
  finalPrice: number;
  statusName: string;
}
