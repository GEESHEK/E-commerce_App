import { Component, Input } from '@angular/core';
import { WatchCard } from '../../../models/watchCard';

@Component({
  selector: 'app-watch-card',
  templateUrl: './watch-card.component.html',
  styleUrls: ['./watch-card.component.css'],
})
export class WatchCardComponent {
  @Input() watchCard: WatchCard | undefined;
}
