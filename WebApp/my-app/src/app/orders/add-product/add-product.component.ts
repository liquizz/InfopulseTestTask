import {Component, OnDestroy, OnInit} from '@angular/core';
import {OrdersService} from '../orders.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {OrdersDataService} from '../order-data.service';
import Order from '../../models/order.model';
import {Product} from '../../models/product.model';
import {ProductsService} from '../../products/products.service';
import {Size} from '../../models/size.model';
import {Subscription} from 'rxjs';
import {ChosenProductModel} from '../../models/chosen-product.model';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit, OnDestroy {
  private currentOrderSubscription: Subscription;

  products: any[] = []; // TODO: Refactor products type && logic
  sizes: Size[] = [];
  queryParams: Params;

  currentOrder: Order = {
    comment: '',
    customerId: 0,
    orderDate: undefined,
    orderId: 0,
    productsList: [],
    statusId: 0,
    totalCost: 0};

  selectedProductId: number;

  selectedProduct: Product = {
    productSize: '',
    price: 0,
    productCategoryId: 0,
    productDate: undefined,
    productDescription: '',
    productDescriptionId: 0,
    productId: 0,
    productName: '',
    productSizeId: 0,
    quantity: 0
  };

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private router: Router,
    private ordersDataService: OrdersDataService,
    private productsService: ProductsService
  ) { }

  ngOnInit(): void {
    this.currentOrderSubscription = this.ordersDataService.currentOrderChangedObservable.subscribe(res => {
      this.currentOrder = res;
    });
    this.productsService.getProducts().subscribe((res: {
        productId: string,
        name: string,
        categoryName: string,
        sizeName: string,
        quantity: number,
        price: number
    }[]) => {
      this.products = res;
    });
    this.productsService.getSizes().subscribe(res => {
      this.sizes = res;
    });
    this.route.queryParams.subscribe(params => {
      this.queryParams = params;
    });
  }

  onSubmitClicked(orderForm: {
    productId: number,
    quantity: number,
    sizeId: number
  }): void {
    this.productsService.getProduct(orderForm.productId).subscribe(res => {
      const chosenProduct: Product = {
        price: res.price,
        productCategoryId: 0,
        productDate: undefined,
        productDescription: '',
        productDescriptionId: 0,
        productName: res.name,
        productSizeId: res.sizeId,
        productSize: res.sizeName,
        productId: +orderForm.productId,
        quantity: +orderForm.quantity
      };

      this.ordersDataService.addChosenProduct(chosenProduct);
      this.router.navigate(['orders', this.route.snapshot.params.id, this.queryParams.from === 'edit' ? 'edit' : 'new']);
    }, error => console.log(error));
  }

  onGoBackClick = () => {
    this.router.navigate(['orders', this.route.snapshot.params.id, this.queryParams.from === 'edit' ? 'edit' : 'new']);
  }

  ngOnDestroy(): void {
    this.currentOrderSubscription.unsubscribe();
  }
}
