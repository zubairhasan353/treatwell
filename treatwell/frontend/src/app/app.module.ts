import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from "@angular/forms";
import { CityComponent } from './city.component';
import { PicComponent } from './pic.component';
import { FooterComponent } from './footer.component';
import { LoginComponent } from './login.component';
import { SignupComponent } from './Signup.component';

import { from } from 'rxjs';



@NgModule({
  
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule


  ],
  providers: [],
  declarations: [AppComponent, CityComponent, PicComponent, FooterComponent, LoginComponent, SignupComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
