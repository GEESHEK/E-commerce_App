import {inject, Injectable, signal} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {User} from "../models/user";
import {map} from "rxjs";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {RegisterUser} from "../models/registerUser";
import {SignInUser} from "../models/signInUser";
import {OrderService} from "./order.service";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient);
  private router = inject(Router);
  private toastr = inject(ToastrService);
  private orderService = inject(OrderService);
  baseUrl = environment.apiUrl;
  private currentUser = signal<User | null>(null);
  currentUser$ = this.currentUser.asReadonly()

  login(signInUser: SignInUser) {
    return this.http.post<User>(this.baseUrl + '/account/login', signInUser).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
          this.toastr.success('Login Successfully');
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('user');
    this.orderService.successOrder = undefined;
    this.currentUser.set(null);
    this.router.navigateByUrl('/signin');
    this.toastr.success('Logout Successfully');
  }

  register(registerUser: RegisterUser) {
    return this.http.post<User>(this.baseUrl + '/account/register', registerUser).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    )
  }

  setUser(user: User) {
    this.currentUser.set(user);
  }
}
