import { Injectable }   from '@angular/core';
import { environment }  from "../../environments/environment";
import { HttpClient }   from "@angular/common/http";
import { Observable }   from "rxjs";
import { UserForLogin } from "../_models/account/UserForLogin";
import { BearerToken }  from "../_models/account/BearerToken";
import {UserForRegistration} from "../_models/account/UserForRegistration";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl + 'account/';

  constructor(private http: HttpClient) { }

  isLoggedIn():boolean{
    const token = localStorage.getItem('accessToken');
    return token ? true : false;
  }

  login(userForLoginDto: UserForLogin): Observable<BearerToken>{
    return this.http.post<BearerToken>(this.baseUrl + 'login/', userForLoginDto);
  }

  registration(userForRegistrationDto: UserForRegistration): Observable<BearerToken>{
    return  this.http.post<BearerToken>(this.baseUrl + 'registration/', userForRegistrationDto);
  }
}
