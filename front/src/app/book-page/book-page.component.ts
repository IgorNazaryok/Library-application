import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Book } from '../shared/interface';
import { BookService } from '../shared/book.service';

@Component({
  selector: 'app-book-page',
  templateUrl: './book-page.component.html',
  styleUrls: ['./book-page.component.scss']
})
export class BookPageComponent implements OnInit {

  book$: Observable<Book>

  constructor(
    private bookService:BookService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.book$=this.route.params.pipe(
      switchMap((params: Params) => {
        return this.bookService.GetBookById(params['id'])
      }))
  }

}
