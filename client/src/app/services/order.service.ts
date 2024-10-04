import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Order} from "../../models/order";
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;
  successOrder: any;

  constructor(private http: HttpClient) {
  }

  order(order: Order): any {
    console.log(order);
      return this.http.post(this.baseUrl + '/order', order).pipe(
        map(successOrder => {
          if (successOrder) {
            this.successOrder = successOrder;
          }
        })
      );
  }
}
