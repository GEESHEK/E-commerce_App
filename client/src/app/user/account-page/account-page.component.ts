import {Component, OnInit} from '@angular/core';
import {User} from "../../../models/user";
import {AccountService} from "../../services/account.service";

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
 user: User | null  = this.accountService.currentUser$();
 username: string | null = "";

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    if (this.user) {
      this.username = this.user?.username ? this.user.username : null;
    }
  }
}
