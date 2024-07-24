import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WatchService } from '../../services/watch.service';
import { WatchDetail } from '../../../models/watchDetail';
import { Photo } from '../../../models/photo';

@Component({
  selector: 'app-watch-detail-page',
  templateUrl: './watch-detail.component.html',
  styleUrls: ['./watch-detail.component.css'],
})
export class WatchDetailComponent implements OnInit {
  watchId: number | undefined;
  watchDetail: WatchDetail | undefined;
  mainPhoto: Photo | undefined;

  constructor(
    private watchService: WatchService,
    private route: ActivatedRoute,
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
        next: (response) => {
          this.watchDetail = response;
          this.mainPhoto = this.getMainPhoto();
          console.log('Main Photo:', this.mainPhoto);
        },
        error: (error) => console.log(error),
      });
    }
  }

  getObjectKeys(obj: any): (keyof WatchDetail)[] {
    return Object.keys(obj) as (keyof WatchDetail)[];
  }

  getMainPhoto(): Photo | undefined {
    console.log('watch details ' + this.watchDetail?.brand);
    return this.watchDetail?.photos.find((photo) => photo.isMain);
  }
}
