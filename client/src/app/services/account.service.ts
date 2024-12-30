import {inject, Injectable, signal} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {User} from "../../models/user";
import {map} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  private currentUser = signal<User | null>(null);
  currentUser$ = this.currentUser.asReadonly()

  login(model: any) {
    return this.http.post<User>(this.baseUrl + '/account/login', model).pipe(
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

  setUser(user: User) {
    this.currentUser.set(user);
  }
}
