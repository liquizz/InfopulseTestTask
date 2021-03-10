import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import Order from "../models/order.model";
import {URL} from '../url-helper';
import CustomerShort from '../models/customer-short.model';
import Status from '../models/status.model';
import { Product } from '../models/product.model';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import Customer from '../models/customer.model';
import OrderShort from '../models/order-short.model';
import {OrdersProducts} from '../models/orders-products.model';
import {FullOrder} from '../models/full-order.model';

@Injectable()
export class OrdersService {
    orders: Order[] = [];
    customers: CustomerShort[] = [];
    statuses: Status[] = [];
    products: Product[] = [];
    ordersSelected: Order[] = []; // TODO: Change datatype to any

    chosenCustomer: CustomerShort;


    constructor(private http: HttpClient){

    }

    fetchShortCustomersData(): Observable<CustomerShort[]> {
      return this.http.get<CustomerShort[]>(`${URL}Customers/CustomersShort`);
    }

    fetchStatusesData(): Observable<Status[]> {
      return this.http.get<Status[]>(`${URL}Orders/Statuses`);
    }

    fetchProductsData(): Observable<Product[]>{
      return this.http.get<Product[]>(`${URL}Products/`);
    }

    fetchOrderData(orderId: number): Observable<FullOrder> {
      return this.http.get<FullOrder>(`${URL}orders/${orderId}`);
    }

    fetchOrdersProducts(orderId: number): Observable<OrdersProducts[]> {
      return this.http.get<OrdersProducts[]>(`${URL}orders/${orderId}/products`);
    }

    fetchOrdersData(): Observable<OrderShort[]>{
      return this.http.get<OrderShort[]>(`${URL}Orders/`);
    }

    createOrder(order: Order): Observable<any>{
      return this.http.post<any>(`${URL}Orders/`, order);
    }

    updateOrder(order: Order): Observable<boolean>{
      return this.http.post<boolean>(`${URL}Orders/${order.orderId}`, order);
    }
}
