import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Book } from 'src/app/shared/interface';
import { BookService } from 'src/app/shared/book.service';


@Component({
  selector: 'app-edit-page',
  templateUrl: './edit-page.component.html',
  styleUrls: ['./edit-page.component.scss']
})
export class EditPageComponent implements OnInit, OnDestroy {

  form: FormGroup
  book: Book = {
    name:'',
    amount:0,
    issued:0,
    authors:[],
    readers:[]
  }
  uSub:Subscription

  constructor(
    private route: ActivatedRoute,
    public bookService: BookService,

  ) { }

  ngOnDestroy(): void {
    if (this.uSub){
      this.uSub.unsubscribe()
    }
  }

  ngOnInit() {

    this.form=new FormGroup({
      amount: new FormControl(null)   
  })
    this.route.params.pipe(
      switchMap((params: Params) => {
        return this.bookService.GetBookById(params['id'])
      })
    ).subscribe((book: Book) => {
      this.book=book
      this.form = new FormGroup({  
        amount: new FormControl(book.amount)
      })
    })    
  }

  submit() {
    this.uSub=this.bookService.UpdateBook({
      ...this.book,
      amount: this.form.value.amount
    }).subscribe()
  }

}
