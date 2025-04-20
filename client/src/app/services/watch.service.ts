import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';
import {HttpClient, HttpParams} from '@angular/common/http';
import {WatchCard} from '../models/watchCard';
import {map, of} from 'rxjs';
import {Brand} from '../models/brand';
import {Category} from '../models/category';
import {WatchDetail} from '../models/watchDetail';
import {CartWatch} from '../models/cartWatch';
import {PaginatedResult} from "../models/pagination";
import {WatchFilter} from "../models/watchFilter";

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

  getWatchCards(pageNumber?: number, pageSize?: number, brand?: string, watchType?: string) {
    let params = new HttpParams();

    if (typeof brand !== 'undefined') {
      params = params.append('brand', brand);
    }

    if (typeof watchType !== 'undefined') {
      params = params.append('watchType', watchType);
    }

    if (pageNumber && pageSize) {
      params = params.append('pageNumber', pageNumber);
      params = params.append('pageSize', pageSize);
    }
    //get method exacts the results from the response but the response contains the headers we need
    return this.http.get<WatchCard[]>(this.baseUrl + '/watch/watch-cards', { observe: 'response', params}).pipe(
      map(response => {
        let paginatedResult = new PaginatedResult<WatchCard[]>();
        paginatedResult.items = response.body ?? []; // or as WatchCard
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination')!);
        return  paginatedResult;
      }));
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
    return this.http.get<Category[]>(this.baseUrl + '/watchType');
  }

  getWatchFilters() {
    return this.http.get<WatchFilter>(this.baseUrl + '/watch/filters');
  }
}
