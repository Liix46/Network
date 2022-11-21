import { Component, OnInit } from '@angular/core';
import {UserService} from "../../_services/user.service";
import {User} from "../../_models/users/User";
import {Image} from "../../_models/shared/Image";
import {ActivatedRoute} from "@angular/router";
import {environment} from "../../../environments/environment";
import {AddFollowDto} from "../../_models/shared/AddFollowDto";

@Component({
  selector: 'app-guest-profile',
  templateUrl: './guest-profile.component.html',
  styleUrls: ['./guest-profile.component.css'],
  providers: [UserService]
})
export class GuestProfileComponent implements OnInit {

  user : User | undefined;
  countPosts: number | undefined;
  countFollowers: number | undefined;
  countFollowings: number | undefined;
  images: Array<Image> | undefined;
  addFollowDto : AddFollowDto | undefined;

  constructor(private userService : UserService, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    let username : string = this.route.snapshot.params['username'];
    this.userService.getUser(username).subscribe(response => {
      this.user = response;

      this.user.urlMainImage = environment.apiFilesUrl + response.urlMainImage;

      this.userService.getCountPostsUser(username).subscribe(response => {
        this.countPosts = response;
        console.log(response);
        console.log(this.countPosts);
      })

      this.userService.getUserImages(username).subscribe(response => {
        for (const image of response) {
          image.url = environment.apiFilesUrl + image.url;
        }
        this.images = response;
      })

      this.userService.getCountFollowers(username).subscribe(response => {
        this.countFollowers = response;
      })
      this.userService.getCountFollowings(username).subscribe(response => {
        this.countFollowings = response;
      })
    })
  }

  addFollow(){
    this.addFollowDto = new AddFollowDto();

    // @ts-ignore
    this.addFollowDto.usernameFrom = localStorage.getItem('username');
    this.addFollowDto.usernameTo = this.user?.username || undefined;
    console.log(this.addFollowDto);
    this.userService.postFollow(this.addFollowDto).subscribe(response => {
      console.log(response);
    });
  }
}
