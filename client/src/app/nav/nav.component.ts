import { Component, OnInit } from '@angular/core';
import { Brand } from '../../models/brand';
import { Categories } from '../../models/categories';
import { Observable } from 'rxjs';
import { WatchService } from '../services/watch.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  brands$: Observable<Brand[]> | undefined;
  categories$: Observable<Categories[]> | undefined;

  constructor(private watchService: WatchService) {}

  ngOnInit(): void {
    this.brands$ = this.watchService.getBrands();
    this.categories$ = this.watchService.getCategories();
  }
}
