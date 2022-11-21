import {Image} from "../shared/Image";

// export interface CreatePostDto {
//
//   UserId : number,
//   Description: string,
//   DatePublication: Date,
//   Images: Array<Image>
// }

// export class CreatePostDto {
//
//   constructor(
//     public userId: number | undefined,
//     public description: string,
//     public datePublication: Date,
//     public file: File) {
//   }
// }
export class CreatePostDto {
  public id: number | undefined
  public userId: number | undefined;
  public description: string | undefined;
  public datePublication: Date | undefined;
  //public image: Image | undefined;
  constructor() {
  }
}
