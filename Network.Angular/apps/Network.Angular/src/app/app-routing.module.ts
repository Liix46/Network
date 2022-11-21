import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from "./components/login/login.component";
import { NotfoundComponent } from "./components/shared/notfound/notfound.component";
import {RegistrationComponent} from "./components/registration/registration.component";
import {HomeComponent} from "./components/home/home.component";
import {AuthGuardService} from "./_quards/auth-guard.service";
import {AuthInterceptorService} from "./_interceptors/auth-interceptor.service";
import {ProfileComponent} from "./components/profile/profile.component";
import {GuestProfileComponent} from "./components/guest-profile/guest-profile.component";

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent},
  { path: '', component: HomeComponent, canActivate: [AuthGuardService] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuardService] },
  {path:  'users/:username', pathMatch:'full', component: GuestProfileComponent, canActivate: [AuthGuardService] },
  { path: '**', component: NotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuardService, AuthInterceptorService]
})
export class AppRoutingModule { }
