import {Pipe, PipeTransform} from '@angular/core';
import { Reader } from 'src/app/shared/interface';

@Pipe({
  name: 'ListReders'
})
export class ListRedersPipe implements PipeTransform {
  transform(reader: Reader[]): string {    
    return reader.map(x=>x.loggin).join(', ')
  }
}
