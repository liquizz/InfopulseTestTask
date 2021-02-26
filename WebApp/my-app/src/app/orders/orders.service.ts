import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import Order from "../models/order.model";

@Injectable()
export default class OrdersService {
    orders: Order[] = [];

    constructor(private http: HttpClient){

    }

    fetchOrdersData(){
        
    }
}