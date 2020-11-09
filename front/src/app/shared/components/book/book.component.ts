import { Component, Input, OnInit } from '@angular/core';
import { BookService } from '../../book.service';
import { Book, BookReader } from '../../interface';
import { AuthService } from '../../service/auth.service';
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  @Input() book:Book
  @Input() isAutentificated:boolean
  
  constructor(
    private bookService:BookService,
    private authService:AuthService
  ) { }

  ngOnInit(): void {
    
  }

  TakeBook(bookId:string){
    const bookReader:BookReader={
      bookId: bookId,
      userId: +this.authService.id
    }
    this.bookService.TakeBook(bookReader).subscribe(()=>{
    this.book.issued++
    })
  }

  isAvailableBook(book:Book){    
    return +book.issued < +book.amount
  }

  
  ReturnBook(bookId:string){    
    this.bookService.ReturnBook(bookId.toString(), this.authService.id).subscribe(()=>{
      this.book.issued--
    })    
  }

}
