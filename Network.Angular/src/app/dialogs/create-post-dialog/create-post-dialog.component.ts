import {Component, OnInit, AfterContentInit} from '@angular/core';

@Component({
  selector: 'app-create-post-dialog',
  templateUrl: './create-post-dialog.component.html',
  styleUrls: ['./create-post-dialog.component.scss']
})
export class CreatePostDialogComponent implements OnInit, AfterContentInit {

   private cardContent: HTMLElement|null = null;
  private imgContainer: HTMLElement | null = null;
  private  buttonNext: HTMLElement|null = null;
  public imgUrl: string = "";


  constructor() {
  }

  ngOnInit(): void {

  }

  ngAfterContentInit(): void {
    this.buttonNext = document.getElementById('buttonNext');
    this.imgContainer = document.getElementById('imgContainer');
    this.cardContent = document.getElementById('mat-dialog-0');
    const input = document.getElementById('imgInput') as HTMLInputElement | null;

    if (this.buttonNext){
      this.buttonNext.style.display = 'none';
    }
    if (this.cardContent){
      this.cardContent.style.padding = '0px';
      this.cardContent.style.overflow = 'hidden';
      this.cardContent.style.borderRadius = '15px';
      this.cardContent.style.width = '80vh'
    }


    input?.addEventListener('change',(e)=>{

      let values: string = '';
      let target = (e.target as HTMLInputElement);
      values = target.value;
      console.log("values: " + values);

      const curFiles = input?.files;
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

        if (this.cardContent){
          this.cardContent.style.maxHeight = '73vh'
          this.cardContent.style.padding = '0px';
          this.cardContent.style.overflow = 'hidden';
          this.cardContent.style.borderRadius = '15px';
          this.cardContent.style.width = '80vh'
        }

        if (this.buttonNext){
          this.buttonNext.style.display = 'block';
        }
      }
    })
  }



}
