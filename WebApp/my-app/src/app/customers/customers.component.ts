import { Component, OnChanges, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { URL } from '../url-helper';
import {Router} from '@angular/router';
import Customer from '../models/customer.model';
import { CustomersService } from './customers.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  providers: [CustomersService]
})
export class CustomersComponent implements OnInit, OnChanges {
  customers: Customer[];

  constructor(
    private http: HttpClient, 
    private router: Router, 
    private customersService: CustomersService ) { 
      this.customersService.customersUpdated.subscribe(
        (updatedCustomers: Customer[]) => {
          this.customers = updatedCustomers;
          console.log('cust: ' + this.customers);
        }
      )
     }

  ngOnInit(): void {
    this.customersService.fetchCustomersData();
    
  }

  ngOnChanges(){
    this.customers = this.customersService.customers;
  }
}
