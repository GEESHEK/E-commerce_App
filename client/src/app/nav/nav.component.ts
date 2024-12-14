import {Component, OnInit} from '@angular/core';
import {Brand} from '../../models/brand';
import {Category} from '../../models/category';
import {Observable} from 'rxjs';
import {WatchService} from '../services/watch.service';
import {CartService} from '../services/cart.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  brands$: Observable<Brand[]> | undefined;
  categories$: Observable<Category[]> | undefined;
  itemsInCart: number = 0;
  username: string | null = null;
  accountDropDowns: string[] | null = null;

  constructor(
    private watchService: WatchService,
    private cartService: CartService,
  ) {
  }

  ngOnInit(): void {
    this.brands$ = this.watchService.getBrands();
    this.categories$ = this.watchService.getCategories();
    this.getCartItemCount();
    // this.username = "Gee's";
    if (this.username == null) {
      this.accountDropDowns = ["Your Account", "Your Orders", "Create Account", "Sign in"];
    } else {
      this.accountDropDowns = ["Your Account", "Your Orders", "Sign Out"];
    }
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
    if (this.username == null && item != "Create Account") return '/signin';

    switch (item) {
      case 'Your Account':
        return '/account';
      case 'Your Orders':
        return '/account/myorders';
      case 'Create Account':
        return '/signup';
      case 'Sign in':
        return '/signin';
      default:
        return "";
    }
  }
}
