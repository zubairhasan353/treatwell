import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { LoginComponent } from './Login/login.component';
//import { MainComponent } from './main/main.component';
import { SignupComponent } from './Signup.component';
import { LoginComponent } from './login.component';
//import { ResetComponent } from './Reset/reset.component';
//import { businessComponent } from './business/business.component';
//import { bdiscountComponent } from './bdiscount/bdiscount.component';
//import { innerhairComponent } from './innerhair/innerhair.component';
//import { tfilesComponent } from './tfiles/tfiles.component';
//import { blowdryComponent} from  './blowdry/blowdry.component';
//import { haircolorComponent } from './haircolor/haircolor.component';

const routes: Routes = [
  {path : "" , redirectTo : "main" , pathMatch:"full"},
  { path: 'signup', component: SignupComponent },
  //{ path: 'main', component: MainComponent },
  { path: 'login', component: LoginComponent },
  //{ path: 'reset', component: ResetComponent },
  //{ path: 'business', component: businessComponent },
  //{ path: 'bdiscount', component: bdiscountComponent},
  //{ path: 'innerhair', component: innerhairComponent},
  //{ path: 'tfile', component: tfilesComponent},
  //{ path: 'blowdry', component: blowdryComponent},
  //{ path: 'haircolor', component: haircolorComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [SignupComponent, LoginComponent]
