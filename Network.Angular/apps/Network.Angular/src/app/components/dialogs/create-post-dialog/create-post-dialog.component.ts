import {Component, OnInit} from '@angular/core';
import {PostService} from "../../../_services/post.service";
import {AccountService} from "../../../_services/account.service";
import {UserTitle} from "../../../_models/users/UserTitle";
import {CreatePostDto} from "../../../_models/post/CreatePostDto";
import {FileUploadService} from "../../../_services/file-upload.service";
import {Guid} from "guid-typescript";
import {Image} from "../../../_models/shared/Image";
import {ImageService} from "../../../_services/image.service";
import {environment} from "../../../../environments/environment";

@Component({
  selector: 'app-create-post-dialog',
  templateUrl: './create-post-dialog.component.html',
  styleUrls: ['./create-post-dialog.component.scss'],
  providers: [PostService, AccountService, FileUploadService, ImageService]
})
export class CreatePostDialogComponent implements OnInit {

  private dialogContainer:  HTMLElement |null= null;
  private mainContainer: HTMLElement |null = null;
  private cardContentContainer: HTMLElement |null = null;
  private imgContainer: HTMLElement |null = null;
  private buttonNext:   HTMLElement |null = null;
  private buttonPref:   HTMLElement |null = null;
  private input:   HTMLInputElement |null = null;

  private canSend : boolean = false;

  constructor(
    private postService: PostService,
    private accountService: AccountService,
    private fileUploadService : FileUploadService,
    private imageService : ImageService) {
  }
  public user: UserTitle | undefined;
  public createPostDto : CreatePostDto = new CreatePostDto();
  public file : File| undefined;
  public image: Image | undefined;

  ngOnInit(): void {
    this.initElements();
    this.ChangeStyleDisplayButton('none');
    this.SetStylesCardContent();
    //console.log(this.user);
  }

  private ChangeStyleDisplayButton(displayStyle: string){
    if (this.buttonNext){
      this.buttonNext.style.display = displayStyle;
    }
    if (this.buttonPref){
      this.buttonPref.style.display = displayStyle;
    }
  }

  private initElements(){
    this.mainContainer = document.getElementById('mainContainer');
    this.cardContentContainer = document.getElementById('cardContent');
    this.buttonNext = document.getElementById('buttonNext');
    this.buttonPref = document.getElementById('buttonPref');
    this.imgContainer = document.getElementById('imgContainer');
    this.dialogContainer = document.getElementsByClassName('mat-dialog-container')[0] as HTMLElement | null;
    this.input = document.getElementById('imgInput') as HTMLInputElement | null;

    this.input?.addEventListener('change',(e)=>{

      const curFiles = this.input?.files;
      let urls: Array<any> = new Array();

      if (curFiles){
        console.log(curFiles);
        // @ts-ignore
        for (const file of curFiles){
          // @ts-ignore
          urls.push(URL.createObjectURL(file));
        }
        console.log(urls);

      }
      let url ="url('" + urls[0] +"')";
      console.log("url: " + url  );

      if (this.imgContainer){
        this.imgContainer.style.display = 'flex';
        this.imgContainer.style.backgroundImage = url;

        this.SetStylesCardContent();
        this.ChangeStyleDisplayButton('block');
      }
    })
  }

  private SetStylesCardContent(){
    if (this.dialogContainer){
      this.dialogContainer.style.maxHeight = '78vh'
      this.dialogContainer.style.padding = '0px';
      this.dialogContainer.style.overflow = 'hidden';
      this.dialogContainer.style.borderRadius = '15px';
      this.dialogContainer.style.width = '40vw'
    }
  }

  private showAddSettings(){
    if (this.dialogContainer){
      this.dialogContainer.style.width = '64vw';
    }
    if (this.mainContainer){
      this.mainContainer.style.width = '64vw';
    }
    if (this.cardContentContainer){
      this.cardContentContainer.style.visibility = 'hidden';
    }
    //mat-card-content
    this.getUserInfo();
  }
  private hideAddSettings(){
    if (this.dialogContainer){
      this.dialogContainer.style.width = '40vw';
    }
    if (this.mainContainer){
      this.mainContainer.style.width = '40vw';
    }
    if (this.cardContentContainer){
      this.cardContentContainer.style.visibility = 'visible';
    }
    if (this.imgContainer){
      this.imgContainer.style.display = 'none';
      this.imgContainer.style.backgroundImage = '';
      this.ChangeStyleDisplayButton('none');
    }
  }

  private onUploadFile(){
    //console.log(this.image);
    if (this.image){
      if (this.file){
        this.fileUploadService.upload(this.file, this.image.name).subscribe(data => console.log(data));

        this.postService.createPost(this.createPostDto).subscribe(post => {
          this.createPostDto = post;
          console.log(this.createPostDto);
          if (this.image){
            this.image.postId = post.id;
            console.log('image');
            console.log(this.image);
            this.imageService.saveImage(this.image).subscribe(data => {
              console.log("saveImage");
              console.log(data)});
          }}
        );


      }
    }
    alert('Post Created');
  }
  private SendPost(){
    if (this.createPostDto){
      this.createPostDto.userId = this.user?.id;
      this.createPostDto.datePublication =  new Date(Date.now());

      // @ts-ignore
      this.file = this.input?.files[0];
      const guid = Guid.raw();
      //console.log(guid);
      const username = localStorage.getItem('username');
      this.image = new Image(guid, 'uploads/'+ username +'/' +guid, this.file?.type, this.user?.id);
      this.onUploadFile();

    }

    console.log(this.createPostDto);
  }
  public ClickNext(){
    if ( this.canSend ){
      this.SendPost();
    }
    else {
      this.showAddSettings();
      this.canSend = true;
    }
  }

  public ClickPref(){
    this.hideAddSettings();
    this.canSend = false;
  }

  private getUserInfo(){
    this.accountService.getUser().subscribe(user => {
      this.user = user
      this.user.urlMainImage = environment.apiFilesUrl + user.urlMainImage;
    });
  }

  public onChangedText(text: string){
    if (this.createPostDto){
      this.createPostDto.description = text;
    }

  }
}
