import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';
import Order from '../models/order.model';
import OrdersService from './orders.service';

export type mode = 'add' | 'edit';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
  providers: [OrdersService]
})

export class OrdersComponent implements OnInit {
  orders: Order[] = [];

  constructor(
    private http: HttpClient,
    private router: Router,
    private ordersService: OrdersService
  ) { }

  ngOnInit(): void {
    this.ordersService.fetchOrdersData().subscribe((response) => {
      this.orders = response;
    });
  }
}


