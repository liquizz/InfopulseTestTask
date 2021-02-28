import {Component, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {URL} from '../../url-helper';
import CustomerShort from '../../models/customer-short.model';
import Status from '../../models/status.model';
import {Product} from '../../models/product.model';
import Order from '../../models/order.model';
import OrdersService from '../orders.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit, OnDestroy {

  customers: CustomerShort[];
  statuses: Status[];
  products: Product[] = [];
  orders: Order[] = [];
  comment: Comment;
  date: Date = new Date();
  chosenCustomer: {customer: string, status: string, comment: string} = {customer: '', status: '', comment: ''};
  isAddButtonPressed = false;

  totalCost: number;

  constructor(
    private http: HttpClient,
    private ordersService: OrdersService
  ) { }

  ngOnInit(): void {
    this.ordersService.fetchOrdersData().subscribe((response: Order[]) => {
      this.orders = response;
    });
    this.ordersService.fetchShortCustomersData().subscribe((response: CustomerShort[]) => {
      this.customers = response;
    });
    this.ordersService.fetchStatusesData().subscribe((response: Status[]) => {
      this.statuses = response;
    });
    this.ordersService.fetchProductsData().subscribe((response: Product[]) => {
      this.products = response;
    });
  }

  onSubmitClicked(): void {

  }

  onAddProductClicked(formData): void{
    this.isAddButtonPressed = true;
  }

  onGoBackClick = () => {
    this.isAddButtonPressed = false;
  }

  ngOnDestroy(): void {

  }

}
