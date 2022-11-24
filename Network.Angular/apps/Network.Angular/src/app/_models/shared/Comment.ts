import {User} from "../users/User";

export class Comment {

  constructor(
    public id: number | undefined,
    public dataPublication: Date,
    public text: string | undefined,
    public postId: number | undefined,
    public userid: number | undefined,
    public user: User | undefined
  ) {}
}
