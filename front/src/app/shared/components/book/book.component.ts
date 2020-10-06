import { Component, Input, OnInit } from '@angular/core';
import { Book } from '../../interface';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  @Input() book:Book
  @Input() isAutentificated:boolean
  
  constructor() { }

  ngOnInit(): void {        
  }

}
