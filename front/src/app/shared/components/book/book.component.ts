import { Component, Input, OnInit } from '@angular/core';
import { BookService } from '../../book.service';
import { Book, BookReader } from '../../interface';
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  @Input() book:Book
  @Input() isAutentificated:boolean
  
  constructor(
    private bookService:BookService

  ) { }

  ngOnInit(): void {        
  }

  TakeBook(bookId:string){
    const bookReader:BookReader={
      bookId: bookId,
      userId: +localStorage.getItem('id')
    }
    this.bookService.TakeBook(bookReader).subscribe(()=>{ 
    console.log('Take', bookReader)})
  }
  ReturnBook(bookId:string){    
    this.bookService.ReturnBook(bookId.toString(), localStorage.getItem('id')).subscribe(()=>{
      console.log('Return', bookId, localStorage.getItem('id'));
    })
    
  }

}
