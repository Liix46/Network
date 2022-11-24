import { Component, OnInit, AfterViewInit } from '@angular/core';
import {AuthGuardService} from "../../_quards/auth-guard.service";
import {UserService} from "../../_services/user.service";
import {FollowingDto} from "../../_models/following/FollowingDto";
import {User} from "../../_models/users/User";
import {environment} from "../../../environments/environment";
import {PostService} from "../../_services/post.service";
import {GetPostDto} from "../../_models/post/GetPostDto";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [AuthGuardService, UserService, PostService]
})
export class HomeComponent implements OnInit, AfterViewInit {

  public textArea : string = '';
  public user : User | undefined;
  followings : Array<FollowingDto> | undefined;
  posts: Array<GetPostDto> | undefined;
  currentHeight: string = '0';
  constructor(private userService: UserService, private postService: PostService) { }

  lastKnownScrollPosition = 0;
  ticking = false;
  homeSection : HTMLElement | undefined;
  style: any;
  doSomething(scrollPos : any) {

    const height :string = this.style['bottom'].replace('-', '').replace('px', '');
    //console.log(height);
    if (height!=undefined && height!="" && height < scrollPos && this.currentHeight != height){
      //alert(height);
      this.currentHeight = height;
      // @ts-ignore
      this.postService.getPostsByFollowing(localStorage.getItem('username'), this.posts?.length).subscribe(response =>{
        //console.log(response);

        if (response.length > 0){
          for (const post of response) {
            // @ts-ignore
            post.image.url = environment.apiFilesUrl + post.image.url;
            // @ts-ignore
            post.user.urlMainImage = environment.apiFilesUrl + post.user.urlMainImage;
          }
          // @ts-ignore
          //this.posts?.push(response as GetPostDto[]);
          for (const post of response) {
            this.posts?.push(post);
          }
          //console.log(this.posts);
        }
      })
    }

  }
  ngOnInit(): void {

    // @ts-ignore


    document.addEventListener('scroll', (e) => {
      this.lastKnownScrollPosition = window.scrollY;

      if (!this.ticking) {
        window.requestAnimationFrame(() => {
          this.doSomething(this.lastKnownScrollPosition);
          this.ticking = false;
        });

        this.ticking = true;
      }
    });

    // @ts-ignore
    this.postService.getPostsByFollowing(localStorage.getItem('username'), 0).subscribe(response => {


      for (const post of response) {
        // @ts-ignore
        post.image.url = environment.apiFilesUrl + post.image.url;
        // @ts-ignore
        post.user.urlMainImage = environment.apiFilesUrl + post.user.urlMainImage;
      }
      this.posts = response;
      console.log(this.posts);
    });

    this.userService.getUser().subscribe(response => {
      this.user = response;
      this.user.urlMainImage = environment.apiFilesUrl + response.urlMainImage;
    })
  }

  sendComment(){

  }

  ngAfterViewInit(): void {


    // @ts-ignore
    //console.log(homeSection.style.height);
    // @ts-ignore
    this.homeSection = document.getElementById('homeSection');
    // @ts-ignore
    this.style = getComputedStyle(this.homeSection);

    console.log(this.style);

  }

}
