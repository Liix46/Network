import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  baseUrl = environment.apiUrl + 'posts/uploads/';
  username : string | null = localStorage.getItem('username') ;

  constructor(private http:HttpClient) { }

  upload(file: File, fileName: string): Observable<any> {

    const formData = new FormData();
    formData.append("file", file, fileName);
    return this.http.post(this.baseUrl + this.username, formData);
  }

  uploadAvatar(file: File, fileName: string): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, fileName);
    return this.http.post(this.baseUrl + 'avatar/' + this.username , formData);
  }


}
