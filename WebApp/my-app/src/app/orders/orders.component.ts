import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';
import {URL} from '../url-helper';


interface Order{
  orderId: number;
  name: string;
  address: string;
  finalPrice: number;
  statusName: string;
}

export type mode = 'add' | 'edit';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})

export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.http.get(`${URL}Orders/`).subscribe(Response => {
        this.orders = Response as Order[];
    });
  }
  onClickHandler(): void {
    console.log('Clicked!');
    this.router.navigateByUrl('/new-order');
  }

}


