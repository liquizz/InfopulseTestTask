import {Injectable} from '@angular/core';
import {URL} from '../url-helper';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Product} from '../models/product.model';

@Injectable()
export class ProductsService {
  products: Product[] = [];

  constructor(private http: HttpClient) {

  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${URL}Products/`);
  }
}
