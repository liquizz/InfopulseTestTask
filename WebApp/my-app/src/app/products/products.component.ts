import {Component, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {ProductsService} from './products.service';

interface Product {
  productId: number;
  name: string;
  categoryName: string;
  sizeName: string;
  quantity: number;
  price: number;
}

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];

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

  onDeleteClicked(productId): void {
    this.productsService.deleteProduct(productId).subscribe(response => {
      if (response === true){
        const index = this.products.findIndex(el => el.productId === productId);
        if (index > -1) {
          this.products.splice(index, 1);
        } else {
          console.log('Object already deleted!');
        }
      }
    });
  }

  onNewProductClicked = () => {
    this.router.navigate(['products', this.products.length + 1, 'new']);
    // TODO: Fix this later, create product first, then fetch productId
  }
}
