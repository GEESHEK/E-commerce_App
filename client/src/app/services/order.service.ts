import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Order} from "../models/order";
import {map} from "rxjs";
import {SuccessOrder} from "../models/successOrder";
import {OrderHistory} from "../models/orderHistory";
import {PaginatedResult} from "../models/pagination";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;
  successOrder: SuccessOrder | undefined;
  currentPageNumber: number = 0;

  constructor(private http: HttpClient) {
  }

  order(order: Order) {
      return this.http.post<SuccessOrder>(this.baseUrl + '/order', order).pipe(
        map((response: SuccessOrder) => {
          if (response) {
            this.successOrder = response;
          }
        })
      );
  }

  userOrder(id: number) {
    return this.http.get<SuccessOrder>(this.baseUrl + '/order/' + id).pipe(
      map((response: SuccessOrder) => {
        if (response) {
          this.successOrder = response;
        }
      })
    );
  }

  orderHistory(pageNumber?: number, pageSize?: number) {
    let params = new HttpParams();

    if (pageNumber && pageSize) {
      params = params.append('pageNumber', pageNumber);
      params = params.append('pageSize', pageSize);
    }

    return this.http.get<OrderHistory[]>(this.baseUrl + '/order/history', {observe: 'response', params}).pipe(
      map((response) => {
        let paginatedResult = new PaginatedResult<OrderHistory[]>();
        paginatedResult.items = response.body ?? [];
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination')!);
        return paginatedResult;
      })
    );
  }

  getCurrentPage() {
    return this.currentPageNumber;
  }

  setCurrentPage(pageNumber: number) {
    this.currentPageNumber = pageNumber;
  }
}
