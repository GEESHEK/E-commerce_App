import {Component, OnInit, ViewChild} from '@angular/core';
import {OrderService} from "../../services/order.service";
import {OrderHistory} from "../../models/orderHistory";
import {ToastrService} from "ngx-toastr";
import {Router} from "@angular/router";
import {PaginatedResult} from "../../models/pagination";
import {PaginationComponent} from "ngx-bootstrap/pagination";

@Component({
  selector: 'app-my-orders-page',
  templateUrl: './my-orders-page.component.html',
  styleUrls: ['./my-orders-page.component.css']
})
export class MyOrdersPageComponent implements OnInit {
  pageNumber = 1;
  pageSize = 5;
  paginatedResults: PaginatedResult<OrderHistory[]> = {
    items: [],
    pagination: {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: 0,
      totalPages: 0
    }
  };

  @ViewChild(PaginationComponent) paginationComponent!: PaginationComponent;

  constructor(
    private orderService: OrderService,
    private router: Router,
    private toastr: ToastrService,
  ) {
  }

  ngOnInit(): void {
    const currentPage = this.orderService.getCurrentPage();
    if (currentPage !== 0) {
      this.pageNumber = currentPage;
    }
    this.loadOrders();
  };

  loadOrders() {
    this.orderService.orderHistory(this.pageNumber, this.pageSize).subscribe({
      next: (response) => {
        this.paginatedResults = response;
      },
      error: (error) => {
        this.toastr.error(error.error);
      }
    });
  };

  getOrder(orderId: number) {
    this.orderService.userOrder(orderId).subscribe({
      next: () => {
        this.orderService.setCurrentPage(this.pageNumber);
        this.router.navigateByUrl('/order/confirmation');
      },
      error: (error) => {
        this.toastr.error(error.error);
      }
    })
  };

  pageChanged(event: any) {
    if (this.pageNumber !== event.page) {
      this.pageNumber = event.page;
      this.loadOrders();
    }
  };
}
