import {Component, OnInit} from '@angular/core';
import {OrderService} from "../../services/order.service";
import {ActivatedRoute} from "@angular/router";
import {SuccessOrder} from "../../../models/successOrder";

@Component({
  selector: 'app-order-confirmation-page',
  templateUrl: './order-confirmation-page.component.html',
  styleUrls: ['./order-confirmation-page.component.css']
})
export class OrderConfirmationPageComponent implements OnInit {
  orderId: number | undefined;
  order: SuccessOrder | undefined;

  constructor(
    private orderService: OrderService,
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
          console.log("logging order: " + JSON.stringify(this.order));
        },
        error: (error) => console.log(error)
      });
    }
  }
}
