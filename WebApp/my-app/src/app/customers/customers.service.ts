import Customer from '../models/customer.model';
import { HttpClient } from '@angular/common/http';
import { URL } from '../url-helper';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface CustomerDTO {
  name: string;
  address: string;
  createdDate: Date;
}

@Injectable()
export class CustomersService{
    customers: Customer[] = [];

    constructor(private http: HttpClient){

    }

    fetchCustomersData(): Observable<Customer[]>{
      return this.http.get<Customer[]>(`${URL}Customers/`);
    }

    sendCustomersData(customerName: string, customerAddress: string, dateCreated: Date): Observable<boolean> {
      const newCustomer: CustomerDTO = {name: customerName, address: customerAddress, createdDate: dateCreated};
      return this.http.post<boolean>(`${URL}Customers`, newCustomer);
    }
}
