import { Component, OnInit } from '@angular/core';
import {OrdersDataService} from '../order-data.service';
import {ActivatedRoute, Router} from '@angular/router';
import Order from '../../models/order.model';
import {Product} from '../../models/product.model';
import Status from '../../models/status.model';
import {OrdersService} from '../orders.service';
import CustomerShort from '../../models/customer-short.model';
import {FullOrder} from '../../models/full-order.model';
import {DateHelper} from '../../helpers/date-helper';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent implements OnInit {

  currentOrderSubscription: Subscription;
  currentProductsSubscription: Subscription;

  currentOrder: FullOrder;
  currentOrderId: number;
  customers: CustomerShort[];

  chosenProducts: any[];
  statuses: Status[];
  formattedDate: string;
  totalCost: number;

  constructor(
    private ordersDataService: OrdersDataService,
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.currentOrderId = this.route.snapshot.params.id;
  }

  ngOnInit(): void {
    this.ordersService.fetchShortCustomersData().subscribe((response: CustomerShort[]) => {
      this.customers = response;
    });
    this.ordersService.fetchStatusesData().subscribe((response: Status[]) => {
      this.statuses = response;
    });
    this.currentProductsSubscription = this.ordersDataService.chosenProductsChangedObservable.subscribe((res) => {
      this.chosenProducts = res;
    });
    this.currentOrderSubscription = this.ordersDataService.currentOrderChangedObservable.subscribe((res) => {
      this.currentOrder = res;
      this.formattedDate = DateHelper.convertDateToReadableString(this.currentOrder.orderDateCreated);
      // this.categories.find((el) => el.categoryName === form.category).categoryId
    });
    if (this.chosenProducts.length > 0){
      this.totalCost = this.calculateTotalCost(this.chosenProducts);
    }
  }

  calculateTotalCost = (productsArray): number => {
    let finalSum = 0;
    productsArray.map(el => {
      finalSum += (+el.quantity * +el.price);
    });
    return finalSum;
  }

  onAddProductClicked(formData: {
    customer: number,
    status: number,
    comment: string
  }): void{
    const updatedOrder: Order = {
      customerId: +formData.customer,
      orderDate: this.currentOrder.orderDateCreated,
      orderId: this.currentOrderId,
      productsList: this.chosenProducts,
      statusId: formData.status,
      totalCost: 0,
      comment: formData.comment
    };

    this.ordersDataService.changeOrder(updatedOrder);
    this.router.navigate(['orders', this.route.snapshot.params.id, 'add-product'], {queryParams: {from: 'edit'}});
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
      customerId: +formData.customer,
      orderDate: this.currentOrder.orderDateCreated,
      orderId: +this.currentOrderId,
      productsList: this.chosenProducts,
      statusId: +formData.status,
      totalCost: this.totalCost,
      comment: formData.comment
    };

    this.ordersService.updateOrder(updatedOrder).subscribe(res => {
      this.router.navigate(['orders']);
    }, error => {
      console.log(error);
    });
    this.ordersDataService.clearChosenProducts();

    this.currentOrderSubscription.unsubscribe();
    this.currentProductsSubscription.unsubscribe();
  }

  onDeleteClick(productId: number): void {
    this.ordersDataService.deleteProductFromChosenProducts(productId);
    this.totalCost = this.calculateTotalCost(this.chosenProducts);
  }

  onCancelClick(): void{
    this.ordersDataService.clearChosenProducts();

    this.currentOrderSubscription.unsubscribe();
    this.currentProductsSubscription.unsubscribe();

    this.router.navigate(['orders', this.route.snapshot.params.id]);
  }
}
