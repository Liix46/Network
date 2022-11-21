import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {CreatePostDto} from "../_models/post/CreatePostDto";
import {Observable} from "rxjs";
import {Image} from "../_models/shared/Image";
import {GetPostDto} from "../_models/post/GetPostDto";

@Injectable({
  providedIn: 'root'
})
export class PostService {

  baseUrl = environment.apiUrl + 'posts/';
  username : string | null = localStorage.getItem('username') ;

  constructor(private http: HttpClient) {  }

  createPost( createPostDto: CreatePostDto):Observable<CreatePostDto>{
    // @ts-ignore
    return this.http.post<CreatePostDto>(this.baseUrl, createPostDto);
  }

  getAllPosts(): Observable<GetPostDto[]>{
    return this.http.get<GetPostDto[]>(this.baseUrl + this.username);
  }

}
