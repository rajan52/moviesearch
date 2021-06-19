import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../app/service/user.service';
import { UserDataService } from '../app/service/userdata.service';
import { MovieService } from '../app/service/movie.service';
import {HttpClientModule, HTTP_INTERCEPTORS} from "@angular/common/http";
import { MyInterceptor } from 'src/app/Utility/MyInterceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [MovieService,UserService,UserDataService, 
    {provide: HTTP_INTERCEPTORS, useClass: MyInterceptor ,  multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
