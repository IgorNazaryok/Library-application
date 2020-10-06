export interface User {
    email: string
    password: string
    returnSecureToken:boolean
}

export interface AuthRequest {
    Email: string
    Password: string
}

export interface AuthRespons {
    id:number
    role:string
    token:string
}

export interface Book {
    id?:string
    name:string
    amount:number
    authors:Array<Author>
}

export interface Author {
    id?:string
    fullName:string
}

export interface BookReader {
    id?:string
    bookId:string
    userId:number
}

export interface errorMessage {
       Name: Array<string>
       Amount: Array<string>
       Authors?:  Array<string>
}
