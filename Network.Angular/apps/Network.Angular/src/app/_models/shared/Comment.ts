export class Comment {
  constructor(public id: number,
              public datePublication: Date,
              public text: string,
              public postId: number) {}
}
