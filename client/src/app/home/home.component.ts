import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  title = 'Home Page';
  baseUrl = environment.apiUrl;
  watches: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getWatches();
  }

  getWatches() {
    return this.http.get(this.baseUrl + '/watch').subscribe({
      next: (response) => (this.watches = response),
      error: (error) => console.log(error),
    });
  }
}
