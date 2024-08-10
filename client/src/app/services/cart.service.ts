import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;
  private watchCartIds: number[] = [];
  //give initial value to observable
  private itemCountSource = new BehaviorSubject<number>(
    this.watchCartIds.length,
  );
  itemCount$ = this.itemCountSource.asObservable();

  constructor(private http: HttpClient) {}

  // TODO api to retrieve watch pic, name and price
  // To check stock and buy watch, orders table

  add(id: number) {
    this.watchCartIds.push(id);
    console.log('Adding to Cart! Watch count is ' + this.watchCartIds.length);
    //this is needed to update the behaviourSubject
    this.itemCountSource.next(this.watchCartIds.length);
  }
}
