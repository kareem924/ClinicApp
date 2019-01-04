import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent} from './modules/home/home/home.component'

const routes: Routes = [
  {
    path: '',
    component : HomeComponent,
    pathMatch: 'full'
  },
  // Fallback when no prior routes is matched
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, {useHash: false})],
    exports: [RouterModule],
    providers: []
})
export class AppRoutingModule { }