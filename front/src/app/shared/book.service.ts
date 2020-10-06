import {Injectable} from '@angular/core'
import {HttpClient, HttpHeaders, HttpErrorResponse} from '@angular/common/http'
import { Book, BookReader, errorMessage } from './interface'
import { Observable, throwError } from 'rxjs'
import { tap, catchError  } from 'rxjs/operators'

@Injectable({providedIn: 'root'})
export class BookService {

   public message:errorMessage = {
    Name: [],
    Amount: [],
    Authors: []
   }

   public takeReturnBookError: string

   Url:string=`https://localhost:5001/books`
   UrlBookReaders:string=`https://localhost:5001/bookReaders`
   
    
    constructor(private httpClient: HttpClient){}   
     

    GetBooks():Observable<Book[]>
    {       
        return this.httpClient.get<Book[]>(this.Url)
        .pipe(
           tap(this.getBooks)          
        )
    }
    GetBookById(id:string):Observable<Book>
    {       
        return this.httpClient.get<Book>(`${this.Url}/${id}`)
        .pipe(
           tap(this.getBook)          
        )
    }
    CreateBook(book:Book):Observable<any>
    {
        return this.httpClient.post(this.Url,book)
        .pipe(            
          catchError(this.CreateBookError.bind(this)) 
        )
    }

    RemoveBook(id:string):Observable<any>
    {
       return this.httpClient.delete<void>(`${this.Url}/${id}`)
    }

    UpdateBook(book:Book):Observable<any>
    {
        return this.httpClient.put(this.Url,book)
        .pipe(            
          catchError(this.CreateBookError.bind(this)) 
        )
    }

    TakeBook(bookReader:BookReader):Observable<any>
    {       
        return this.httpClient.post(this.UrlBookReaders,bookReader)
        .pipe(            
          catchError(this.TakeReturnBookError.bind(this)) 
        )
    }

    ReturnBook(bookId:string,userId:string):Observable<any>
    {        
        return this.httpClient.delete<void>(`${this.UrlBookReaders}/${bookId}/${userId}`)
        .pipe(            
          catchError(this.TakeReturnBookError.bind(this)) 
        )
    }


    private CreateBookError (err: HttpErrorResponse) {
        this.message= err.error.errors        
         return throwError(err)        
    }

    private TakeReturnBookError (err: HttpErrorResponse) {
        this.takeReturnBookError= err.error.errors
        console.log('Error!!!! ',err.error.errors);        
         return throwError(err)        
    }

    private getBooks(res:Book[]):Book[]{
        return res
    }

    private getBook(res:Book):Book{
        return res        
    }
}