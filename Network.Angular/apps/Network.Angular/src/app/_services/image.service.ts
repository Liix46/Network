import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Image} from "../_models/shared/Image";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private baseUrl = environment.apiUrl + 'posts/images';
  constructor(private http: HttpClient ) { }

  saveImage(image: Image):Observable<Image>{
    return this.http.post<Image>(this.baseUrl, image);
  }
}
