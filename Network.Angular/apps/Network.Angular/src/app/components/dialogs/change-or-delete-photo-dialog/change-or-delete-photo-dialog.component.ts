import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {FileUploadService} from "../../../_services/file-upload.service";
import {Image} from "../../../_models/shared/Image";
import {Guid} from "guid-typescript";
import {UserTitle} from "../../../_models/users/UserTitle";
import {AccountService} from "../../../_services/account.service";
import {UserService} from "../../../_services/user.service";

@Component({
  selector: 'app-change-or-delete-photo-dialog',
  templateUrl: './change-or-delete-photo-dialog.component.html',
  styleUrls: ['./change-or-delete-photo-dialog.component.css'],
  providers: [FileUploadService, AccountService, UserService]
})
export class ChangeOrDeletePhotoDialogComponent implements OnInit {

  private input: HTMLInputElement | undefined;
  private file : File | undefined;

  constructor(
    private fileUploadService : FileUploadService,
    private accountService : AccountService,
    private userService : UserService) {}

  public ngOnInit(): void {
    this.initElements();
  }


  private initElements(){
    this.input = document.getElementById('imgInput') as HTMLInputElement;
  }
  public uploadPhoto(e: any){

    // @ts-ignore
    this.file = this.input?.files[0];

    if (this.file){
      this.fileUploadService.uploadAvatar(this.file, Guid.raw()).subscribe(data => console.log(data));
    }

  }

  public clickRemoveImage(){

    this.userService.deleteAvatarImage().subscribe(
      response => {
        console.log(response);
      }
    );
  }

}
