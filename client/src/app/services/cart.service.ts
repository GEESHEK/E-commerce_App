import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;
  private watchCartIds: number[] = [];

  constructor(private http: HttpClient) {}

  // TODO api to retrieve watch pic, name and price
  // To check stock and buy watch, orders table

  addToCart(id: number) {
    this.watchCartIds.push(id);
    console.log('Adding to Cart! Watch count is ' + this.watchCartIds.length);
  }
}
