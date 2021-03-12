import {Component, OnDestroy, OnInit} from '@angular/core';
import {OrdersService} from '../orders.service';
import Order from '../../models/order.model';
import {OrdersProducts} from '../../models/orders-products.model';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {Subscription} from 'rxjs';
import {FullOrder} from '../../models/full-order.model';
import {DateHelper} from '../../helpers/date-helper';
import {OrdersDataService} from '../order-data.service';
import {Product} from '../../models/product.model';


@Component({
  selector: 'app-view-order',
  templateUrl: './view-order.component.html',
  styleUrls: ['./view-order.component.css']
})
export class ViewOrderComponent implements OnInit, OnDestroy {
  order: FullOrder = {
    customerId: 0,
    statusId: 0,
    comment: '',
    address: '',
    finalPrice: 0,
    name: '',
    orderDateCreated: undefined,
    orderId: 0,
    statusName: ''
  };
  ordersProducts: OrdersProducts[] = [];
  formattedDate: string;

  paramsSubscription: Subscription;
  orderId: number;

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private ordersDataService: OrdersDataService,
    private router: Router
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

  onEditClicked = () => {
    this.ordersDataService.changeOrder(this.order);
    this.ordersProducts.map((el) => {

      const newProduct: Product = {
        Price: +el.price,
        ProductCategoryId: 0,
        ProductDate: undefined,
        ProductDescription: '',
        ProductDescriptionId: 0,
        ProductId: el.productId,
        ProductName: el.name,
        ProductSizeId: el.sizeId,
        ProductSize: el.sizeName,
        Quantity: +el.productQuantity

      };
      this.ordersDataService.addChosenProduct(newProduct);
    });
    this.router.navigate(['orders', this.route.snapshot.params.id, 'edit']);
  }
}
