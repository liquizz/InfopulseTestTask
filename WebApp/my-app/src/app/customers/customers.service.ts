import Customer from "../models/customer.model";
import { HttpClient } from '@angular/common/http';
import { URL } from '../url-helper';
import { EventEmitter, Injectable } from "@angular/core";

@Injectable()
export class CustomersService{
    customers: Customer[] = [];
    
    constructor(private http: HttpClient){

    }
    
    customersUpdated = new EventEmitter<Customer[]>();

    fetchCustomersData(): void{
        this.http.get(`${URL}Customers/`).subscribe(Response => {
            this.customers = Response as Customer[];
            this.customersUpdated.emit(this.customers);
          });
    }

    sendCustomersData(payload: any): void{ // TODO: remove "any" type soon

    }

    deleteCustomersData(customerId: number): void{

    }
}