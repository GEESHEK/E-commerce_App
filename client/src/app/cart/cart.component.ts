import {Component, OnInit} from '@angular/core';
import {CartService} from '../services/cart.service';
import {WatchService} from '../services/watch.service';
import {CartWatch} from '../models/cartWatch';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  itemIds: number[] = [];
  items: CartWatch[] = [];
  totalPrice: number = 0;
  itemLabel: string = '';

  constructor(
    private cartService: CartService,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.itemIds = this.cartService.getItemIds();
    if (this.itemIds.length > 0) {
      this.loadItems(this.itemIds);
    }
    console.log('how many items are in cartwatch[]: ' + this.items.length);
  }

  loadItems(ids: number[]) {
    this.watchService.getCartWatches(ids).subscribe({
      next: (response) => {
        this.items = response;
        this.totalPrice = this.calculateTotalPrice(this.items);
        this.singleOrPluralItemString();
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
    let totalPrice = 0;

    if (items.length <= 0) {
      return 0;
    }

    for (const itemId of this.itemIds) {
      totalPrice += items.find((x) => x.id === itemId)?.price ?? 0;
    }

    return totalPrice;
  }

  updateItemQuantity(id: number, updatedQty: number, inStock: number): void {
    let itemCount = this.calculateItemCount(id);

    if (updatedQty === itemCount && updatedQty > inStock && updatedQty <= 0) {
      return;
    }

    if (updatedQty > itemCount) {
      let excess = updatedQty - itemCount;
      for (let i = 0; i < excess; i++) {
        this.cartService.addItem(id);
      }
    }

    if (updatedQty < itemCount) {
      let excess = itemCount - updatedQty;
      for (let i = 0; i < excess; i++) {
        this.cartService.removeOneItem(id);
      }
    }

    this.singleOrPluralItemString();
    this.totalPrice = this.calculateTotalPrice(this.items);
  }

  calculateItemCount(id: number): number {
    return this.itemIds.filter((ids) => ids === id).length;
  }

  singleOrPluralItemString(): void {
    this.itemLabel = this.itemIds.length > 1 ? 'items' : 'item';
  }
}
