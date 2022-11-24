import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Comment} from "../_models/shared/Comment";

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  baseUrl = environment.apiUrl + 'comments/';

  constructor(private http: HttpClient) { }

  addComment(comment: Comment| undefined):Observable<Comment>{
    return this.http.post<Comment>(this.baseUrl, comment);
  }
}
