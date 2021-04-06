import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MarketdataListComponent } from './marketdata/marketdata-list/marketdata-list.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'marketdata', component: MarketdataListComponent },
 // { path: 'countries/:countryname', component: CountryDetailComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
