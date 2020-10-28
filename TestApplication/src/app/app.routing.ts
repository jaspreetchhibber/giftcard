import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from 'src/app/home/home.component';
import { LoginComponent } from 'src/app/login/login.component';
import { GiftCardComponent } from 'src/app/giftcard/giftcard.component';
import { AuthGuard } from 'src/app/_helper/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'giftcard/:id', component: GiftCardComponent },
  { path: 'giftcard', component: GiftCardComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
 export class AppRoutingModule { }
//export class AppRoutingModule = RouterModule.forRoot(routes);
