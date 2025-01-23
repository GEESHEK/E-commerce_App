import {Component, OnInit} from '@angular/core';
import {OrderService} from "../../services/order.service";
import {Router} from "@angular/router";
import {SuccessOrder} from "../../models/successOrder";
import {CartWatch} from "../../models/cartWatch";
import {WatchService} from "../../services/watch.service";

@Component({
  selector: 'app-order-confirmation-page',
  templateUrl: './order-confirmation-page.component.html',
  styleUrls: ['./order-confirmation-page.component.css']
})
export class OrderConfirmationPageComponent implements OnInit {
  order: SuccessOrder | undefined;
  itemIds: number[] = [];
  items: CartWatch[] = [];

  constructor(
    private orderService: OrderService,
    private watchService: WatchService,
    private router: Router) {
  }

  ngOnInit(): void {
    if (this.orderService.successOrder == null) {
      this.router.navigateByUrl('/home');
    }
    this.loadOrderDetails();
  }

  loadOrderDetails(): void {
    if (this.orderService.successOrder != null) {
      this.order = this.orderService.successOrder;
      this.itemIds = this.getProductIds(this.order);
      if (this.itemIds.length > 0) {
        this.loadItems(this.itemIds);
      }
    }

  }

  loadItems(ids: number[]) {
    this.watchService.getCartWatches(ids).subscribe({
      next: (response) => {
        this.items = response;
      },
      error: (error) => console.log(error),
    });
  }

  getProductIds(order: SuccessOrder): number[] {
    return order.items.map(item => item.productId);
  }

  getQuantity(id: number): number {
    return this.order!.items.find(x => x.productId === id)!.quantity;
  }
}
