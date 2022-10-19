import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
constructor(private accountService:AccountService, private router:Router)
{

}

  canActivate(): Observable<boolean>  {
    return this.accountService.currentUser$.pipe(
      map(user=> {
        if(!user)
            this.router.navigateByUrl('/login');


        if(user.roles.includes('Admin'))
            return true;
      })
    );
  }

}
