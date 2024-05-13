import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  baseUrl = environment.apiUrl;
  title = 'JDM Watches';
  watches: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getWatches();
  }

  getWatches() {
    return this.http.get(this.baseUrl + '/watches').subscribe({
      next: response => this.watches = response,
      error: error => console.log(error)
    });
  }

}
