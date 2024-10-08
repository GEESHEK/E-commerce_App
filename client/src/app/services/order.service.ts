import {Injectable} from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Order} from "../../models/order";
import {Observable} from "rxjs";
import {SuccessOrder} from "../../models/successOrder";

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  order(order: Order): Observable<number> {
    console.log(order);
      return this.http.post<number>(this.baseUrl + '/order', order);
  }

  retrieveSuccessOrder(id: number): Observable<SuccessOrder> {
    return this.http.get<SuccessOrder>(this.baseUrl + '/order/success/' + id);
  }
}
