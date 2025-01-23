import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Order} from "../models/order";
import {map} from "rxjs";
import {SuccessOrder} from "../models/successOrder";
import {OrderHistory} from "../models/orderHistory";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;
  successOrder: SuccessOrder | undefined;

  constructor(private http: HttpClient) {
  }

  order(order: Order) {
    console.log(order);
      return this.http.post<SuccessOrder>(this.baseUrl + '/order', order).pipe(
        map((response: SuccessOrder) => {
          if (response) {
            this.successOrder = response;
          }
        })
      );
  }

  userOrder(id: number) {
    return this.http.get<SuccessOrder>(this.baseUrl + '/order/success/' + id).pipe(
      map((response: SuccessOrder) => {
        if (response) {
          this.successOrder = response;
        }
      })
    );
  }

  orderHistory() {
    return this.http.get<OrderHistory[]>(this.baseUrl + '/order/history');
  }
}
