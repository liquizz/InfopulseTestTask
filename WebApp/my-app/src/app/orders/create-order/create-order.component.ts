import {Component, Input, OnDestroy, OnInit, Output} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {URL} from '../../url-helper';
import CustomerShort from '../../models/customer-short.model';
import Status from '../../models/status.model';
import {Product} from '../../models/product.model';
import Order from '../../models/order.model';
import {OrdersService} from '../orders.service';
import {OrdersDataService} from '../order-data.service';
import OrderShort from '../../models/order-short.model';
import {Subscription} from 'rxjs';
import {DateHelper} from '../../helpers/date-helper';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit, OnDestroy {
  currentOrderChangedSubscription: Subscription;
  currentChosenProductsSubscription: Subscription;


  customers: CustomerShort[];
  statuses: Status[];
  chosenProducts: any[] = []; // TODO: Change this later
  orders: OrderShort[] = [];
  comment: Comment;
  date: Date = new Date();
  formattedDate = DateHelper.convertDateToReadableString(this.date);

  currentOrderId: number;
  currentOrder: Order;

  totalCost: number;

  constructor(
    private http: HttpClient,
    private ordersService: OrdersService,
    private ordersDataService: OrdersDataService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.totalCost = 0;
  }

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
    this.currentChosenProductsSubscription = this.ordersDataService.chosenProductsChangedObservable.subscribe(res => {
      this.chosenProducts = res;
    });
    this.currentOrderChangedSubscription = this.ordersDataService.currentOrderChangedObservable.subscribe(res => {
      this.currentOrder = res;
    });
    if (this.chosenProducts.length > 0){
      this.totalCost = this.calculateTotalCost(this.chosenProducts);
    }
  }

  calculateTotalCost = (productsArray): number => {
    let finalSum = 0;
    productsArray.map(el => {
      finalSum += (el.Quantity * el.Price);
    });
    return finalSum;
  }

  onSubmitClicked(formData): void {
    const updatedOrder: Order = {
      customerId: +formData.customer,
      orderDate: this.date,
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
      totalCost: 0,
      comment: formData.comment
    };

    this.ordersDataService.changeOrder(updatedOrder);
    // this.ordersService.updateOrder(updatedOrder).subscribe(res => { Bad idea (probably)
    //
    // }, error => {
    //     console.log(error);
    //   }
    //   );
    this.router.navigate(['orders', this.route.snapshot.params.id, 'add-product'], {queryParams: {from: 'new'}});
  }

  ngOnDestroy(): void {

  }

}
