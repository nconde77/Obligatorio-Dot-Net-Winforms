import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-slider',
  templateUrl: './product-slider.component.html',
  styleUrls: ['./product-slider.component.scss']
})
export class ProductSliderComponent {
  products: Product[] = [
    { image: 'assets/images/product_01.png', name: 'Bioderma', price: '95' },
    {
      image: 'assets/images/product_02.png',
      name: 'Chanca Piedra',
      price: '70'
    },
    {
      image: 'assets/images/product_03.png',
      name: 'Umcka Cold Care',
      price: '120'
    },
    { image: 'assets/images/product_04.png', name: 'Cetyl Pure', price: '45' },
    { image: 'assets/images/product_05.png', name: 'CLA Core', price: '38' },
    { image: 'assets/images/product_06.png', name: 'Poo Pourri', price: '89' }
  ];
}

class Product {
  image: string;
  name: string;
  price: string;
}
