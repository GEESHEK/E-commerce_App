import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService implements OnInit {
  baseUrl = environment.apiUrl;
  private cartIds: number[] = this.getCartIdsFromStorage();
  private itemCountSource = new BehaviorSubject<number>(this.cartIds.length);
  itemCount$ = this.itemCountSource.asObservable();

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Initialize itemCountSource with the length from localStorage
    this.updateItemCount();
  }

  getItemIds(): number[] {
    return this.cartIds;
  }

  addItem(id: number) {
    this.cartIds.push(id);
    console.log('Adding to Cart! Item count is ' + this.cartIds.length);
    this.updateItemCount();
    this.saveCartIdsToStorage();
  }

  removeOneItem(id: number) {
    const index = this.cartIds.indexOf(id);

    if (index !== -1) {
      this.cartIds.splice(index, 1);
      this.updateItemCount();
      this.saveCartIdsToStorage();
      console.log('Removing from Cart! Item count is ' + this.cartIds.length);
    }
  }

  // Method to remove an item from the cartIds array
  removeAllOccurrencesOfAnItem(id: number) {
    this.cartIds = this.cartIds.filter((item) => item !== id);
    this.updateItemCount();
    this.saveCartIdsToStorage();
  }

  removeAllItems() {
    localStorage.removeItem('cartIds');
    this.cartIds = [];
    this.updateItemCount();
  }

  // Method to update the itemCountSource based on the current length of cartIds
  private updateItemCount() {
    this.itemCountSource.next(this.cartIds.length);
  }

  // Method to save the cartIds array to localStorage
  private saveCartIdsToStorage() {
    localStorage.setItem('cartIds', JSON.stringify(this.cartIds));
  }

  // Method to retrieve the cartIds array from localStorage
  private getCartIdsFromStorage(): number[] {
    const storedCartIds = localStorage.getItem('cartIds');
    return storedCartIds ? JSON.parse(storedCartIds) : [];
  }
}
