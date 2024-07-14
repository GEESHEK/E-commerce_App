import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { WatchCard } from '../../models/watchCard';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WatchService {
  baseUrl = environment.apiUrl;
  homepageWatchCards: WatchCard[] = [];

  constructor(private http: HttpClient) {}

  getWatches() {
    return this.http.get(this.baseUrl + '/watch');
  }

  getHomepageWatchCards() {
    if (this.homepageWatchCards.length > 0) return of(this.homepageWatchCards);
    return this.http
      .get<WatchCard[]>(this.baseUrl + '/homepage/watch-cards')
      .pipe(
        map((watchCard) => {
          this.homepageWatchCards = watchCard;
          return watchCard;
        }),
      );
  }

  getWatchCards() {
    return this.http.get<WatchCard[]>(this.baseUrl + '/watch/watch-cards');
  }
}
