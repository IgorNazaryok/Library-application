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
    issued?:number
    authors:Array<Author>
    readers?:Array<Reader>
}

export interface Author {
    id?:string
    fullName:string
}

export interface Reader {
    id?:string
    loggin:string
}

export interface BookReader {
    id?:string
    bookId:string
    userId:number
}

export interface errorMessage {
       Name: string
       Amount: string
       Authors?: string
}

export interface authErrorMessage {
    Email?: string
    Password?: string
    ErrorMessage?:string
}

