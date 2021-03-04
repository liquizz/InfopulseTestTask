import {EventEmitter, Injectable} from '@angular/core';
import Order from '../models/order.model';
import CustomerShort from '../models/customer-short.model';
import Status from '../models/status.model';
import {Product} from '../models/product.model';
import {BehaviorSubject, Subject} from 'rxjs';

@Injectable({providedIn: 'root'})
export class OrdersDataService {
  chosenProducts: Product[] = [];
  currentOrder: Order = {address: '', finalPrice: 0, name: '', orderId: 0, statusName: ''};

  private chosenProductsChanged = new BehaviorSubject<any>(this.chosenProducts);
  private currentOrderChanged = new BehaviorSubject<any>(this.currentOrder);

  chosenProductsChangedObservable = this.chosenProductsChanged.asObservable();
  currentOrderChangedObservable = this.currentOrderChanged.asObservable();

  addChosenProduct(product: Product): void {
    this.chosenProducts.push(product);
    this.chosenProductsChanged.next(this.chosenProducts);
  }

  changeOrder(order: any): void{
    this.currentOrder = order;
    this.currentOrderChanged.next(this.currentOrder);
  }

}
