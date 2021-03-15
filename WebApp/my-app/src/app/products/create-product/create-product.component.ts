import { Component, OnInit } from '@angular/core';
import {Product} from '../../models/product.model';
import {ProductsService} from '../products.service';
import {Category} from '../../models/category.model';
import {Size} from '../../models/size.model';
import {Router} from '@angular/router';
import {DateHelper} from '../../helpers/date-helper';

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
  formattedDate: string = DateHelper.convertDateToReadableString(this.date);


  constructor(
    private productsService: ProductsService,
    private router: Router
  ) { }

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
      productSize: '',
      productId: undefined,
      productName: form.name,
      productCategoryId: this.categories.find((el) => el.categoryName === form.category).categoryId,
      productSizeId: this.sizes.find((el) => el.sizeName === form.size).sizeId,
      quantity: +form.quantity,
      price: +form.price,
      productDate: this.date,
      productDescription: form.description,
      productDescriptionId: undefined
    };
    this.productsService.createProduct(newProduct).subscribe(() => {
      this.isSuccessful = true;
      this.router.navigate(['products']);
    }, error => {
      console.log(error);
    });
  }

}
