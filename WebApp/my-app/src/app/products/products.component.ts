import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {ProductsService} from './products.service';
import {Product} from '../models/product.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[];

  constructor(
    private http: HttpClient,
    private router: Router,
    private productsService: ProductsService
  ) { }

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((res) => {
      this.products = res;
    });
  }
}
