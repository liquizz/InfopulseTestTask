import { Component, OnInit } from '@angular/core';
import {URL} from '../url-helper';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import Product from '../models/product.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  title = true;
  products: Product[] = [];
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get(`${URL}Products/`).subscribe(Response => {
      this.products = Response as Product[];
      console.log(this.products)
    });
  }
}
