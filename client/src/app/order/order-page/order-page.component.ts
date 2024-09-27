import { Component } from '@angular/core';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css'],
})
export class OrderPageComponent {
  modal: any = {};

  orderNow() {
    console.log(this.modal);
  }

  cancel() {
    console.log('cancelled');
  }
}
