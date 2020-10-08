import {Pipe, PipeTransform} from '@angular/core';
import { Author } from '../../shared/interface';

@Pipe({
  name: 'Author'
})
export class AuthorPipe implements PipeTransform {
  transform(authors: Author[]): string {
    return authors.map(x=>x.fullName).join(', ')
  }
}
