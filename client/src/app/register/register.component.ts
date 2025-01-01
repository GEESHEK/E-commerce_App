import {Component} from '@angular/core';
import {AccountService} from "../services/account.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  modal: any = {};

  constructor(
    private accountService: AccountService,
    private router: Router) {
  }

  register() {
    this.accountService.register(this.modal).subscribe({
      next: response => {
        this.router.navigateByUrl('/home');
      },
      error: error => console.log(error)
    });
  }
}
