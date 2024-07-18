import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WatchPageComponent } from './watch/watch-page/watch-page.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'watches/:pageType', component: WatchPageComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
  //TODO add a route for not-found pathways
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
