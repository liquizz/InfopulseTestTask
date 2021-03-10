import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';
import Order from '../models/order.model';
import {OrdersService} from './orders.service';
import {OrdersDataService} from './order-data.service';

// export type mode = 'add' | 'edit';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})

export class OrdersComponent implements OnInit {
  orders: any[] = [];
  currentOrder: Order = {
    comment: '',
    customerId: 0,
    orderDate: undefined,
    orderId: 0,
    productsList: [],
    statusId: 0,
    totalCost: 0
  };

  constructor(
    private http: HttpClient,
    private router: Router,
    private ordersService: OrdersService,
    private ordersDataService: OrdersDataService
  ) { }

  ngOnInit(): void {
    this.ordersService.fetchOrdersData().subscribe((response) => {
      this.orders = response;
    });
    this.ordersDataService.currentOrderChangedObservable.subscribe(res => {
      this.currentOrder = res;
    });
  }

  onNewOrderClicked = () => {
    const newOrder: any = {
      orderDate: new Date()
    };
    this.ordersService.createOrder(newOrder).subscribe(res => {
      this.ordersDataService.changeOrder(res);
      this.router.navigate(['orders', res.orderId , 'new']);
    });
  }
}


