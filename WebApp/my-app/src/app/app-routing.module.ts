import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { CustomersComponent } from './customers/customers.component';
import { ProductsComponent } from './products/products.component';
import { CreateOrderComponent } from './orders/create-order/create-order.component';
import { CreateCustomerComponent } from './customers/create-customer/create-customer.component';
import { CreateProductComponent } from './products/create-product/create-product.component';
import {AddProductComponent} from './orders/add-product/add-product.component';


const routes: Routes = [
  { path: 'orders', component: OrdersComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'orders/new', component: CreateOrderComponent },
  { path: 'orders/new/add-product', component: AddProductComponent },
  { path: 'customers/new', component: CreateCustomerComponent },
  { path: 'products/new', component: CreateProductComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
