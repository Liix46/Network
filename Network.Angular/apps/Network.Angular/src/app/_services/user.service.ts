import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {User} from "../_models/users/User";
import {Observable} from "rxjs";
import {UserTitle} from "../_models/users/UserTitle";
import {Image} from "../_models/shared/Image";
import {UserSearchDto} from "../_models/users/UserSearchDto";
import {serializeJson} from "nx/src/utils/json";
import {SearchDto} from "../_models/shared/SearchDto";
import {AddFollowDto} from "../_models/shared/AddFollowDto";
import {FollowingDto} from "../_models/following/FollowingDto";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.apiUrl + 'users/';
  username : string | null = localStorage.getItem('username') ;

  constructor(private http: HttpClient) { }

  getUserById(userId: number | undefined) : Observable<User>{
    return  this.http.get<User>(this.baseUrl + 'userId/' + userId);
  }

  getUser(username:string|undefined = undefined): Observable<User>{
    if (username){
      return  this.http.get<User>(this.baseUrl + username);
    }
    else {
      return  this.http.get<User>(this.baseUrl + this.username);
    }
  }

  getCountPostsUser(username:string|undefined = undefined): Observable<number>{
    const url = this.baseUrl + 'count-posts/';
    if (username){
      return this.http.get<number>( url + username );
    }
    else {
      return this.http.get<number>( url + this.username );
    }

  }

  getCountFollowers(username:string|undefined = undefined) : Observable<number>{
    const url = this.baseUrl + 'count-followers/';
    if (username){
      return this.http.get<number>(url + username);
    }
    else {
      return this.http.get<number>(url + this.username);
    }

  }

  getCountFollowings(username:string|undefined = undefined) : Observable<number>{
    const url = this.baseUrl + 'count-followings/';
    if (username){
      return this.http.get<number>(url + username);
    }
    else {
      return this.http.get<number>(url + this.username);
    }

  }

  deleteAvatarImage(): Observable<boolean>{
      // @ts-ignore
    return this.http.delete<boolean>(`${this.baseUrl}avatar/${this.username}`, this.username);
  }

  getUserImages(username:string|undefined = undefined): Observable<Array<Image>>{
    const url = this.baseUrl + 'images/';
    if (username){
      return this.http.get<Array<Image>>(url + username);
    }
    else {
      return this.http.get<Array<Image>>(url + this.username);
    }

  }

  postSearchUsers(search: SearchDto): Observable<Array<UserSearchDto>>{
    const url = this.baseUrl + 'search-users';
    //const options = new HttpHeaders('content-type: application/json; charset=utf-8');

    return this.http.post<Array<UserSearchDto>>(url, search);
  }

  postFollow(addFollowDto : AddFollowDto) : Observable<boolean>{
    const url = this.baseUrl + 'add-follow';
    return this.http.post<boolean>(url, addFollowDto);
  }

  getFollowingPostsByUsername() : Observable<Array<FollowingDto>>{
    const url = this.baseUrl + 'following/'+ this.username;

    return this.http.get<Array<FollowingDto>>(url);
  }
}
