"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
//import { LoginComponent } from './Login/login.component';
//import { MainComponent } from './main/main.component';
var Signup_component_1 = require("./Signup.component");
var login_component_1 = require("./login.component");
//import { ResetComponent } from './Reset/reset.component';
//import { businessComponent } from './business/business.component';
//import { bdiscountComponent } from './bdiscount/bdiscount.component';
//import { innerhairComponent } from './innerhair/innerhair.component';
//import { tfilesComponent } from './tfiles/tfiles.component';
//import { blowdryComponent} from  './blowdry/blowdry.component';
//import { haircolorComponent } from './haircolor/haircolor.component';
var routes = [
    { path: "", redirectTo: "main", pathMatch: "full" },
    { path: 'signup', component: Signup_component_1.SignupComponent },
    //{ path: 'main', component: MainComponent },
    { path: 'login', component: login_component_1.LoginComponent },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = __decorate([
        core_1.NgModule({
            imports: [router_1.RouterModule.forRoot(routes)],
            exports: [router_1.RouterModule]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());
exports.AppRoutingModule = AppRoutingModule;
exports.routingComponents = [Signup_component_1.SignupComponent, login_component_1.LoginComponent];
//# sourceMappingURL=app-routing.module.js.map