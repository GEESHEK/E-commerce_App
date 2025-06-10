import { Directive, effect, inject, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { AccountService } from '../services/account.service';

@Directive({
  selector: '[appHasRole]' //*appHasRole
})
export class HasRoleDirective {
  @Input() appHasRole: string[] = [];
  private accountService = inject(AccountService);
  private viewContainerRef = inject(ViewContainerRef);
  private templateRef = inject(TemplateRef);

  constructor() {
    effect(() => {
      const roles = this.accountService.roles();
      const hasRole = roles?.some(r => this.appHasRole.includes(r));
      this.viewContainerRef.clear();
      if (hasRole) {
        this.viewContainerRef.createEmbeddedView(this.templateRef);
      }
    });
  }
}
