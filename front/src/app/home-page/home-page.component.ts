import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../shared/interface';
import { BookService } from '../shared/book.service';
import { AuthService } from '../admin/shared/service/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
  
  books$: Observable<Book[]>
  isAutentificated:boolean

  constructor(
    private bookService:BookService,
    private authService:AuthService) { }

  ngOnInit(): void {
    this.books$=this.bookService.GetBooks()
    this.isAutentificated=this.authService.isAutentificated()
  }

}
