import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';
import { UserDataService } from '../service/userdata.service';
import { Observable } from 'rxjs/internal/Observable';
import { TokenDto } from 'src/app/service/token.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted = false;
  constructor(private formBuilder: FormBuilder, private router: Router, private userService:UserService,
    private userDataService:UserDataService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  get data() { return this.loginForm.controls; }

  onSubmit() {    
    if (this.loginForm.invalid) {
      return;
    } 
    else   
    {
      var data=  this.userService.Login(this.data.username.value,this.data.password.value)
      .subscribe((res)=>{this.Success(res)},(err)=>{this.Error(err)});
      console.log(data);
    }
  }

  Error(res) {
    alert('error');
    this.router.navigate(['/login']);
  }

  Success(res) {
   console.log(res);
   alert("res");
   this.userDataService.tokendto=res;
   this.router.navigate(['/home']);
   
  }

}