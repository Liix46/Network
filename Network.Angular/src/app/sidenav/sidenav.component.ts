import { Component, OnInit } from '@angular/core';
import { MatDialog } from "@angular/material/dialog";
import { CreatePostDialogComponent } from "../dialogs/create-post-dialog/create-post-dialog.component";

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openDialog(): void{
    const dialogRef = this.dialog.open(CreatePostDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    })
  }
}
