export interface User {
  name: string;
  username: string;
  bio: string;
  urlMainImage:string|null;
  gender: Gender;
}

export interface CountPostsByUser {
  count : number;
}

export enum Gender{
  Male, Female
}

