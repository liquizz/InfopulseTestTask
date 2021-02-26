import {Component, Input, OnInit, Output} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {URL} from '../../url-helper';
import CustomerShort from '../../models/customer-short.model';
import Status from '../../models/status.model';
import Product from '../../models/product.model';
import Order from '../../models/order.model';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {
  customers: CustomerShort[];
  statuses: Status[];
  products: Product[];
  orders: Order[] = [];
  comment: Comment;
  date: Date = new Date();
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get(`${URL}Customers/CustomersShort`).subscribe(res => {
      this.customers = res as CustomerShort[];
    });
    this.http.get(`${URL}Orders/Statuses`).subscribe(res => {
      this.statuses = res as Status[];
    });
    this.http.get(`${URL}Products/`).subscribe(res => {
      this.products = res as Product[];
    });
    this.http.get(`${URL}Orders/`).subscribe(res => {
      this.orders = res as Order[];
    });
  }

}
