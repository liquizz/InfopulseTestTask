export interface Customer{
  customerId: number;
  name: string;
  address: string;
  createdDate: Date;
}

export interface Status {
  statusId: number;
  statusName: string;
}

export interface Product {
  productId: number;
  productDate: Date;
  name: string;
  quantity: number;
  price: any;
  productCategories: any;
  productSizes: any;
  productDescriptions: any;
}

export interface Comment{
  commentId: number;
  comment: string;
}

export interface Order{
  orderId: number;
  createdDate: Date;
  customer: Customer;
  status: Status;
  cost: number;
  products: Product[];
  comment: Comment;
}
