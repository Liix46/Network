import { Injectable } from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable()
export class AuthInterceptorService implements HttpInterceptor{

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const accessToken = localStorage.getItem('accessToken');
    console.log(`accessToken ${accessToken}`);
    if (accessToken){
      request = request.clone({
        setHeaders: {Authorization: `Bearer ${accessToken}`}
      });
    }
    return next.handle(request);
  }
}
