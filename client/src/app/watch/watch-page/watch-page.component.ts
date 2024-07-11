import { Component, OnInit } from '@angular/core';
import { WatchCard } from '../../../models/watchCard';
import { HttpClient } from '@angular/common/http';
import { WatchService } from '../../services/watch.service';

@Component({
  selector: 'app-watch-page',
  templateUrl: './watch-page.component.html',
  styleUrls: ['./watch-page.component.css'],
})
export class WatchPageComponent implements OnInit {
  page: string = 'All Watch Page'; //dynamically change based on the page
  watchCards: WatchCard[] = [];

  constructor(
    private http: HttpClient,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.loadWatchCards();
  }

  loadWatchCards() {
    this.watchService.getWatchCards().subscribe({
      next: (response) => (this.watchCards = response),
      error: (error) => console.log(error),
    });
  }
}
