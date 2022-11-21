import {Image} from "../shared/Image";
import {Like} from "../shared/Like";

export interface GetPostDto {
//   public int Id { get; set; }
// public DateTime DatePublication { get; set; }
//
// public List<Comment>? Comments { get; set; }
// public List<Image>? Images { get; set; }
// public List<Like>? Likes { get; set; }
//
// public int UserId { get; set; }
  id : number,
  datePublication: Date,
  userId : number,
  images : Array<Image> | undefined,
  likes : Array<Like> | undefined,
  comments : Array<Comment> | undefined
}
