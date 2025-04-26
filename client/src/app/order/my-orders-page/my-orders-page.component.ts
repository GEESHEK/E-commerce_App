import {Component, OnInit} from '@angular/core';
import {OrderService} from "../../services/order.service";
import {OrderHistory} from "../../models/orderHistory";
import {ToastrService} from "ngx-toastr";
import {ActivatedRoute, Router} from "@angular/router";
import {PaginatedResult} from "../../models/pagination";

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

  constructor(
    private orderService: OrderService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const page = params['page'] ? + params['page'] : null;
      const pageSize = params['pageSize'] ? + params['pageSize'] : null;

      if (page && pageSize) {
        this.pageNumber = page;
        this.pageSize = pageSize;
      } else {
        // No pagination in URL, so set defaults in URL
        this.pageNumber = 1;
        this.pageSize = 5;
        this.updateUrl();
      }
      this.loadOrders();
    })
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
      this.updateUrl();
    }
  };

  updateUrl() {
    void this.router.navigate([], {
      relativeTo: this.route,
      queryParams: {
        page: this.pageNumber,
        pageSize: this.pageSize
      },
      queryParamsHandling: 'merge',
      replaceUrl: true,
    });
  }
}
