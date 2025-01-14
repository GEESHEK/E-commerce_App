import {Component, OnInit} from '@angular/core';
import {User} from "../../models/user";
import {AccountService} from "../../services/account.service";
import {UserService} from "../../services/user.service";

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
 user: User | null  = this.accountService.currentUser$();
 username: string | null = "";
 userProfile: any;

  constructor(
    private accountService: AccountService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    if (this.user) {
      this.username = this.user?.username ? this.user.username : null;
    }
    this.userService.getUserProfile().subscribe({
      next: (response) => (this.userProfile = response),
      error: (error) => console.error(error),
    });
  }
}
