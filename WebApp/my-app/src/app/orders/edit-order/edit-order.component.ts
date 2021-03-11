import { Component, OnInit } from '@angular/core';
import {OrdersDataService} from '../order-data.service';
import {ActivatedRoute, Router} from '@angular/router';
import Order from '../../models/order.model';
import {Product} from '../../models/product.model';
import Status from '../../models/status.model';
import {OrdersService} from '../orders.service';
import CustomerShort from '../../models/customer-short.model';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent implements OnInit {

  currentOrder: Order;
  currentOrderId: number;
  customers: CustomerShort[];

  chosenProducts: Product[];
  statuses: Status[];
  formattedDate: string;
  totalCost: number;

  constructor(
    private ordersDataService: OrdersDataService,
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.ordersService.fetchShortCustomersData().subscribe((response: CustomerShort[]) => {
      this.customers = response;
    });
    this.ordersService.fetchStatusesData().subscribe((response: Status[]) => {
      this.statuses = response;
    });
  }

  onAddProductClicked(formData: {
    customer: number,
    status: number,
    comment: string
  }): void{
    const updatedOrder: Order = {
      customerId: formData.customer,
      orderDate: this.currentOrder.orderDate,
      orderId: this.currentOrderId,
      productsList: this.chosenProducts,
      statusId: formData.status,
      totalCost: 0,
      comment: formData.comment
    };

    this.ordersDataService.changeOrder(updatedOrder);
  }

  // onRemoveProductClicked(productId: number): void {
  //
  // }

  onSubmitClicked(formData: {
    customer: number,
    status: number,
    comment: string
  }): void {
    const updatedOrder: Order = {
      customerId: this.currentOrder.customerId,
      orderDate: this.currentOrder.orderDate,
      orderId: +this.currentOrderId,
      productsList: this.chosenProducts,
      statusId: +formData.status,
      totalCost: this.totalCost,
      comment: formData.comment
    };

    this.ordersService.updateOrder(updatedOrder).subscribe(res => {

    }, error => {
      console.log(error);
    });
    this.router.navigate(['orders']);
  }

}
