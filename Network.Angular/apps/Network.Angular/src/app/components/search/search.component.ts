import { Component, OnInit } from '@angular/core';
import {UserService} from "../../_services/user.service";
import {UserSearchDto} from "../../_models/users/UserSearchDto";
import {SearchDto} from "../../_models/shared/SearchDto";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers: [UserService]
})
export class SearchComponent implements OnInit {
  searchUsers : Array<UserSearchDto> | undefined;
  constructor(private userService : UserService) {}

  ngOnInit(): void {}

  usersSearch(e: any): void {
    //console.log(e.target.value);
    let searchString = e.target.value;
    if (searchString){
      if (searchString.trim().length > 0){
        const search = new SearchDto(searchString);
        this.userService.postSearchUsers(search).subscribe(response => {
          for (const user of response) {
            user.urlMainImage = environment.apiFilesUrl + user.urlMainImage;
          }
          this.searchUsers = response;
          console.log(this.searchUsers);
        })
      }
    }
  }
}
