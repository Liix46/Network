import {Component, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'input-hint',
  templateUrl: './input-hint.component.html',
  styleUrls: ['./input-hint.component.scss']
})
export class InputHintComponent implements OnInit {

  @Output() onChangedTextArea = new EventEmitter<string>();
  changeText(textArea: string){
    this.onChangedTextArea.emit(textArea);
  }

  public textArea: string = '';
  public isEmojiPickerVisible: boolean = false;

  constructor() { }
  ngOnInit(): void {
  }

  public changeAreaText(){
    this.changeText(this.textArea);
  }

  public addEmoji(event: any) {
    this.textArea = `${this.textArea}${event.emoji.native}`;
    this.isEmojiPickerVisible = false;
  }
}
