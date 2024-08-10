import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService implements OnInit {
  baseUrl = environment.apiUrl;
  private watchCartIds: number[] = this.getWatchCartIdsFromStorage();
  //give initial value to observable
  private itemCountSource = new BehaviorSubject<number>(
    this.watchCartIds.length,
  );
  itemCount$ = this.itemCountSource.asObservable();

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // Initialize itemCountSource with the length from localStorage
    this.updateItemCount();
  }

  add(id: number) {
    this.watchCartIds.push(id);
    console.log('Adding to Cart! Watch count is ' + this.watchCartIds.length);
    //this is needed to update the behaviourSubject
    // this.itemCountSource.next(this.watchCartIds.length);
    this.updateItemCount();
    this.saveWatchCartIdsToStorage();
  }

  removeOneItem(id: number) {
    const index = this.watchCartIds.indexOf(id);

    // Check if the id is found in the array
    if (index !== -1) {
      // Remove the item at the found index
      this.watchCartIds.splice(index, 1);
      this.updateItemCount();
      this.saveWatchCartIdsToStorage(); // Or whichever storage method you're using
    }
  }

  // Method to remove an item from the watchCartIds array
  removeAllSpecificIdOccurrences(id: number) {
    this.watchCartIds = this.watchCartIds.filter((item) => item !== id);
    this.updateItemCount();
    this.saveWatchCartIdsToStorage();
  }

  removeAllItems() {
    localStorage.removeItem('watchCartIds');
    this.updateItemCount();
  }

  // Method to update the itemCountSource based on the current length of watchCartIds
  private updateItemCount() {
    this.itemCountSource.next(this.watchCartIds.length);
  }

  // Method to save the watchCartIds array to localStorage
  private saveWatchCartIdsToStorage() {
    localStorage.setItem('watchCartIds', JSON.stringify(this.watchCartIds));
  }

  // Method to retrieve the watchCartIds array from localStorage
  private getWatchCartIdsFromStorage(): number[] {
    const storedCartIds = localStorage.getItem('watchCartIds');
    return storedCartIds ? JSON.parse(storedCartIds) : [];
  }
}
