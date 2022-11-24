import {User} from "../users/User";
import {GetPostDto} from "../post/GetPostDto";

export interface FollowingDto {
  userId : number;
  user: User,
  followingId : number
}

//public int UserId { get; set; }
//     public User User { get; set; }
//     public int FollowingId { get; set; }
