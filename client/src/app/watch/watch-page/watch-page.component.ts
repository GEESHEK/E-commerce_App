import {Component, OnInit} from '@angular/core';
import {WatchCard} from '../../models/watchCard';
import {WatchService} from '../../services/watch.service';
import {ActivatedRoute} from '@angular/router';
import {PaginatedResult} from "../../models/pagination";
import {WatchFilter} from "../../models/watchFilter";

@Component({
  selector: 'app-watch-page',
  templateUrl: './watch-page.component.html',
  styleUrls: ['./watch-page.component.css'],
})
export class WatchPageComponent implements OnInit {
  pageType: string | null = ''; //dynamically change based on the page
  filter: string | null = '';
  watchFilters: WatchFilter | null = null;
  userFilters: WatchFilter = {
    brands: [], calibres: [], dials: [], diameters: [], movementTypes: [], price: [], watchTypes: []
  };
  pageNumber = 1;
  pageSize = 8;
  paginatedResults: PaginatedResult<WatchCard[]> = {
    items: [],
    pagination: {
      currentPage: 1,
      itemsPerPage: 8,
      totalItems: 0,
      totalPages: 0
    }
  };

  constructor(
    private route: ActivatedRoute,
    private watchService: WatchService,
  ) {
  }

  ngOnInit(): void {
    this.userFilters = this.watchService.getUserFilters();
    this.loadFilters();
    this.checkPageTypeAndFilterThenLoadWatches();
  }

  loadWatchCards() {
    this.watchService.getWatchCards(this.userFilters, this.pageNumber, this.pageSize).subscribe({
      next: (response) => (this.paginatedResults = response),
      error: (error) => console.log(error),
    });
  }

  loadFilters() {
    if (this.watchService.watchFilters !== null) {
      this.watchFilters = this.watchService.watchFilters;
      return;
    }

    this.watchService.getWatchFilters().subscribe({
      next: (response) => this.watchFilters = response,
      error: (error) => console.log(error),
    });
  }

  pageChanged(event: any) {
    if (this.pageNumber !== event.page) {
      this.pageNumber = event.page;
      this.checkPageTypeAndFilterThenLoadWatches();
    }
  }

  checkPageTypeAndFilterThenLoadWatches() {
    this.route.paramMap.subscribe((params) => {
      this.pageType = params.get('pageType');
      this.filter = params.get('filter');

      const currentPageRoute = this.watchService.getPageRoute();

      if (currentPageRoute !== this.filter + "/" + this.pageType) {
        this.watchService.setPageRoute(this.filter + "/" + this.pageType);
        this.watchService.resetUserFilters();
        this.userFilters = this.watchService.getUserFilters();
      }

      if (this.filter == 'brand' && this.pageType) {
        this.userFilters.brands.push(this.pageType);
        this.loadWatchCards();
        return;
      }

      if (this.filter == 'category' && this.pageType) {
        this.userFilters.watchTypes.push(this.pageType);
        this.loadWatchCards();
        return;
      }

      this.loadWatchCards();
    });
  }

  filterWatches(filter: string, value: any) {
    switch (filter) {
      case 'price':
        this.userFilters.price[0] = value;
        break;
      case 'brands':
        this.userFilters.brands = this.addOrRemoveUserFilters(this.userFilters.brands, value);
        break;
      case 'calibres':
        this.userFilters.calibres = this.addOrRemoveUserFilters(this.userFilters.calibres, value);
        break;
      case 'dials':
        this.userFilters.dials = this.addOrRemoveUserFilters(this.userFilters.dials, value);
        break;
      case 'diameters':
        this.userFilters.diameters = this.addOrRemoveUserFilters(this.userFilters.diameters, value);
        break;
      case 'movementTypes':
        this.userFilters.movementTypes = this.addOrRemoveUserFilters(this.userFilters.movementTypes, value);
        break;
      case 'watchTypes':
        this.userFilters.watchTypes = this.addOrRemoveUserFilters(this.userFilters.watchTypes, value);
        break;
      default:
        break;
    }

    this.watchService.setUserFilters(this.userFilters);

    this.watchService.getWatchCards(this.userFilters, this.pageNumber, this.pageSize).subscribe({
      next: (response) => (this.paginatedResults = response),
      error: (error) => console.log(error),
    });
  }

  private addOrRemoveUserFilters<T>(arr: T[], val: T): T[] {
    const index = arr.indexOf(val);
    if (index > -1) {
      arr.splice(index, 1);
    } else {
      arr.push(val);
    }
    return arr;
  };

  clearFilter(filter: string) {
    if (this.userFilters === null) {
      return;
    }

    switch (filter) {
      case 'price':
        this.userFilters.price = [];
        break;
      case 'brands':
        this.userFilters.brands = [];
        break;
      case 'calibres':
        this.userFilters.calibres = [];
        break;
      case 'dials':
        this.userFilters.dials = [];
        break;
      case 'diameters':
        this.userFilters.diameters = [];
        break;
      case 'movementTypes':
        this.userFilters.movementTypes = [];
        break;
      case 'watchTypes':
        this.userFilters.watchTypes = [];
        break;
      case 'all':
        this.userFilters = this.userFilters = {
          brands: [],
          calibres: [],
          dials: [],
          diameters: [],
          movementTypes: [],
          watchTypes: [],
          price: []
        }
        break
      default:
        break;
    }

    this.watchService.setUserFilters(this.userFilters);

    this.watchService.getWatchCards(this.userFilters, this.pageNumber, this.pageSize).subscribe({
      next: (response) => (this.paginatedResults = response),
      error: (error) => console.log(error),
    });
  }
}
