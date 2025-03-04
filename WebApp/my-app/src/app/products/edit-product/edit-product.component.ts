import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {ProductsService} from '../products.service';
import {Subscription} from 'rxjs';
import {Product} from '../../models/product.model';
import {Category} from '../../models/category.model';
import {Size} from '../../models/size.model';
import {DateHelper} from '../../helpers/date-helper';

interface ReceivedProduct {
  productId: number;
  name: string;
  categoryName: string;
  sizeName: string;
  quantity: number;
  price: number;
  productDate: Date;
  productDescriptionId: number;
  description: string;
}

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  productId = 0;
  paramsSubscription: Subscription;
  product: ReceivedProduct; // TODO: Ask mentor about what if we put Product type here instead of any
  categories: Category[] = [];
  sizes: Size[] = [];
  currentCategoryName = '';
  currentSizeName = '';
  formattedDate: string;
  // isSuccessful: boolean;

  constructor(
    private route: ActivatedRoute,
    private productsService: ProductsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.paramsSubscription = this.route.params.subscribe((params: Params) => {
      this.productId = params.id;
    });
    this.productsService.getProduct(this.productId).subscribe((response) => {
      this.product = response;
      this.formattedDate = DateHelper.convertDateToReadableString(this.product.productDate);
    });
    this.productsService.getCategories().subscribe((response) => {
      this.categories = response;
    });
    this.productsService.getSizes().subscribe((response) => {
      this.sizes = response;
    });
    // this.currentCategoryName = this.categories.find((el) => el.categoryId === this.product.ProductCategoryId).categoryName;
    // this.currentSizeName = this.sizes.find((el) => el.sizeId === this.product.ProductSizeId).sizeName;
  }

  onSubmitClicked(form: {
      category: string,
      size: string,
      description: string,
      price: number,
      quantity: number,
      name: string
    }): void {

    const newProduct: Product = {
      productSize: '',
      productId: +this.productId,
      productName: form.name,
      productCategoryId: this.categories.find((el) => el.categoryName === form.category).categoryId,
      productSizeId: this.sizes.find((el) => el.sizeName === form.size).sizeId,
      quantity: +form.quantity,
      price: +form.price,
      productDate: this.product.productDate,
      productDescription: form.description,
      productDescriptionId: this.product.productDescriptionId
    };

    console.log(this.product);
    console.log(newProduct);

    this.productsService.updateProduct(newProduct).subscribe(response => {
      if (response === true){
        this.router.navigate(['products']);
      }
    }, error => {
      console.log(error);
    });
}

}
