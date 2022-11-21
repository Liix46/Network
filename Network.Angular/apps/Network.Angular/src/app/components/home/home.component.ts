import { Component, OnInit } from '@angular/core';
import {AuthGuardService} from "../../_quards/auth-guard.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [AuthGuardService]
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
