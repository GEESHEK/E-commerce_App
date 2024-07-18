import { Component, OnInit } from '@angular/core';
import { WatchCard } from '../../../models/watchCard';
import { HttpClient } from '@angular/common/http';
import { WatchService } from '../../services/watch.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-watch-page',
  templateUrl: './watch-page.component.html',
  styleUrls: ['./watch-page.component.css'],
})
export class WatchPageComponent implements OnInit {
  pageType: string | null = ''; //dynamically change based on the page
  watchCards: WatchCard[] = [];

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.pageType = params.get('pageType');
    });
    this.loadWatchCards();
  }
  //TODO filter the watches
  loadWatchCards() {
    this.watchService.getWatchCards().subscribe({
      next: (response) => (this.watchCards = response),
      error: (error) => console.log(error),
    });
  }
}
