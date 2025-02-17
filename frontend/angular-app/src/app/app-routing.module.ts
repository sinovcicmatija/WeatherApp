import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StartPageComponent } from './start-page/start-page.component';
import { MapsComponent } from './maps/maps.component';
import { SavedCitiesComponent } from './saved-cities/saved-cities.component';

const routes: Routes = [
  { path: '', component: StartPageComponent },
  { path: 'maps', component: MapsComponent},
  { path: 'saved-cities', component: SavedCitiesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
