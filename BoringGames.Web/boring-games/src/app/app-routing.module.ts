import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { CreditsComponent } from './credits/credits.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/games',
    pathMatch: 'full'
  },
  {
    path: 'games',
    loadChildren: () => import('./games/games.module').then( m => m.GamesModule)
  },
  {
    path: 'credits',
    component: CreditsComponent
  }

];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
