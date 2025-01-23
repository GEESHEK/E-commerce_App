import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {WatchPageComponent} from './watch/watch-page/watch-page.component';
import {WatchDetailComponent} from './watch/watch-detail-page/watch-detail.component';
import {CartComponent} from './order/cart/cart.component';
import {OrderPageComponent} from './order/order-page/order-page.component';
import {OrderConfirmationPageComponent} from './order/order-confirmation-page/order-confirmation-page.component';
import {SignInPageComponent} from "./user/sign-in-page/sign-in-page.component";
import {RegisterPageComponent} from "./user/register-page/register-page.component";
import {AccountPageComponent} from "./user/account-page/account-page.component";
import {authGuard} from "./guards/auth.guard";
import {MyOrdersPageComponent} from "./order/my-orders-page/my-orders-page.component";

const appName: string = 'JDM Watches';

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Home - ' + appName },
  { path: 'watches/:filter/:pageType', component: WatchPageComponent, title: 'Watches - ' + appName },
  { path: 'watch/:watchId', component: WatchDetailComponent, title: 'Watch Detail - ' + appName },
  { path: 'cart', component: CartComponent, title: 'Cart - ' + appName },
  { path: 'order', component: OrderPageComponent, title: 'Order - ' + appName },
  { path: 'order/confirmation', component: OrderConfirmationPageComponent, title: 'Order Confirmation - ' + appName },
  { path: 'signin', component: SignInPageComponent, title: 'Sign In - ' + appName },
  { path: 'register', component: RegisterPageComponent, title: 'Create Account - ' + appName },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'account', component: AccountPageComponent, title: 'My Account - ' + appName },
      { path: 'myorders', component: MyOrdersPageComponent, title: 'My Orders - ' + appName },
    ]
  },
  { path: '**', component: HomeComponent, pathMatch: 'full', title: 'Home - ' + appName,},
  //TODO add a route for not-found pathways
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
