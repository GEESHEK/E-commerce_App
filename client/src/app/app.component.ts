import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient} from "@angular/common/http";
import {AccountService} from "./services/account.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Home Page';
  protected readonly Router = Router;

  constructor(private http: HttpClient, private accountService: AccountService) {

  }

  ngOnInit() {
    // this.getUsers();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }

  // getUsers() {
  //   this.http.get('http://localhost:5001/api/users').subscribe({
  //
  //   })
  // }
}
