import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { NotfoundComponent } from './components/shared/notfound/notfound.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { HomeComponent } from './components/home/home.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { CreatePostDialogComponent } from './components/dialogs/create-post-dialog/create-post-dialog.component';
import { InputHintComponent } from './components/input-hint/input-hint.component';
import { PickerModule } from '@ctrl/ngx-emoji-mart';

import { AuthGuardService } from './_quards/auth-guard.service';
import { AuthInterceptorService } from './_interceptors/auth-interceptor.service';
import { ProfileComponent } from './components/profile/profile.component';
import { ChangeOrDeletePhotoDialogComponent } from './components/dialogs/change-or-delete-photo-dialog/change-or-delete-photo-dialog.component';
import { SearchComponent } from './components/search/search.component';
import { GuestProfileComponent } from './components/guest-profile/guest-profile.component';
import { PostInfoDialogComponent } from './components/dialogs/post-info-dialog/post-info-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotfoundComponent,
    RegistrationComponent,
    HomeComponent,
    SidenavComponent,
    CreatePostDialogComponent,
    InputHintComponent,
    ProfileComponent,
    ChangeOrDeletePhotoDialogComponent,
    SearchComponent,
    GuestProfileComponent,
    PostInfoDialogComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    PickerModule,
  ],
  providers: [
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent, LoginComponent],
})
export class AppModule {}
