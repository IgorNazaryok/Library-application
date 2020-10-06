import {Pipe, PipeTransform} from '@angular/core';
import { Author } from './interface';

@Pipe({
  name: 'ListAuthor'
})
export class ListAuthorPipe implements PipeTransform {
  transform(authors: Author[]): string {
    return authors.map(x=>x.fullName).join(', ')
  }

/*   transform(author: string): string {
    return author.concat(', ')
  } */
}
