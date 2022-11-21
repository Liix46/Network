import {Component, OnInit} from '@angular/core';
import {AccountService} from "../../_services/account.service";
import {ActivatedRoute, Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {UserForLogin} from "../../_models/account/UserForLogin";
import {BearerToken} from "../../_models/account/BearerToken";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [AccountService]
})
export class LoginComponent implements OnInit {

  private returnUrl!: string;
  public userLoginForm!: FormGroup;
  constructor(private accountService: AccountService,
              private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder) {

  }

  ngOnInit(): void {
    this.userLoginForm = this.formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8)]]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] ||'';
  }

  login(){
    const userLogin: UserForLogin = {
      ...this.userLoginForm.value
    };

    this.accountService.login(userLogin)
      .subscribe((bearerToken: BearerToken) => {
        localStorage.setItem('accessToken', bearerToken.accessToken);
        localStorage.setItem('username', bearerToken.username);
        this.router.navigate([this.returnUrl]);
      })
  }
}
