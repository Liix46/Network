import {Image} from "../shared/Image";
import {Like} from "../shared/Like";
import {Comment} from "../shared/Comment"
import {User} from "../users/User";

export interface GetPostDto {
  id : number,
  datePublication: Date,
  description : string | undefined,
  userId : number,
  image : Image | null | undefined,
  likes : Array<Like> | undefined,
  comments : Array<Comment> | undefined
  user: User | undefined
}
