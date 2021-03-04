import {Component, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {URL} from '../../url-helper';
import CustomerShort from '../../models/customer-short.model';
import Status from '../../models/status.model';
import {Product} from '../../models/product.model';
import Order from '../../models/order.model';
import OrdersService from '../orders.service';
import {OrdersDataService} from '../order-data.service';
import OrderShort from '../../models/order-short.model';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit, OnDestroy {

  customers: CustomerShort[];
  statuses: Status[];
  chosenProducts: any[] = []; // TODO: Change this later
  orders: OrderShort[] = [];
  comment: Comment;
  date: Date = new Date();

  currentOrderId: number;
  currentOrder: Order;

  totalCost: number;

  constructor(
    private http: HttpClient,
    private ordersService: OrdersService,
    private ordersDataService: OrdersDataService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.ordersService.fetchOrdersData().subscribe((response: OrderShort[]) => {
      this.orders = response;
    });
    this.ordersService.fetchShortCustomersData().subscribe((response: CustomerShort[]) => {
      this.customers = response;
    });
    this.ordersService.fetchStatusesData().subscribe((response: Status[]) => {
      this.statuses = response;
    });
    // this.ordersService.fetchProductsData().subscribe((response: Product[]) => {
    //   this.products = response;
    // });
    this.currentOrderId = this.route.snapshot.params.id;
    this.ordersDataService.chosenProductsChangedObservable.subscribe(res => {
      this.chosenProducts = res;
    });
  }

  onSubmitClicked(order): void {
    // const formData = new FormData();
    //
    // formData.append('customerId', order.customer);
    // formData.append('statusId', order.status);
    // formData.append('orderDate', this.date.toDateString());
    // formData.append('totalCost', this.totalCost.toString());
    // formData.append('productsList', JSON.stringify({}));
    //
    // this.ordersService.createOrder(formData).subscribe(res => {
    //   console.log(res);
    // });
  }

  onAddProductClicked(formData: {
    customer: number,
    status: number,
    comment: string
  }): void{
    const updatedOrder: Order = {
      customerId: formData.customer,
      orderDate: this.date,
      orderId: this.currentOrderId,
      productsList: this.chosenProducts,
      statusId: formData.status,
      totalCost: 0, // Calculate here
      comment: formData.comment
    };

    this.ordersDataService.changeOrder(updatedOrder);
    this.router.navigate(['orders', this.route.snapshot.params.id, 'add-product']);
  }

  ngOnDestroy(): void {

  }

}
