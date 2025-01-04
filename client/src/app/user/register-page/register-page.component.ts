import {Component, OnInit} from '@angular/core';
import {RegisterUser} from '../../../models/registerUser';
import {AccountService} from "../../services/account.service";
import {Router} from "@angular/router";
import {AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators} from "@angular/forms";

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});

  constructor(
    private accountService: AccountService,
    private router: Router,
    private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.initialiseForm();
  }

  register() {
    const registerUser: RegisterUser = {
      username: this.registerForm.value.username,
      password: this.registerForm.value.password,
      gender: this.registerForm.value.gender
    };

    this.accountService.register(registerUser).subscribe({
      next: response => {
        this.router.navigateByUrl('/home');
      },
      error: error => console.log(error)
    });
  }

  initialiseForm() {
    this.registerForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      confirmPassword: ['', [Validators.required, this.matchValues('password')]],
      gender: [null, Validators.required],
    });
    //if the password is changed it will rerun  the validator for confirm password
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {isMatching: true};
    }
  }
}
