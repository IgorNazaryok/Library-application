import {Injectable} from '@angular/core'
import {HttpClient, HttpHeaders, HttpErrorResponse} from '@angular/common/http'
import { Book, BookReader, errorMessage } from './interface'
import { Observable, throwError } from 'rxjs'
import { tap, catchError  } from 'rxjs/operators'
import {AlertService} from './alert.service'

@Injectable({providedIn: 'root'})
export class BookService {

   public message:errorMessage = {
    Name: '',
    Amount: '',
    Authors: ''
   }

   public updateBookError: string
   public bookReaderError=''
   Url:string=`https://localhost:5001/books`
   UrlBookReaders:string=`https://localhost:5001/bookReaders`
   
    
    constructor(
        private httpClient: HttpClient,
        private alertService: AlertService){}   
     

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

    GetBooksByReaderId(ReaderId:string):Observable<Book[]>
    {       
        return this.httpClient.get<Book[]>(`${this.Url}/mybook/${ReaderId}`)
        .pipe(
           tap(()=>{
            this.getBooks
            this.bookReaderError=''}),
           catchError(this.CreateBookReaderMessage.bind(this))          
        )
    }

    CreateBook(book:Book):Observable<any>
    {
        return this.httpClient.post(this.Url,book)
        .pipe(
            tap(()=>this.alertService.success('Book created!')),            
          catchError(this.CreateBookError.bind(this)) 
        )
    }

    RemoveBook(id:string):Observable<any>
    {
       return this.httpClient.delete<void>(`${this.Url}/${id}`)
       .pipe(
        tap(()=>this.alertService.success('Book deleted!')))
    }

    UpdateBook(book:Book):Observable<any>
    {
        this.updateBookError=''
        if(book.amount<book.issued)
        {
            this.updateBookError='The total amount cannot be less than the issued!'
            return new Observable
        }
        else if(book.amount==book.issued)
        {
            this.alertService.success('Total amount has been updated!')
            return new Observable
        }
        else 
        {
            return this.httpClient.put(this.Url,book)
            .pipe(    
                tap(()=>this.alertService.success('Total amount has been updated!')),        
              catchError(this.CreateBookError.bind(this)) 
            )
        } 
    }

    TakeBook(bookReader:BookReader):Observable<any>
    {       
        return this.httpClient.post(this.UrlBookReaders,bookReader)
        .pipe(
            tap(()=>this.alertService.success('Book taken!')),            
            catchError((err)=>{
                this.alertService.danger(err.error.message)
                return throwError(err)  
                }) 
        )
    }

    ReturnBook(bookId:string,userId:string):Observable<any>
    {        
        return this.httpClient.delete<void>(`${this.UrlBookReaders}/${bookId}/${userId}`)
        .pipe(     
            tap(()=>this.alertService.success('Book returned!')),                     
            catchError((err)=>{
                this.alertService.danger(err.error.message)
                return throwError(err)  
              }) 
        )
    }


    private CreateBookError (err: HttpErrorResponse) {        
        this.message.Name=''
        this.message.Amount=''
            if(err.error.errors.hasOwnProperty('Name'))   
                this.message.Name= err.error.errors.Name[0] 
            if(err.error.errors.hasOwnProperty('Amount'))
                this.message.Amount= err.error.errors.Amount[0]
        

         return throwError(err)        
    }

    private CreateBookReaderMessage (err: HttpErrorResponse) {             
            if(err.error.hasOwnProperty('message'))   
            this.bookReaderError= err.error.message                       
         return throwError(err)        
    }

    private getBooks(res:Book[]):Book[]{     
        return res.map((book)=>
        {
            book.issued = book.readers.length                        
            return book       
        })
    }

    private getBook(book:Book):Book{
        book.issued = book.readers.length
        return book        
    }
}