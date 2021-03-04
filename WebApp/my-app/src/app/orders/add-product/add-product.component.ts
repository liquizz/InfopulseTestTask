import {Component, DoCheck, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import OrdersService from '../orders.service';
import {ActivatedRoute, Router} from '@angular/router';
import {OrdersDataService} from '../order-data.service';
import Order from '../../models/order.model';
import {Product} from '../../models/product.model';
import {ProductsService} from '../../products/products.service';
import {Size} from '../../models/size.model';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit, DoCheck {
  @Input('productId') productField;

  products: any[] = []; // TODO: Refactor products type && logic
  sizes: Size[] = [];

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
    Price: 0,
    ProductCategoryId: 0,
    ProductDate: undefined,
    ProductDescription: '',
    ProductDescriptionId: 0,
    ProductId: 0,
    ProductName: '',
    ProductSizeId: 0,
    Quantity: 0
  };

  constructor(
    private ordersService: OrdersService,
    private route: ActivatedRoute,
    private router: Router,
    private ordersDataService: OrdersDataService,
    private productsService: ProductsService
  ) { }

  ngOnInit(): void {
    this.ordersDataService.currentOrderChangedObservable.subscribe(res => {
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
  }

  ngDoCheck(): void {
    console.log('ngDoCheck');

  }

  onSubmitClicked(orderForm): void{

  }

  onGoBackClick = () => {
    this.router.navigate(['orders', this.route.snapshot.params.id, 'new']);
  }

}
