import {Component, OnInit, ViewChild} from '@angular/core';
import {CustomersService} from '../customers.service';
import {NgForm} from '@angular/forms';
import {DateHelper} from '../../helpers/date-helper';
import {Router} from '@angular/router';

interface CreateCustomer{
  username: string;
  address: string;
}

@Component({
  selector: 'app-create-customer',
  templateUrl: './create-customer.component.html',
  styleUrls: ['./create-customer.component.css']
})
export class CreateCustomerComponent implements OnInit {
  address: string;
  date: Date = new Date();
  formattedDate: string = DateHelper.convertDateToReadableString(this.date);
  isSuccessful: boolean = undefined;

  constructor(
    private customersService: CustomersService
  ) { }

  ngOnInit(): void {
  }

  onCustomerCreate(formData: CreateCustomer): void {
    this.customersService.sendCustomersData(formData.username, formData.address, this.date)
      .subscribe((response) => {
      if (response === true){
        this.isSuccessful = true;
      } else {
        this.isSuccessful = false;
      }
    }, error => {
      console.log(error);
    });
  }
}
