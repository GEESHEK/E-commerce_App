import { Component, OnInit } from '@angular/core';
import { Order } from '../../../models/order';
import { CartWatch } from '../../../models/cartWatch';
import { CartService } from '../../services/cart.service';
import { WatchService } from '../../services/watch.service';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css'],
})
export class OrderPageComponent implements OnInit {
  itemIds: number[] = [];
  items: CartWatch[] = [];
  totalPrice: number = 0;
  order: Order = {
    CustomerDetail: {
      firstName: '',
      surname: '',
      email: '',
      phoneNumber: '',
      address: '',
      zipCode: '',
      city: '',
      country: '',
    },
    Item: [],
  };

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
      next: (response) => {
        this.items = response;
        this.totalPrice = this.calculateTotalPrice(this.items);
      },
      error: (error) => console.log(error),
    });
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

  calculateItemCount(id: number): number {
    return this.itemIds.filter((ids) => ids === id).length;
  }

  orderNow() {
    console.log(this.order);
  }

  cancel() {
    console.log('cancelled');
  }
}
