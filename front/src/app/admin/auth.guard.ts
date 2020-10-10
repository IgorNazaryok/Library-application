import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import {Injectable} from '@angular/core'
import { ActivatedRouteSnapshot, CanActivate, Router, RouteReuseStrategy, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../shared/service/auth.service';


@Injectable()
export class AuthGuard implements CanActivate{

constructor(
  private authService:AuthService,
  private router:Router
){}

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
      ): Observable<boolean> | Promise<boolean> | boolean {
              if (this.authService.isAutentificated() && this.authService.isRoleAdmin()) {
                return true
              }
              else {
                this.authService.logout()
                this.router.navigate(['/', 'login'])
              }
      }
    
}