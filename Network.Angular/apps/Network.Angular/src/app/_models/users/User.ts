import {GetPostDto} from "../post/GetPostDto";

export interface User {
  id: number;
  name: string;
  userName: string;
  bio: string;
  urlMainImage:string|null;
  gender: Gender;
  posts: Array<GetPostDto>| null
}

export enum Gender{
  Male, Female
}

