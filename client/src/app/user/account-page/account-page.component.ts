import {Component, OnInit} from '@angular/core';
import {User} from "../../models/user";
import {AccountService} from "../../services/account.service";
import {UserService} from "../../services/user.service";
import {CustomerDetail} from "../../models/customerDetail";
import {ToastrService} from "ngx-toastr";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
  user: User | null = this.accountService.currentUser$();
  username: string | null = "";
  userProfile: CustomerDetail | undefined;
  userProfileForm: FormGroup = new FormGroup({});

  constructor(
    private accountService: AccountService,
    private userService: UserService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.initialiseForm();
    if (this.user) {
      this.username = this.user?.username ? this.user.username : null;
    }
    this.userService.getUserProfile().subscribe({
      next: (response) => {
        (this.userProfile = response);
        this.initialiseForm();
      },
      error: (error) => {
        if (error.error === "User details not found") {
          this.initialiseForm();
        } else {
          this.toastr.error(error.error);
        }
      }
    });
  }

  updateProfile() {
    console.log(this.user?.username + " updated!");
  }

  initialiseForm() {
    if (this.userProfile) {
      this.userProfileForm = this.fb.group({
        firstName: [this.userProfile.firstName, Validators.required],
        surname: [this.userProfile.surname, Validators.required],
        email: [this.userProfile.email, [Validators.required, Validators.email]],
        phoneNumber: [this.userProfile.phoneNumber, [Validators.required, Validators.pattern('^[0-9]{11}$')]],
        address: [this.userProfile.address, Validators.required],
        zipCode: [this.userProfile.zipCode, Validators.required],
        city: [this.userProfile.city, Validators.required],
        country: [this.userProfile.country, Validators.required],
      }, {updateOn: 'change'});
    } else {
      this.userProfileForm = this.fb.group({
        firstName: ["", Validators.required],
        surname: ["", Validators.required],
        email: ["", [Validators.required, Validators.email]],
        phoneNumber: ["", [Validators.required, Validators.pattern('^[0-9]{11}$')]],
        address: ["", Validators.required],
        zipCode: ["", Validators.required],
        city: ["", Validators.required],
        country: ["", Validators.required],
      });
    }
  }
}
