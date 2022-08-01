export interface IUserModel {
 
    email: string;
    userName: string;
    password: string;
    Token: string;
    isAdmin:string;
}

export class UserModel implements IUserModel {
    email: any;
    userName: any;
    password: any;
    Token: any;
    isAdmin:any;
}