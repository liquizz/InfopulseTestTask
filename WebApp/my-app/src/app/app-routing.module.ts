import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { CustomersComponent } from './customers/customers.component';
import { ProductsComponent } from './products/products.component';
import { CreateOrderComponent } from './orders/create-order/create-order.component';
import { CreateCustomerComponent } from './customers/create-customer/create-customer.component';
import { CreateProductComponent } from './products/create-product/create-product.component';
import {AddProductComponent} from './orders/add-product/add-product.component';
import {ViewProductComponent} from './products/view-product/view-product.component';
import {EditProductComponent} from './products/edit-product/edit-product.component';


const routes: Routes = [
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/:id/new', component: CreateOrderComponent },
  // { path: 'orders/:id/add-product/:productId', component: AddProductComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'products/:id', component: ViewProductComponent },
  { path: 'products/:id/new', component: CreateProductComponent },
  { path: 'products/:id/edit', component: EditProductComponent },
  { path: 'customers/new', component: CreateCustomerComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
