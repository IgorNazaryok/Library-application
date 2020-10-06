import {Injectable} from '@angular/core'
import {HttpClient, HttpErrorResponse} from '@angular/common/http'
import { AuthRequest, AuthRespons } from '../../../shared/interface'
import { Observable, Subject, throwError } from 'rxjs'
import { catchError, tap } from 'rxjs/operators'

@Injectable({providedIn: 'root'})
export class AuthService{
    public error$: Subject<string>=new Subject<string>()

    constructor(private httpClient: HttpClient){}

    get token(): string {
    return localStorage.getItem('token')
    }

    Login(model:AuthRequest):Observable<any>
    {
       return this.httpClient.post(`https://localhost:5001/users/authenticate`,model)
        .pipe(
           tap(this.setToken),
           catchError(this.handleError.bind(this)) 
        )
    }
    logout()
    {
        this.setToken(null)
    }
    isAutentificated(): boolean {
        return !!this.token
    }

    private handleError (err: HttpErrorResponse) {
        this.error$.next(err.error.errorText)
         return throwError(err)
        
    }

    private setToken(response:AuthRespons|null){  
        console.log(response);
              
      if(response){
        localStorage.setItem('id', response.id.toString())
        localStorage.setItem('role', response.role)
        localStorage.setItem('token', response.token)
       }
       else localStorage.clear()
        
    }
}