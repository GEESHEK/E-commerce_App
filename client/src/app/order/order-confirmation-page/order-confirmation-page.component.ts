import {Component, OnInit} from '@angular/core';
import {OrderService} from "../../services/order.service";
import {ActivatedRoute} from "@angular/router";
import {SuccessOrder} from "../../models/successOrder";
import {CartWatch} from "../../models/cartWatch";
import {WatchService} from "../../services/watch.service";

@Component({
  selector: 'app-order-confirmation-page',
  templateUrl: './order-confirmation-page.component.html',
  styleUrls: ['./order-confirmation-page.component.css']
})
export class OrderConfirmationPageComponent implements OnInit {
  orderId: number | undefined;
  order: SuccessOrder | undefined;
  itemIds: number[] = [];
  items: CartWatch[] = [];

  constructor(
    private orderService: OrderService,
    private watchService: WatchService,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const param = params.get('orderId');
      this.orderId = param !== null ? +param : NaN;
      if (isNaN(this.orderId)) {
        // Handle the case where the parameter is not a number
        console.error('Invalid parameter value');
        //TODO redirect user
        return;
      }
      this.loadOrderDetails();
    })
  }

  loadOrderDetails(): void {
    if (this.orderId != null) {
      this.orderService.retrieveSuccessOrder(this.orderId).subscribe({
        next: (response) => {
          this.order = response;
          this.itemIds = this.getProductIds(this.order);
          if (this.itemIds.length > 0) {
            this.loadItems(this.itemIds);
          }
        },
        error: (error) => console.log(error)
      });
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
