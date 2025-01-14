import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {CustomerDetail} from "../models/customerDetail";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUserProfile() {
    return this.http.get<CustomerDetail>(this.baseUrl + '/user/details');
  }
}
