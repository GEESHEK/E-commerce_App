import {Injectable, signal} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {User} from "../../models/user";
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  currentUser = signal<User | null>(null);

  constructor(private Http: HttpClient) { }

  login(model: any) {
    return this.Http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
