import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { UserModel } from '../Model/UserModel';
@Injectable({
  providedIn: 'root'
})
export class SecurityServiceService {

  userModel= new UserModel();
  constructor(private http: HttpClient) { }
  login()
  {
    debugger;
    return this.http.post( 'https://localhost:7186/api/Account/login',this.userModel);
  }
}
