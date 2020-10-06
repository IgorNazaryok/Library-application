import { Component, OnDestroy, OnInit } from '@angular/core';
import {BookService} from '../../shared/book.service'
import { Book} from '../../shared/interface'
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-dashboard-page',
  templateUrl: './dashboard-page.component.html',
  styleUrls: ['./dashboard-page.component.scss']
})
export class DashboardPageComponent implements OnInit, OnDestroy {

  books:Book[] = []
  pSub:Subscription
  dSub:Subscription
  searchStr=''
  constructor(private bookService:BookService) { }

  ngOnInit(): void {
   this.pSub=this.bookService.GetBooks().subscribe(data=>{
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

  remove(id:string){
    this.dSub=this.bookService.RemoveBook(id).subscribe(()=>{
      this.books=this.books.filter(book=>book.id!==id)
    })
  }
}
