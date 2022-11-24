import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {PostService} from "../../../_services/post.service";
import {GetPostDto} from "../../../_models/post/GetPostDto";
import {Comment} from "../../../_models/shared/Comment";
import {environment} from "../../../../environments/environment";
import {UserService} from "../../../_services/user.service";
import {User} from "../../../_models/users/User";
import {CommentService} from "../../../_services/comment.service";

@Component({
  selector: 'app-post-info-dialog',
  templateUrl: './post-info-dialog.component.html',
  styleUrls: ['./post-info-dialog.component.css'],
  providers: [PostService, UserService, CommentService]
})
export class PostInfoDialogComponent implements OnInit {
  post : GetPostDto | undefined;
  user : User | undefined;
  textArea : string = '';
  private textAreaElement:   HTMLElement |null = null;

  constructor(
    public dialogRef: MatDialogRef<PostInfoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number|undefined,
    private postService: PostService,
    private userService: UserService,
    private commentService: CommentService
  ) {}


  ngOnInit(): void {
    this.textAreaElement = document.getElementById('textArea');
    if (this.textAreaElement){
      this.textAreaElement.style.height = "20px";
    }
    this.getPost();
  }

  private getPost(){
    this.postService.getPost(this.data).subscribe(response => {
      this.post = response;
      // @ts-ignore
      for (const comment of this.post.comments) {
        // @ts-ignore
        comment.user.urlMainImage = environment.apiFilesUrl + comment.user.urlMainImage;
      }
      // @ts-ignore
      this.post.image.url = environment.apiFilesUrl + response.image?.url;
      //console.log(response);

      this.userService.getUserById(this.post?.userId).subscribe(response => {
        this.user = response;
        console.log(this.user);
        console.log(response);
        this.user.urlMainImage = environment.apiFilesUrl + response.urlMainImage;

      })
    })

  }
  private commentsUpdate(){
    this.postService.getPost(this.data).subscribe(response => {
      // @ts-ignore
      this.post.comments = response.comments;
      // @ts-ignore
      for (const comment of this.post.comments) {
        // @ts-ignore
        comment.user.urlMainImage = environment.apiFilesUrl + comment.user.urlMainImage;
      }
    })
  }
  sendComment(){
    if (this.textArea?.trim().length == 0){
      return;
    }
    let user: User | undefined;
    this.userService.getUser().subscribe(response => {
      user = response;

      let comment : Comment = new Comment(undefined, new Date(Date.now()),this.textArea, this.post?.id, user?.id, undefined);
      this.commentService.addComment(comment).subscribe(response => {
        console.log(response);

        this.commentsUpdate();
      });

    });



  }

}
