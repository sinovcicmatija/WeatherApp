import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { debounceTime, distinctUntilChanged, filter, Observable, startWith, switchMap } from 'rxjs';
import { FormControl } from '@angular/forms';
import { City } from './models/city.model';
import { ApiService } from './services/api.service';
import { CityService } from './services/city.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  standalone: false
})
export class AppComponent {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;
  isMobile = true;
  isCollapsed = true;

  searchControl = new FormControl();
  cities$: Observable<City[]> | null = null;

  selectedCity: string = "";

  constructor(private observer: BreakpointObserver, private apiService: ApiService, private cityService: CityService) {}

  ngOnInit() {
    this.observer.observe(['(max-width: 800px)']).subscribe((screenSize) => {
      if(screenSize.matches) {
        this.isMobile = true;
      } else {
        this.isMobile = false;
      }
    });

    this.cities$ = this.searchControl.valueChanges.pipe(
      debounceTime(500), 
      distinctUntilChanged(), 
      filter(value => typeof value === 'string' && value.trim().length > 0),
      switchMap(value => this.apiService.getCityData(value)),
    );
  }

  onCitySelected(event: any) {
    const oldCity: City | null = localStorage.getItem('selectedCity') 
        ? JSON.parse(localStorage.getItem('selectedCity')!) 
        : null;
    const selectedCity: City = event.option.value; 
    console.log("Odabrani grad:", selectedCity);
    this.cityService.updateSelectedCity(selectedCity, oldCity);
  }

  displayFn(city: City | null): string {
    return city?.name ?? '';
  }


  toggleSidenav() {
    if(this.isMobile){
      this.sidenav.toggle();
      this.isCollapsed = false;
    } else {
      this.sidenav.open();
      this.isCollapsed = !this.isCollapsed;
    }
  }
}
