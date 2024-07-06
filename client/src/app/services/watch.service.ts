import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class WatchService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getWatches() {
    return this.http.get(this.baseUrl + '/watch');
  }
}
