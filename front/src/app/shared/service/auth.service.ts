import {Injectable} from '@angular/core'
import {HttpClient, HttpErrorResponse} from '@angular/common/http'
import { AuthRequest, AuthRespons,authErrorMessage } from '../interface'
import { Observable, Subject, throwError } from 'rxjs'
import { catchError, tap } from 'rxjs/operators'


@Injectable({providedIn: 'root'})
export class AuthService{
    public authErrorMessage:authErrorMessage={
        Email:'',
        Password:'',
        ErrorMessage:'',
    }

    constructor(private httpClient: HttpClient){}

    get token(): string {
    return localStorage.getItem('token')
    }

    get role(): string {
        return localStorage.getItem('role')
    }

    Login(model:AuthRequest):Observable<any>
    {
       return this.httpClient.post(`https://localhost:5001/users/authenticate`,model)
        .pipe(
           tap(this.setToken),
           catchError(this.CreateAuthError.bind(this)) 
        )
    }

    
    Registration(model:AuthRequest):Observable<any>
    {
       return this.httpClient.post(`https://localhost:5001/users`,model)
        .pipe(           
           catchError(this.CreateAuthError.bind(this)) 
        )
    }
    logout()
    {
        this.setToken(null)
    }
    isAutentificated(): boolean {
        return !!this.token
    }

    isRoleAdmin(): boolean {
        return this.role==='admin'
    }

    private CreateAuthError (err: HttpErrorResponse) { 
        this.authErrorMessage={}
        if(err.error.message){
            this.authErrorMessage.ErrorMessage = err.error.message
        }
        else {
            if(err.error.errors.hasOwnProperty('Password'))   
                this.authErrorMessage.Password= err.error.errors.Password[0] 
            if(err.error.errors.hasOwnProperty('Email'))
                this.authErrorMessage.Email= err.error.errors.Email[0]
        }         
         return throwError(err)        
    }   

    
    ClearAuthError () { 
        this.authErrorMessage={}        
    }

    private setToken(response:AuthRespons|null){  
              
      if(response){
        localStorage.setItem('id', response.id.toString())
        localStorage.setItem('role', response.role)
        localStorage.setItem('token', response.token)
       }
       else localStorage.clear()
        
    }
}