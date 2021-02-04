import { Component, OnInit } from '@angular/core';
import {URL} from '../url-helper';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

interface Product{
  productId: number;
  productDate: Date;
  name: string;
  quantity: number;
  price: number;
  categoryName: string;
  sizeName: string;
}

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
    });
  }
  onClickHandler(): void {
    this.router.navigateByUrl('/new-product');
  }
}
