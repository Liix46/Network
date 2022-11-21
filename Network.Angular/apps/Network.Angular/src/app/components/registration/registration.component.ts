import { Component, OnInit } from '@angular/core';
import {AccountService} from "../../_services/account.service";
import {ActivatedRoute, Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UserForRegistration} from "../../_models/account/UserForRegistration";
import {BearerToken} from "../../_models/account/BearerToken";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
  providers: [AccountService]
})
export class RegistrationComponent implements OnInit {

  private returnUrl!: string;
  public userRegForm!: FormGroup;
  constructor(private accountService: AccountService,
              private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.userRegForm = this.formBuilder.group({
      UserName: ['', [Validators.required]],
      FullName: ['', [Validators.required]],
      Email: ['', [Validators.required, Validators.email]],
      Password: ['', [Validators.required, Validators.minLength(8)]]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '';
  }

  registration(){
    const userReg : UserForRegistration = {
      ...this.userRegForm.value
    };

    this.accountService.registration(userReg)
      .subscribe((bearerToken : BearerToken) =>{
        localStorage.setItem('accessToken', bearerToken.accessToken);
        localStorage.setItem('username', bearerToken.username);
        this.router.navigate([this.returnUrl]);
      })
  }

}
