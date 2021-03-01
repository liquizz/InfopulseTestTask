import {Injectable} from '@angular/core';
import {URL} from '../url-helper';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Product} from '../models/product.model';
import {Category} from '../models/category.model';
import {Size} from '../models/size.model';

@Injectable()
export class ProductsService {
  products: Product[] = [];

  constructor(private http: HttpClient) {

  }

  getProducts(): Observable<any> {
    return this.http.get<any>(`${URL}Products/`);
  }

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(`${URL}Products/categories`);
  }

  getSizes(): Observable<Size[]> {
    return this.http.get<Size[]>(`${URL}Products/sizes`);
  }

  deleteProduct(productId: number): Observable<Product>{
    return this.http.delete<Product>(`${URL}Products/delete/${productId}`);
  }

  createProduct(product: Product): Observable<boolean>{
    return this.http.post<boolean>(`${URL}Products/create`, product);
  }


}
