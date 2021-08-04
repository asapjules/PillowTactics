import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from "@angular/router";

import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { CreatecharacterComponent } from './createcharacter/createcharacter.component';
import { EditcharacterComponent } from './editcharacter/editcharacter.component';
import { ArenaComponent } from './arena/arena.component';

import { FormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    CreatecharacterComponent,
    EditcharacterComponent,
    ArenaComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      {path: "profile", component: ProfileComponent},
      {path: "create", component: CreatecharacterComponent},
      {path: "edit", component: EditcharacterComponent},
      {path: "arena", component: ArenaComponent},
      {path:"login", component: LoginComponent},
      {path:"login", component:RegisterComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
