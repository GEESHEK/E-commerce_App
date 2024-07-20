import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WatchService } from '../../services/watch.service';
import { WatchDetail } from '../../../models/watchDetail';

@Component({
  selector: 'app-watch-detail-page',
  templateUrl: './watch-detail.component.html',
  styleUrls: ['./watch-detail.component.css'],
})
export class WatchDetailComponent implements OnInit {
  watchId: number | undefined;
  watchDetail: WatchDetail | undefined;

  constructor(
    private route: ActivatedRoute,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const param = params.get('watchId');
      this.watchId = param !== null ? +param : NaN;
      if (isNaN(this.watchId)) {
        // Handle the case where the parameter is not a number
        console.error('Invalid parameter value');
        //TODO redirect user
      }
      this.loadWatchDetails();
    });
  }

  loadWatchDetails(): void {
    if (this.watchId != null) {
      this.watchService.getWatchDetailById(this.watchId).subscribe({
        next: (response) => (this.watchDetail = response),
        error: (error) => console.log(error),
      });
    }
  }

  getObjectKeys(obj: any): (keyof WatchDetail)[] {
    return Object.keys(obj) as (keyof WatchDetail)[];
  }
}
