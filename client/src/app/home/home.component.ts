import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WatchService } from '../services/watch.service';
import { WatchCard } from '../../models/watchCard';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  title = 'Home Page';
  watchCards$: Observable<WatchCard[]> | undefined;

  constructor(
    private http: HttpClient,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.watchCards$ = this.watchService.getHomepageWatchCards();
  }

  // loadWatchCards() {
  //   this.watchService.getHomepageWatchCards().subscribe({
  //     next: (response) => (this.watchCards = response),
  //     error: (error) => console.log(error),
  //   });
  // }
}
