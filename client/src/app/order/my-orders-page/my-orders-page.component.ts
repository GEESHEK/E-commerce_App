import {Component, OnInit} from '@angular/core';
import {OrderService} from "../../services/order.service";
import {OrderHistory} from "../../models/orderHistory";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";

@Component({
  selector: 'app-my-orders-page',
  templateUrl: './my-orders-page.component.html',
  styleUrls: ['./my-orders-page.component.css']
})
export class MyOrdersPageComponent implements OnInit {
  orderHistory: OrderHistory[] = [];

  constructor(
    private orderService: OrderService,
    private router: Router,
    private toastr: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.orderService.orderHistory().subscribe({
      next: (response) => {
        this.orderHistory = response;
      },
      error: (error) => {
        this.toastr.error(error.error);
      }
    })
  }

  getOrder(orderId: number) {
    this.orderService.userOrder(orderId).subscribe({
      next: () => {
        this.router.navigateByUrl('/order/confirmation');
      },
      error: (error) => {
        this.toastr.error(error.error);
      }
    })
  }
}
