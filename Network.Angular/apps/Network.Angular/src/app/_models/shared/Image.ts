// export interface Image{
//   name: string
//   url: string
//   formatType: string
//   userId : number
// }

export class Image{
  constructor(public name: string, public url: string, public formatType: string | undefined, public postId: number | undefined) {


  }

}
