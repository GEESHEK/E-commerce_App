import {Component, OnInit} from '@angular/core';
import {WatchCard} from '../../models/watchCard';
import {WatchService} from '../../services/watch.service';
import {ActivatedRoute} from '@angular/router';
import {PaginatedResult} from "../../models/pagination";

@Component({
  selector: 'app-watch-page',
  templateUrl: './watch-page.component.html',
  styleUrls: ['./watch-page.component.css'],
})
export class WatchPageComponent implements OnInit {
  pageType: string | null = ''; //dynamically change based on the page
  filter: string | null = '';
  watchCards: WatchCard[] = [];
  paginatedResults: PaginatedResult<WatchCard[]> = {
    items: [],
    pagination: {
      currentPage: 1,
      itemsPerPage: 10,
      totalItems: 0,
      totalPages: 0
    }
  };

  constructor(
    private route: ActivatedRoute,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.pageType = params.get('pageType');
      this.filter = params.get('filter');

      if (this.filter == 'brand' && this.pageType) {
        this.loadWatchCards(this.pageType);
        return;
      }

      if (this.filter == 'category' && this.pageType) {
        this.loadWatchCards(undefined, this.pageType);
        return;
      }

      this.loadWatchCards();
    });
  }

  loadWatchCards(brand?: string, category?: string) {
    this.watchService.getWatchCards(brand, category).subscribe({
      next: (response) => (this.watchCards = response),
      error: (error) => console.log(error),
    });
  }

  loadPaginatedWatchCards(pageNumber?: number, pageSize?: number) {
    this.watchService.getPaginatedWatchCards(pageNumber, pageSize).subscribe({
      next: (response) => (this.paginatedResults = response),
      error: (error) => console.log(error),
    })
  }
}
