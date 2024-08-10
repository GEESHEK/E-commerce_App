import { Component, OnInit } from '@angular/core';
import { Brand } from '../../models/brand';
import { Categories } from '../../models/categories';
import { Observable, Subscription } from 'rxjs';
import { WatchService } from '../services/watch.service';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  brands$: Observable<Brand[]> | undefined;
  categories$: Observable<Categories[]> | undefined;
  itemsInCart: number = 0;
  private subscription: Subscription = new Subscription();

  constructor(
    private watchService: WatchService,
    private cartService: CartService,
  ) {}

  ngOnInit(): void {
    this.brands$ = this.watchService.getBrands();
    this.categories$ = this.watchService.getCategories();
    this.getCartItemCount();
  }

  private getCartItemCount() {
    this.subscription = this.cartService.itemCount$.subscribe({
      next: (count: number) => {
        this.itemsInCart = count;
      },
      error: (error) => console.log(error),
    });
  }
}
