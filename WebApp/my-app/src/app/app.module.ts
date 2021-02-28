import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductsComponent } from './products/products.component';
import { CustomersComponent } from './customers/customers.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateOrderComponent } from './orders/create-order/create-order.component';
import { CreateCustomerComponent } from './customers/create-customer/create-customer.component';
import { CreateProductComponent } from './products/create-product/create-product.component';
import {FormsModule} from '@angular/forms';
import {CustomersService} from './customers/customers.service';
import OrdersService from './orders/orders.service';
import { AddProductComponent } from './orders/add-product/add-product.component';
import {ProductsService} from './products/products.service';

@NgModule({
  declarations: [
    AppComponent,
    OrdersComponent,
    ProductsComponent,
    CustomersComponent,
    DashboardComponent,
    CreateOrderComponent,
    CreateCustomerComponent,
    CreateProductComponent,
    AddProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    CustomersService,
    OrdersService,
    ProductsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
