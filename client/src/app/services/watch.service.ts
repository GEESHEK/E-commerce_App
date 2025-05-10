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
  watchFilters: WatchFilter | null = null;

  constructor(private http: HttpClient) {
  }

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

  getWatchDetailById(id: number) {
    return this.http.get<WatchDetail>(
      this.baseUrl + '/watch/watch-detail/' + id,
    );
  }

  getWatchCards(filter: WatchFilter, pageNumber?: number, pageSize?: number) {
    let params = new HttpParams();

    if (filter.brands.length > 0) {
      filter.brands.forEach(brand => {
        params = params.append('brands', brand);
      });
    }

    if (filter.calibres.length > 0) {
      filter.calibres.forEach(calibre => {
        params = params.append('calibres', calibre);
      });
    }

    if (filter.dials.length > 0) {
      filter.dials.forEach(dial => {
        params = params.append('dials', dial);
      });
    }

    if (filter.diameters.length > 0) {
      filter.diameters.forEach(diameter => {
        params = params.append('diameters', diameter);
      });
    }

    if (filter.movementTypes.length > 0) {
      filter.movementTypes.forEach(movementType => {
        params = params.append('movementTypes', movementType);
      });
    }

    if (filter.watchTypes.length > 0) {
      filter.watchTypes.forEach(watchType => {
        params = params.append('watchTypes', watchType);
      });
    }

      if (filter.price.length > 0) {
        filter.price.forEach(price => {
          params = params.append('price', price);
        });
    }

    if (pageNumber && pageSize) {
      params = params.append('pageNumber', pageNumber);
      params = params.append('pageSize', pageSize);
    }

    //get method extracts the results from the response, but the response contains the headers we need
    return this.http.get<WatchCard[]>(this.baseUrl + '/watch/watch-cards', {observe: 'response', params}).pipe(
      map(response => {
        let paginatedResult = new PaginatedResult<WatchCard[]>();
        paginatedResult.items = response.body ?? []; // or as WatchCard
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination')!);
        return paginatedResult;
      }));
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
    return this.http.get<WatchFilter>(this.baseUrl + '/watch/filters').pipe(
      map(response => {
        this.watchFilters = response;
        return response;
      })
    );
  }
}
