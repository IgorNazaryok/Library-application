import {NgModule} from '@angular/core'
import {HttpClientModule} from '@angular/common/http'
import { ListAuthorPipe } from './listAutor.pipe'



@NgModule({
    declarations:[
        ListAuthorPipe
    ],
    imports: [HttpClientModule],
    exports: [
        HttpClientModule,
        ListAuthorPipe
    ],
    providers: [ ]
})
export class ShareModule {

}