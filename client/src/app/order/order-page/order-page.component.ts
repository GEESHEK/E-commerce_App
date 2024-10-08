import {Component, OnInit} from '@angular/core';
import {Order} from '../../../models/order';
import {CartWatch} from '../../../models/cartWatch';
import {CartService} from '../../services/cart.service';
import {WatchService} from '../../services/watch.service';
import {FormBuilder, FormGroup, Validators,} from '@angular/forms';
import {Item} from "../../../models/item";
import {OrderService} from "../../services/order.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrls: ['./order-page.component.css'],
})
export class OrderPageComponent implements OnInit {
  private watchTypeId: number = 1;
  itemIds: number[] = [];
  orderForm: FormGroup = new FormGroup({});
  items: CartWatch[] = [];
  totalPrice: number = 0;
  validationErrors: string[] | undefined;

  constructor(
    private cartService: CartService,
    private watchService: WatchService,
    private fb: FormBuilder,
    private orderService: OrderService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.initialiseForm();
    this.itemIds = this.cartService.getItemIds();
    if (this.itemIds.length > 0) {
      this.loadItems(this.itemIds);
    }
  }

  initialiseForm() {
    this.orderForm = this.fb.group({
      firstName: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern('^[0-9]{11}$')]],
      address: ['', Validators.required],
      zipCode: ['', Validators.required],
      country: ['', Validators.required],
      city: ['', Validators.required],
    });
  }

  loadItems(ids: number[]) {
    this.watchService.getCartWatches(ids).subscribe({
      next: (response) => {
        this.items = response;
        this.totalPrice = this.calculateTotalPrice(this.items);
      },
      error: (error) => console.log(error),
    });
  }

  calculateTotalPrice(items: CartWatch[]): number {
    let totalPrice = 0;

    if (items.length <= 0) {
      return 0;
    }

    for (const itemId of this.itemIds) {
      totalPrice += items.find((x) => x.id === itemId)?.price ?? 0;
    }

    return totalPrice;
  }

  calculateItemCount(id: number): number {
    return this.itemIds.filter((ids) => ids === id).length;
  }

  orderNow() {
    if (this.orderForm.valid && this.items.length > 0) {

      const order: Order = {
        customerDetail: {
          firstName: this.orderForm.value.firstName,
          surname: this.orderForm.value.surname,
          email: this.orderForm.value.email,
          phoneNumber: this.orderForm.value.phoneNumber,
          address: this.orderForm.value.address,
          zipCode: this.orderForm.value.zipCode,
          city: this.orderForm.value.city,
          country: this.orderForm.value.country,
        },
        items: this.setOrderItems()
      }

      console.log(JSON.stringify(order));

      this.orderService.order(order).subscribe({
        next: (orderId: number) => {
          console.log("order was successful");
          //empty the shopping cart and redirect them to the success page
          this.cartService.removeAllItems();
          this.router.navigateByUrl('/order/confirmation/' + orderId);
        },
        error: (error: string[] | undefined) => {
          this.validationErrors = error;
          console.log("Errors: " + this.validationErrors)
        }
      })
    }
  }

  setOrderItems(): Item[] {
    const itemList: Item[] = [];

    for (const item of this.items) {
      itemList.push({
        productId: item.id,
        itemTypeId: this.watchTypeId,
        quantity: this.calculateItemCount(item.id),
      })
    }

    return itemList;
  }
}
