import { Injectable }   from '@angular/core';
import { environment }  from "../../environments/environment";
import { HttpClient }   from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { UserForLogin } from "../_models/account/UserForLogin";
import { BearerToken }  from "../_models/account/BearerToken";
import {UserForRegistration} from "../_models/account/UserForRegistration";
import {UserTitle} from "../_models/users/UserTitle";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl + 'account/';

  constructor(private http: HttpClient) { }

  isLoggedIn():boolean{
    const token = localStorage.getItem('accessToken');
    return !!token;
  }

  login(userForLoginDto: UserForLogin): Observable<BearerToken>{
    return this.http.post<BearerToken>(this.baseUrl + 'login/', userForLoginDto);
  }

  registration(userForRegistrationDto: UserForRegistration): Observable<BearerToken>{
    return  this.http.post<BearerToken>(this.baseUrl + 'registration/', userForRegistrationDto);
  }

  getUser():Observable<UserTitle>{
    const url = this.baseUrl+ 'current-user/';
    return  this.http.get<UserTitle>(url);
  }

}
