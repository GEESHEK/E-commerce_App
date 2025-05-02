import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { BusyService } from '../services/busy.service';
import { delay, finalize, identity } from 'rxjs';
import { environment } from 'src/environments/environment';

export const loadingInterceptor : HttpInterceptorFn = (req, next) => {
  const busyService = inject(BusyService);

  busyService.busy();

  return next(req).pipe(
    //can't return null so return identity which doesn't do anything
    (environment.production ? identity : delay(500)),
    finalize(() => {
      busyService.idle();
    })
  );
}


