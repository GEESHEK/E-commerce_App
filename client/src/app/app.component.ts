import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  baseUrl = environment.apiUrl;
  title = 'Yukata App';
  products: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    return this.http.get(this.baseUrl + '/products').subscribe({
      next: response => this.products = response,
      error: error => console.log(error)
    });
  }

}
