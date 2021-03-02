import { Component, OnInit } from '@angular/core';
import {Product} from '../../models/product.model';
import {ProductsService} from '../products.service';
import {Category} from '../../models/category.model';
import {NgForm} from '@angular/forms';
import {Size} from '../../models/size.model';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  products: Product[] = [];
  categories: Category[] = [];
  sizes: Size[] = [];
  date: Date = new Date();
  isSuccessful: boolean;


  constructor(private productsService: ProductsService) { }

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((response) => {
      this.products = response;
    });
    this.productsService.getCategories().subscribe((response) => {
      this.categories = response;
    });
    this.productsService.getSizes().subscribe((response) => {
      this.sizes = response;
    });
  }

  onSubmitClicked(
    form: {
      category: string,
      size: string,
      description: string,
      price: number,
      quantity: number,
      name: string
    }): void{

    const newProduct: Product = {
      ProductId: undefined,
      ProductName: form.name,
      ProductCategoryId: this.categories.find((el) => el.categoryName === form.category).categoryId,
      ProductSizeId: this.sizes.find((el) => el.sizeName === form.size).sizeId,
      Quantity: +form.quantity,
      Price: +form.price,
      ProductDate: this.date,
      ProductDescription: form.description,
      ProductDescriptionId: undefined
    };
    this.productsService.createProduct(newProduct).subscribe(() => {
      this.isSuccessful = true;
    }, error => {
      console.log(error);
    });
  }

}
