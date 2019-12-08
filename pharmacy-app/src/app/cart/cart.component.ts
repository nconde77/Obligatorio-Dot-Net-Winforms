import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  products: Product[] = [
    {image: 'assets/images/product_01.png', name: 'Bioderma', price: 95, quantity: 1},
    {image: 'assets/images/product_02.png', name: 'Chanca Piedra', price: 70, quantity: 2},
    {image: 'assets/images/product_03.png', name: 'Umcka Cold Care', price: 120, quantity: 2},
    {image: 'assets/images/product_04.png', name: 'Cetyl Pure', price: 45, quantity: 4},
    {image: 'assets/images/product_05.png', name: 'CLA Core', price: 38, quantity: 3},
    {image: 'assets/images/product_06.png', name: 'Poo Pourri', price: 89, quantity: 1},
];

  constructor() { }

  ngOnInit() {
  }

}

class Product {
  image: string;
  name: string;
  price: number;
  quantity: number;
}
