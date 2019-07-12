import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CityComponent } from './city.component';
import { PicComponent } from './pic.component';
import { FooterComponent } from './footer.component';
import { LoginComponent } from './login.component';
import { SignupComponent } from './Signup.component';

@NgModule({
    imports: [BrowserModule,
        FormsModule],
    declarations: [AppComponent, CityComponent, PicComponent, FooterComponent, LoginComponent, SignupComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
