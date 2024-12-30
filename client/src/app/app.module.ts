import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

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
import { CartComponent } from './cart/cart.component';
import { OrderConfirmationPageComponent } from './order/order-confirmation-page/order-confirmation-page.component';
import { OrderPageComponent } from './order/order-page/order-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './forms/text-input/text-input.component';
import { OrderWatchListComponent } from './order/order-watch-list/order-watch-list.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { RegisterComponent } from './register/register.component';

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
    SignInComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgOptimizedImage,
    BsDropdownModule.forRoot(),
    AccordionModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
