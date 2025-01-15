import {Component, Input} from '@angular/core';
import {WatchCard} from '../../models/watchCard';
import {CartService} from '../../services/cart.service';

@Component({
  selector: 'app-watch-card',
  templateUrl: './watch-card.component.html',
  styleUrls: ['./watch-card.component.css'],
})
export class WatchCardComponent {
  @Input() watchCard: WatchCard | undefined;

  constructor(private cartService: CartService) {}

  isQtyInCartEqualToStock(watch: WatchCard): boolean {
    return this.cartService.calculateItemCount(watch.id) == watch.stock;
  }
}
