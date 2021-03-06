import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {AuthService} from '../shared/service/auth.service'
import {AlertService} from './alert.service'
import {Router} from '@angular/router';
import {catchError, tap} from 'rxjs/operators';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(
    private auth: AuthService,
    private router: Router,
    private alertService: AlertService
  ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.auth.isAutentificated()) {
      req = req.clone({ headers: req.headers.set('Authorization', `Bearer ${this.auth.token}`) });
    }
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 401) {
           this.auth.logout()
	   this.alertService.warning('Your session has expired! Please re-enter the site.')
           this.router.navigate(['/', 'login'])
          }
          return throwError(error)
        })
      )
  } 
}
