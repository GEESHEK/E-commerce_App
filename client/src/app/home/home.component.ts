import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { WatchService } from '../services/watch.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  title = 'Home Page';
  baseUrl = environment.apiUrl;
  watches: any;

  constructor(
    private http: HttpClient,
    private watchService: WatchService,
  ) {}

  ngOnInit(): void {
    this.watchService.getWatches().subscribe({
      next: (response) => (this.watches = response),
      error: (error) => console.log(error),
    });
  }
}
