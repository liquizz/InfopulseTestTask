import {Component, OnDestroy, OnInit} from '@angular/core';
import {OrdersService} from '../orders.service';
import Order from '../../models/order.model';
import {OrdersProducts} from '../../models/orders-products.model';
import {ActivatedRoute, Params} from '@angular/router';
import {Subscription} from 'rxjs';
import {FullOrder} from '../../models/full-order.model';
import {DateHelper} from '../../helpers/date-helper';



@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrls: ['./view-order.component.css']
})
export class ViewOrderComponent implements OnInit, OnDestroy {
  order: FullOrder = {address: '', finalPrice: 0, name: '', orderDateCreated: undefined, orderId: 0, statusName: ''};
  ordersProducts: OrdersProducts[] = [];
  formattedDate: string;

  paramsSubscription: Subscription;
  orderId: number;

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params.subscribe((params: Params) => {
      this.orderId = params.id;
    });
    this.ordersService.fetchOrderData(this.orderId).subscribe(res => {
      this.order = res;
      this.formattedDate = DateHelper.convertDateToReadableString(this.order.orderDateCreated);
    });
    this.ordersService.fetchOrdersProducts(this.orderId).subscribe(res => {
      this.ordersProducts = res;
    });
  }

  ngOnDestroy(): void {
    this.paramsSubscription.unsubscribe();
  }
}
