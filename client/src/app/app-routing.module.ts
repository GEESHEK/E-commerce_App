import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WatchPageComponent } from './watch/watch-page/watch-page.component';
import { WatchDetailComponent } from './watch/watch-detail-page/watch-detail.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'watches/:filter/:pageType', component: WatchPageComponent },
  { path: 'watch/:watchId', component: WatchDetailComponent },
  { path: 'cart', component: CartComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
  //TODO add a route for not-found pathways
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
