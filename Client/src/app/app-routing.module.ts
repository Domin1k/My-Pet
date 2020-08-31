import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
    {
      path: 'auth',
      loadChildren: () => import('./authentication/authentication-routing.module').then(m => m.AuthenticationRoutingModule)
    },
    {
      path: 'pets',
      loadChildren: () => import('./pets/pets-routing.module').then(m => m.PetsRoutingModule)
    },
    {
      path: '',
      loadChildren: () => import('./shared/shared-routing.module').then(m => m.SharedRoutingModule)
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }