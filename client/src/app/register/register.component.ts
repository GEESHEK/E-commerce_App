import {Component} from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  modal: any = {};

  register() {
    console.log(this.modal);
  }

  cancel() {
    console.log("cancelled");
  }
}
