import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { WatchCard } from '../../models/watchCard';
import { map, of } from 'rxjs';
import { Brand } from '../../models/brand';
import { Categories } from '../../models/categories';
import { WatchDetail } from '../../models/watchDetail';
import { CartWatch } from '../../models/cartWatch';

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

  getWatchDetailById(id: number) {
    return this.http.get<WatchDetail>(
      this.baseUrl + '/watch/watch-detail/' + id,
    );
  }

  getCartWatches(ids: number[]) {
    let params = new HttpParams();
    let cartIds: string = '';

    ids.forEach((id, index) => {
      if (index === 0) {
        cartIds = `${id}`;
      } else {
        cartIds += `,${id}`;
      }
    });

    params = params.append('ids', cartIds);

    return this.http.get<CartWatch[]>(this.baseUrl + '/cart/watches', {
      params,
    });
  }

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl + '/brand');
  }

  getCategories() {
    return this.http.get<Categories[]>(this.baseUrl + '/category');
  }
}
