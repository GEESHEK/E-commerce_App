import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // TODO api to retrieve watch pic, name and price
  // To check stock and buy watch, orders table
}
