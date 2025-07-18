import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AccountService } from '../services/account.service';
import { ToastrService } from 'ngx-toastr';

export const adminGuard: CanActivateFn = (route, state) => {
  const  accountService = inject(AccountService);
  const toastr = inject(ToastrService);

  if (accountService.roles().includes('Admin')) {
    return true
  } else {
    toastr.error('You cannot enter this area');
    return false;
  }
};
