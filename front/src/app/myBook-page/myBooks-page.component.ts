import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { Book } from '../shared/interface';
import { BookService } from '../shared/book.service';
import { AuthService } from '../shared/service/auth.service';

@Component({
  selector: 'app-myBooks-page',
  templateUrl: './myBooks-page.component.html',
  styleUrls: ['./myBooks-page.component.scss']
})
export class MyBooksPageComponent implements OnInit, OnDestroy {
  
  books:Book[] = []
  pSub:Subscription
  dSub:Subscription

  constructor(
    public bookService:BookService,
    public authService:AuthService) { }

  ngOnInit(): void {    
    this.pSub=this.bookService.GetBooksByReaderId(this.authService.id).subscribe(data=>{
      this.books=data      
    })
  }

  ngOnDestroy(): void{
    if (this.pSub){
      this.pSub.unsubscribe()
    }
    if (this.dSub){
      this.dSub.unsubscribe()
    }
  }
}
