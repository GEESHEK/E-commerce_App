import {Component, computed, OnInit} from '@angular/core';
import {Brand} from '../../models/brand';
import {Category} from '../../models/category';
import {Observable} from 'rxjs';
import {WatchService} from '../services/watch.service';
import {CartService} from '../services/cart.service';
import {AccountService} from "../services/account.service";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  brands$: Observable<Brand[]> | undefined;
  categories$: Observable<Category[]> | undefined;
  itemsInCart: number = 0;
  username = computed(() => {
    const user = this.accountService.currentUser$();
    if (user) {
      this.userExists();
    }
    return user?.username ? this.capitalizeFirstLetter(user.username) + "'s" : "";
  });
  accountDropDowns: string[] | null = null;

  constructor(
    private watchService: WatchService,
    private cartService: CartService,
    private accountService: AccountService
  ) {
  }

  ngOnInit(): void {
    this.brands$ = this.watchService.getBrands();
    this.categories$ = this.watchService.getCategories();
    this.getCartItemCount();
    this.createDropDown();
  }

  private getCartItemCount() {
    this.cartService.itemCount$.subscribe({
      next: (count: number) => {
        this.itemsInCart = count;
      },
      error: (error) => console.log(error),
    });
  }

  getRouterLink(item: string): string {
    //auth guard will handle this and prompt user to sign in with toastr
    // if (this.username() === "" && item !== "Create Account") return '/signin';

    switch (item) {
      case 'Your Account':
        return '/account';
      case 'Your Orders':
        return '/myorders';
      case 'Create Account':
        return '/register';
      case 'Sign in':
        return '/signin';
      default:
        return "";
    }
  }

  logout() {
    this.accountService.logout();
    this.createDropDown();
  }

  capitalizeFirstLetter(value: string): string {
    if (!value) return value;
    return value.charAt(0).toUpperCase() + value.slice(1);
  }

  createDropDown() {
    if (this.username() === "") {
      this.accountDropDowns = ["Your Account", "Your Orders", "Create Account", "Sign in"];
    } else {
      this.userExists();
    }
  }

  userExists() {
    this.accountDropDowns = ["Your Account", "Your Orders", "Sign Out"];
  }
}
