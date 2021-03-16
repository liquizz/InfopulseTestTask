import {EventEmitter, Injectable} from '@angular/core';
import Order from '../models/order.model';
import CustomerShort from '../models/customer-short.model';
import Status from '../models/status.model';
import {Product} from '../models/product.model';
import {BehaviorSubject, Subject} from 'rxjs';
import {ChosenProductModel} from '../models/chosen-product.model';

@Injectable({providedIn: 'root'})
export class OrdersDataService {
  chosenProducts: Product[] = [];
  currentOrder: Order = {
    comment: '',
    customerId: 0,
    orderDate: undefined,
    orderId: 0,
    productsList: [],
    statusId: 0,
    totalCost: 0
  };

  private chosenProductsChanged = new BehaviorSubject<any>(this.chosenProducts);
  private currentOrderChanged = new BehaviorSubject<any>(this.currentOrder);

  chosenProductsChangedObservable = this.chosenProductsChanged.asObservable();
  currentOrderChangedObservable = this.currentOrderChanged.asObservable();

  addChosenProduct(product: any): void {
    this.chosenProducts.push(product);
    this.chosenProductsChanged.next(this.chosenProducts);
  }

  changeOrder(order: any): void{
    this.currentOrder = order;
    this.currentOrderChanged.next(this.currentOrder);
  }

  deleteProductFromChosenProducts(productId: number): void {
    const currentProducts = this.chosenProductsChanged.getValue();
    currentProducts.forEach((item, index) => {
      if (item.productId === productId) { currentProducts.splice(index, 1); }
    });

    this.chosenProductsChanged.next(currentProducts);
  }

  clearChosenProducts(): void{
    this.chosenProducts = [];
  }
}
