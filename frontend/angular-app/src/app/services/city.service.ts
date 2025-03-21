import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { City } from '../models/city.model';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CityService {
  private selectedCitySubject = new BehaviorSubject<City | null>(null);
  selectedCity$ = this.selectedCitySubject.asObservable();

  private weatherDataSubject = new BehaviorSubject<any | null>(null);
  weatherData$ = this.weatherDataSubject.asObservable();


  constructor(private apiService: ApiService) {
}

  updateSelectedCity(city: City) {
    this.selectedCitySubject.next(city);
    this.fetchWeatherData(city);
  }

  fetchWeatherData(city: City) {
    this.apiService.getWeatherData(city).subscribe(data => {
      this.weatherDataSubject.next(data);
      console.log("Primljeni podaci o vremenu:", data);
        });
    }
}

