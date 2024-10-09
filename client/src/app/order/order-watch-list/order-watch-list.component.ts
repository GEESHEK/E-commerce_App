import {Component, Input} from '@angular/core';
import {FormBuilder} from "@angular/forms";
import {CartWatch} from "../../../models/cartWatch";
import {CartService} from "../../services/cart.service";
import {WatchService} from "../../services/watch.service";
import {OrderService} from "../../services/order.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-order-watch-list',
  templateUrl: './order-watch-list.component.html',
  styleUrls: ['./order-watch-list.component.css']
})
export class OrderWatchListComponent {
  @Input() items: CartWatch[] | undefined;
  @Input() itemIds: number[] = [];

  constructor(
    private cartService: CartService,
    private watchService: WatchService,
    private fb: FormBuilder,
    private orderService: OrderService,
    private router: Router,
  ) {}

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
}
