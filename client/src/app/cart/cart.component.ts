import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart.service';
import { WatchService } from '../services/watch.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  itemIds: number[] = [];
  items: any[] = [];
  quantity: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

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

  loadItems(ids: number[]) {
    this.watchService.getCartWatches(ids).subscribe({
      next: (response) => (this.items = response),
      error: (error) => console.log(error),
    });
  }

  updatePage(): void {
    //When a watch is added or removed the page should be updated
  }

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
