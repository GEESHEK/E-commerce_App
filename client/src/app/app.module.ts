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
import { ImagefallbackdirectiveDirective } from './directive/imagefallbackdirective.directive';

@NgModule({
  declarations: [AppComponent, NavComponent, HomeComponent, WatchCardComponent, WatchPageComponent, ImagefallbackdirectiveDirective],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgOptimizedImage,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
