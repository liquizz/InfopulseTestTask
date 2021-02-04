import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { URL } from '../url-helper';
import {Router} from '@angular/router';

interface Customer{
  customerId: number;
  name: string;
  address: string;
  createdDate: Date;
  totalUserSum: any;
  totalOrders: number;
}

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  customers: Customer[];
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get(`${URL}Customers/`).subscribe(Response => {
      this.customers = Response as Customer[];
    });
  }
  onClickHandler(): void {
    this.router.navigateByUrl('new-customer');
  }
}
