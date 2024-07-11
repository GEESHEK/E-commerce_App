import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { WatchCard } from '../../models/watchCard';

@Injectable({
  providedIn: 'root',
})
export class WatchService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getWatches() {
    return this.http.get(this.baseUrl + '/watch');
  }

  getHomepageWatchCards() {
    return this.http.get<WatchCard[]>(this.baseUrl + '/homepage/watch-cards');
  }
}
