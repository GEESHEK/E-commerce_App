import { Component, OnInit } from '@angular/core';
import { WatchService } from '../services/watch.service';
import { WatchCard } from '../models/watchCard';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  watchCards: WatchCard[] = [];

  constructor(
    private watchService: WatchService,
    private toastr: ToastrService
  ) {
  }

  ngOnInit(): void {
    this.watchService.getHomepageWatchCards().subscribe({
      next: (cards) => {
        this.watchCards = cards;
      },
      error: (error) => {
        console.log('Failed to load watches', error);
        this.toastr.error('Failed to load watches');
      }
    });
  }
}
