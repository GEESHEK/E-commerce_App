import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {WatchPageComponent} from './watch/watch-page/watch-page.component';
import {WatchDetailComponent} from './watch/watch-detail-page/watch-detail.component';
import {CartComponent} from './cart/cart.component';
import {OrderPageComponent} from './order/order-page/order-page.component';
import {OrderConfirmationPageComponent} from './order/order-confirmation-page/order-confirmation-page.component';

const appName: string = 'JDM Watches';

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Home - ' + appName },
  { path: 'watches/:filter/:pageType', component: WatchPageComponent, title: 'Watches - ' + appName,},
  { path: 'watch/:watchId', component: WatchDetailComponent, title: 'Watch Detail - ' + appName,},
  { path: 'cart', component: CartComponent, title: 'Cart - ' + appName },
  { path: 'order', component: OrderPageComponent, title: 'Order - ' + appName },
  { path: 'order/confirmation', component: OrderConfirmationPageComponent, title: 'Order Confirmation - ' + appName,},
  { path: '**', component: HomeComponent, pathMatch: 'full', title: 'Home - ' + appName,},
  //TODO add a route for not-found pathways
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
