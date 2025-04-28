import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
/*import { RegisterComponent } from './components/register/register.component';
import { ClaimsComponent } from './components/claims/claims.component';
import { NewAccountComponent } from './components/new-account/new-account.component';
import { NewClaimComponent } from './components/new-claim/new-claim.component';
import { AuthInterceptor } from './auth/auth.interceptor';
*/

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ClaimsComponent,
    NewAccountComponent,
    NewClaimComponent
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, ReactiveFormsModule],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }