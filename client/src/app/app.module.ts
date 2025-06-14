import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { WatchCardComponent } from './watch/watch-card/watch-card.component';
import { NgOptimizedImage } from '@angular/common';
import { WatchPageComponent } from './watch/watch-page/watch-page.component';
import { ImageFallbackDirective } from './directive/image-fallback.directive';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { WatchDetailComponent } from './watch/watch-detail-page/watch-detail.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { CartComponent } from './order/cart/cart.component';
import { OrderConfirmationPageComponent } from './order/order-confirmation-page/order-confirmation-page.component';
import { OrderPageComponent } from './order/order-page/order-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './forms/text-input/text-input.component';
import { OrderWatchListComponent } from './order/order-watch-list/order-watch-list.component';
import { SignInPageComponent } from './user/sign-in-page/sign-in-page.component';
import { RegisterPageComponent } from './user/register-page/register-page.component';
import { AccountPageComponent } from './user/account-page/account-page.component';
import { ToastrModule } from 'ngx-toastr';
import { MyOrdersPageComponent } from './order/my-orders-page/my-orders-page.component';
import { jwtInterceptor } from './interceptors/jwtInterceptor';
import { FooterComponent } from './footer/footer.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxSpinnerModule } from 'ngx-spinner';
import { loadingInterceptor } from './interceptors/loading.interceptor';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './directive/has-role.directive';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    WatchCardComponent,
    WatchPageComponent,
    ImageFallbackDirective,
    WatchDetailComponent,
    CartComponent,
    OrderConfirmationPageComponent,
    OrderPageComponent,
    TextInputComponent,
    OrderWatchListComponent,
    SignInPageComponent,
    RegisterPageComponent,
    AccountPageComponent,
    MyOrdersPageComponent,
    FooterComponent,
    AdminPanelComponent,
    HasRoleDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgOptimizedImage,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    AccordionModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    PaginationModule,
    NgxSpinnerModule.forRoot({
      type: 'timer'
    })
  ],
  providers: [provideHttpClient(withInterceptors([jwtInterceptor, loadingInterceptor]))],
  bootstrap: [AppComponent]
})
export class AppModule {
}
