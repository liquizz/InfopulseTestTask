import { Component, OnInit } from '@angular/core';
import {Product} from '../../models/product.model';
import {ProductsService} from '../products.service';
import {Category} from '../../models/category.model';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  products: Product[] = [];
  categories: Category[] = [];
  date: Date = new Date();


  constructor(private productsService: ProductsService) { }

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((response) => {
      this.products = response;
    });
    this.productsService.getCategories().subscribe((response) => {
      this.categories = response;
    });
  }

  onSubmitClicked(
    form: NgForm): void{

  }

}
