import Customer from "../models/customer.model";
import { HttpClient } from '@angular/common/http';
import { URL } from '../url-helper';
import { EventEmitter, Injectable } from "@angular/core";
import {Observable, Subscription} from 'rxjs';

interface CustomerDTO {
  Name: string;
  Address: string;
  CreatedDate: Date;
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
      const newCustomer: CustomerDTO = {Name: customerName, Address: customerAddress, CreatedDate: dateCreated};
      return this.http.post<boolean>(`${URL}Customers`, newCustomer);
    }
}
