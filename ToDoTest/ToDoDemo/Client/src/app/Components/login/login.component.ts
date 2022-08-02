import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUserModel } from 'src/app/Model/UserModel';
import { SecurityServiceService } from 'src/app/Security/security-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public securityService:SecurityServiceService, private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    console.log(this.securityService.userModel.userName);
    console.log(this.securityService.userModel.password);
    this.securityService.login().subscribe(
      (res)=>{
        debugger;
        var result = res as IUserModel;
        if(result.Token != '')
        {
          localStorage.setItem('token', result.Token);
          localStorage.setItem('isAdmin', String(result.isAdmin));
          this.router.navigate(['/createtodo'])
         
        }
      },
      (err)=>{
        alert("Invalid User Name or Password");
      }
    )
  }


}
