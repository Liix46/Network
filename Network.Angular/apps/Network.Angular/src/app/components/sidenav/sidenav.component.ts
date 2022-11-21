import { Component, OnInit } from '@angular/core';
import { MatDialog } from "@angular/material/dialog";
import { CreatePostDialogComponent } from "../dialogs/create-post-dialog/create-post-dialog.component";

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  private searchComponent: HTMLElement | null | undefined;
  private listItemSpan: HTMLCollectionOf<HTMLElement> | undefined;
  private listMatItem: HTMLCollectionOf<HTMLElement> | undefined;
  private titleElement: HTMLElement | null | undefined;
  private navContainer: HTMLElement | null | undefined;

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
    this.searchComponent = document.getElementById('search-component');
    this.listItemSpan = document.getElementsByClassName('list-item-span') as HTMLCollectionOf<HTMLElement>;
    this.listMatItem = document.getElementsByClassName('mat-list-item') as HTMLCollectionOf<HTMLElement>;
    this.titleElement = document.getElementById('side-title');
    this.navContainer = document.getElementById('nav-container');

    if (this.searchComponent){
      this.searchComponent.style.display = 'none';

    }
  }

  openDialog(): void{
    const dialogRef = this.dialog.open(CreatePostDialogComponent, {disableClose: true});
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    })
  }

  changeSizeNavMenu() : void{
    if (this.listItemSpan) {
      for (let i = 0; i < this.listItemSpan.length; i++){
        // @ts-ignore
        if (this.listItemSpan.item(i).style.display != 'none'){
          // @ts-ignore
          this.listItemSpan.item(i).style.display = 'none';
        }
        else {
          // @ts-ignore
          this.listItemSpan.item(i).style.display = 'block';
        }

      }
    }
    if(this.titleElement){
      if (this.titleElement.style.display != 'none'){
        this.titleElement.style.display = 'none';
      }
      else {
        this.titleElement.style.display = 'block';
      }
    }
    if (this.navContainer){
      if (this.navContainer.style.width == '4vw'){
        this.navContainer.style.width = '18vw';
      }
      else
      {
        this.navContainer.style.width = '4vw';
      }
    }
    // @ts-ignore
    console.log(this.listMatItem.length);

    if (this.listMatItem){
      for (let i = 0; i < this.listMatItem.length; i++){
        // @ts-ignore
        if (this.listMatItem.item(i).style.width == '20%'){
          // @ts-ignore
          this.listMatItem.item(i).style.width = '90%';
          // @ts-ignore
          this.listMatItem.item(i).style.marginLeft = '10px';
          // @ts-ignore
          this.listMatItem.item(i).style.paddingLeft = '0px';
        }
        else {
          // @ts-ignore
          this.listMatItem.item(i).style.width = '20%';
          // @ts-ignore
          this.listMatItem.item(i).style.marginLeft = '2px';
          // @ts-ignore
          this.listMatItem.item(i).style.paddingLeft = '10px';
        }

      }
    }
  }
  searchClick(): void{
    this.searchComponent = document.getElementById('search-component');
    this.listItemSpan = document.getElementsByClassName('list-item-span') as HTMLCollectionOf<HTMLElement>;
    this.titleElement = document.getElementById('side-title');
    this.navContainer = document.getElementById('nav-container');
    this.listMatItem = document.getElementsByClassName('mat-list-item') as HTMLCollectionOf<HTMLElement>;


    if (this.searchComponent){

      if (this.searchComponent.style.display != 'none'){
        this.searchComponent.style.display = 'none';
      }
      else {
        this.searchComponent.style.display = 'block';
      }
      this.changeSizeNavMenu();
    }

  }
}
