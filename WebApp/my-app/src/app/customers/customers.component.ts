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
export class CustomersComponent implements OnInit {
  customers: Customer[];

  constructor(
    private http: HttpClient,
    private router: Router,
    private customersService: CustomersService ) {
     }

  ngOnInit(): void {
    this.customersService.fetchCustomersData().subscribe((data) => {
      this.customers = data;
    });
  }


}
