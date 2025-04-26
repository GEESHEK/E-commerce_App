import {Component, OnInit} from '@angular/core';
import {WatchCard} from '../../models/watchCard';
import {WatchService} from '../../services/watch.service';
import {ActivatedRoute, Router} from '@angular/router';
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
    private router: Router,
    private route: ActivatedRoute,
    private watchService: WatchService,
  ) {
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      const page = params['page'] ? + params['page'] : null;
      const pageSize = params['pageSize'] ? + params['pageSize'] : null;

      this.userFilters = {
        brands: [],
        calibres: [],
        dials: [],
        diameters: [],
        movementTypes: [],
        price: [],
        watchTypes: []
      };

      if (page && pageSize) {
        this.pageNumber = page;
        this.pageSize = pageSize;
        this.userFilters.brands = this.getArrayFromParams(params['brands']);
        this.userFilters.calibres = this.getArrayFromParams(params['calibres']);
        this.userFilters.dials = this.getArrayFromParams(params['dials']);
        this.userFilters.diameters = this.getArrayFromParams(params['diameters']);
        this.userFilters.movementTypes = this.getArrayFromParams(params['movementTypes']);
        this.userFilters.price = this.getArrayFromParams(params['price']);
        this.userFilters.watchTypes = this.getArrayFromParams(params['watchTypes']);
      } else {
        // No pagination in URL, so set defaults in URL
        this.pageNumber = 1;
        this.pageSize = 8;
        this.updateUrl();
      }
    })
    this.loadFilters();
    // Handle the pageType and filter params from route
    this.route.paramMap.subscribe((routeParams) => {
      this.pageType = routeParams.get('pageType');
      this.filter = routeParams.get('filter');

      if (this.filter === 'brand' && this.pageType) {
        this.userFilters.brands.push(this.pageType);
      }

      if (this.filter === 'category' && this.pageType) {
        this.userFilters.watchTypes.push(this.pageType);
      }

      this.loadWatchCards();
    });
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
      this.loadWatchCards();
      this.updateUrl();
    }
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

    this.loadWatchCards();
    this.updateUrl();
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
        this.userFilters = {
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

    this.loadWatchCards();
    this.updateUrl();
  }

  updateUrl() {
    const queryParams: any = {
      page: this.pageNumber,
      pageSize: this.pageSize,
    };

    if (this.userFilters) {
      if (this.userFilters.brands.length) queryParams.brands = this.userFilters.brands;
      if (this.userFilters.calibres.length) queryParams.calibres = this.userFilters.calibres;
      if (this.userFilters.dials.length) queryParams.dials = this.userFilters.dials;
      if (this.userFilters.diameters.length) queryParams.diameters = this.userFilters.diameters;
      if (this.userFilters.movementTypes.length) queryParams.movementTypes = this.userFilters.movementTypes;
      if (this.userFilters.price.length) queryParams.price = this.userFilters.price;
      if (this.userFilters.watchTypes.length) queryParams.watchTypes = this.userFilters.watchTypes;
    }

    void this.router.navigate([], {
      relativeTo: this.route,
      queryParams,
      queryParamsHandling: 'merge',
      replaceUrl: true,
    });
  }

  private getArrayFromParams(param: any): any[] {
    if (!param) return [];
    return Array.isArray(param) ? param : [param];
  }
}
