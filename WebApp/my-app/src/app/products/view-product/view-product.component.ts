import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import {Subscription} from 'rxjs';
import {ProductsService} from '../products.service';
import {DateHelper} from '../../helpers/date-helper';

interface Product {
  productId: number;
  name: string;
  categoryName: string;
  sizeName: string;
  quantity: number;
  price: number;
  productDate: Date;
  description: string;
}

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.css']
})
export class ViewProductComponent implements OnInit {
  productId: number = undefined;
  product: Product = {
    categoryName: '',
    description: '',
    name: '',
    price: 0,
    productDate: undefined,
    productId: 0,
    quantity: 0,
    sizeName: ''
  };
  formattedDate: string;
  paramsSubscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private productsService: ProductsService
  ) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params.subscribe((params: Params) => {
      this.productId = params.id;
    });
    this.productsService.getProduct(this.productId).subscribe((response) => {
      this.product = response;
      this.formattedDate = DateHelper.convertDateToReadableString(response.productDate);
    });
  }

}
