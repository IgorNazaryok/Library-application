import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Author, Book } from 'src/app/shared/interface';
import {BookService} from '../../shared/book.service';

@Component({
  selector: 'app-create-page',
  templateUrl: './create-page.component.html',
  styleUrls: ['./create-page.component.scss']
})
export class CreatePageComponent implements OnInit {

  form:FormGroup
  authorsBook:Array<Author>=[]
  authorNewBook:Author

  constructor(
    public bookService:BookService,
  ) { }

  ngOnInit(): void {
    this.form=new FormGroup({
      name: new FormControl(null),
      amount: new FormControl(null),
      authors: new FormControl(null)
  })
  }
  submit(){
    const book:Book={
      name: this.form.value.name,
      amount: +this.form.value.amount,
      authors: this.authorsBook
    }
    this.bookService.CreateBook(book)
    .subscribe(()=>{
      alert("Book added!")
      this.form.reset()
    })    
  }
  addAuthor(){
    if(this.form.value.authors)
    var newAuthor= this.form.value.authors.toString().trim()
    const authorBook:Author={
      fullName:newAuthor
    }
    this.authorsBook.push(authorBook) 
    this.form.value.authors = null
  }
}
