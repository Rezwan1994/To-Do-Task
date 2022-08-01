import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateToDoComponent } from './Components/create-to-do/create-to-do.component';
import { LoginComponent } from './Components/login/login.component';




const routes: Routes = [
  //{path: '', component: HomeComponent, data: {breadcrumb: 'Home'} },
  //{path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'} },
  {path: '', component: LoginComponent},

  {path: 'login', component: LoginComponent},
  {path: 'createtodo', component: CreateToDoComponent},

];


@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
