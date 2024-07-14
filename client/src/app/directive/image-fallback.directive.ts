import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[app-Image-fallback]',
})
export class ImageFallbackDirective {
  constructor(private el: ElementRef) {}

  @HostListener('error')
  onError() {
    this.el.nativeElement.src = './assets/NoWatch.png';
  }
}
