import {Component, inject} from '@angular/core';
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.css']
})
export class SignInPageComponent {
  private accountService = inject(AccountService);
  private router = inject(Router);
  model: any = {};

  login() {
    console.log(this.model);
    this.accountService.login(this.model).subscribe({
      next: response => {
        this.router.navigateByUrl('/home');
      },
      error: error => console.log(error)
    })
  }

}
