import {Component, Input, OnInit, Output} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {URL} from '../url-helper';

interface Customer{
  customerId: number;
  name: string;
  address: string;
  createdDate: Date;
}

interface Status {
  statusId: number;
  statusName: string;
}

interface Product {
  productId: number;
  productDate: Date;
  name: string;
  quantity: number;
  price: any;
  productCategories: any;
  productSizes: any;
  productDescriptions: any;
}

interface Comment{
  commentId: number;
  comment: string;
}

interface Order{
  orderId: number;
  name: string;
  address: string;
  finalPrice: number;
  statusName: string;
}

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {
  customers: Customer[];
  statuses: Status[];
  products: Product[];
  orders: Order[] = [];
  comment: Comment;
  date: Date = new Date();
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get(`${URL}Customers/CustomersShort`).subscribe(res => {
      this.customers = res as Customer[];
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
