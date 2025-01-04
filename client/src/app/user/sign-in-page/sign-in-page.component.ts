import {Component, inject, OnInit} from '@angular/core';
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";
import {ToastrService} from "ngx-toastr";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {SignInUser} from "../../../models/signInUser";

@Component({
  selector: 'app-sign-in-page',
  templateUrl: './sign-in-page.component.html',
  styleUrls: ['./sign-in-page.component.css']
})
export class SignInPageComponent implements OnInit {
  private accountService = inject(AccountService);
  private router = inject(Router);
  private toastr = inject(ToastrService);
  private fb = inject(FormBuilder);
  signInForm: FormGroup = new FormGroup({});
  model: any = {
    username: "",
    password: "",
    gender: ""
  };

  ngOnInit(): void {
    this.initialiseForm();
  }

  login() {
    const signInUser: SignInUser = {
      username: this.signInForm.value.username,
      password: this.signInForm.value.password,
    }

    this.accountService.login(signInUser).subscribe({
      next: response => {
        this.router.navigateByUrl('/home');
      },
      error: error => this.toastr.error(error.error)
    })
  }

  initialiseForm() {
    this.signInForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

}
