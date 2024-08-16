import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { WatchService } from '../services/watch.service';
import { CartWatch } from '../../models/cartWatch';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  itemIds: number[] = [];
  items: CartWatch[] = [];
  totalPrice: number = 0;

  constructor(
    private cartService: CartService,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.itemIds = this.cartService.getItemIds();
    if (this.itemIds.length > 0) {
      this.loadItems(this.itemIds);
    }
  }
  //Todo some safety for when the stock is zero in the shopping cart e.g. when stock = 0
  //Add to order controller and something on the cart page so that it is greyed out and is not calculated
  loadItems(ids: number[]) {
    this.watchService.getCartWatches(ids).subscribe({
      next: (response) => {
        this.items = response;
        this.totalPrice = this.calculateTotalPrice(this.items);
      },
      error: (error) => console.log(error),
    });
  }

  removeAnItemFromCart(id: number): void {
    this.cartService.removeOneItem(id);
  }

  removeAllOccurrencesFromCart(id: number): void {
    this.cartService.removeAllOccurrencesOfAnItem(id);
    this.itemIds = this.cartService.getItemIds();
    this.items = this.items.filter((item) => item.id !== id);
    this.totalPrice = this.calculateTotalPrice(this.items);
  }

  removeAllItemsFromCart(): void {
    this.cartService.removeAllItems();
  }

  createRange(stock: number): number[] {
    return Array.from({ length: stock }, (_, i) => i + 1);
  }

  calculateTotalPrice(items: CartWatch[]): number {
    return items.reduce((total, items) => total + items.price, 0);
  }

  //method to add qty to the watch object and remove it
  //count the ids, what if we change it on drop down from 1 to 3, add 2 of those ids etc.
  updateItemQuantity(id: number, updatedQty: number, inStock: number): void {
    let itemCount = this.calculateItemCount(id);

    if (updatedQty === itemCount && updatedQty > inStock && updatedQty <= 0) {
      return;
    }

    if (updatedQty > itemCount) {
      let excess = updatedQty - itemCount;
      for (let i = 0; i < excess; i++) {
        this.itemIds.push(id);
      }
    }

    if (updatedQty < itemCount) {
      this.itemIds = this.itemIds.filter((ids) => ids !== id);
      for (let i = 0; i < updatedQty; i++) {
        this.itemIds.push(id);
      }
    }
  }

  calculateItemCount(id: number): number {
    return this.itemIds.filter((ids) => ids === id).length;
  }
}
