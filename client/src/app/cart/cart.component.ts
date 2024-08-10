import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  watchIds: number[] = [];
  quantity: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

  constructor(private cartService: CartService) {}

  ngOnInit(): void {}

  removeAnItemFromCart(id: number): void {
    this.cartService.removeOneItem(id);
  }

  removeAllOccurrencesFromCart(id: number): void {
    this.cartService.removeAllOccurrencesOfAnItem(id);
  }

  removeAllItemsFromCart(): void {
    this.cartService.removeAllItems();
  }
}
