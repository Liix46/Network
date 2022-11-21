import { Component, OnInit } from '@angular/core';
import {UserService} from "../../_services/user.service";
import { User} from "../../_models/users/User";
import {MatDialog} from "@angular/material/dialog";
import {
  ChangeOrDeletePhotoDialogComponent
} from "../dialogs/change-or-delete-photo-dialog/change-or-delete-photo-dialog.component";
import {environment} from "../../../environments/environment";
import {PostService} from "../../_services/post.service";
import {GetPostDto} from "../../_models/post/GetPostDto";
import {Image} from "../../_models/shared/Image";
import {PostInfoDialogComponent} from "../dialogs/post-info-dialog/post-info-dialog.component";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserService, PostService]
})
export class ProfileComponent implements OnInit {
  user : User | undefined;
  countPosts: number | undefined;
  countFollowers: number | undefined;
  countFollowings: number | undefined;
  images: Array<Image> | undefined;
  constructor(private userService: UserService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.userService.getUser().subscribe(response => {
      this.user = response;

      this.user.urlMainImage = environment.apiFilesUrl + response.urlMainImage;

      this.userService.getCountPostsUser().subscribe(response => {
        this.countPosts = response;
        console.log(response);
        console.log(this.countPosts);
      })

      this.userService.getUserImages().subscribe(response => {
        for (const image of response) {
          image.url = environment.apiFilesUrl + image.url;
        }
        this.images = response;
      })

      this.userService.getCountFollowers().subscribe(response => {
        this.countFollowers = response;
      })
      this.userService.getCountFollowings().subscribe(response => {
        this.countFollowings = response;
      })
    })
  }

  openDialog(){
    const dialogRef = this.dialog.open(ChangeOrDeletePhotoDialogComponent, {disableClose:true});
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    })
  }
  showPostInfo(){
    const dialogRef = this.dialog.open(PostInfoDialogComponent);

  }
}
