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
    const storedCity = localStorage.getItem('selectedCity');
    if (storedCity) {
      this.selectedCitySubject.next(JSON.parse(storedCity));
    }

    const cachedWeather = localStorage.getItem('weatherData');
    if (cachedWeather) {
      const parsedData = JSON.parse(cachedWeather);
      this.weatherDataSubject.next(parsedData.weatherData);
    }
  }

  updateSelectedCity(city: City) {
    localStorage.setItem('selectedCity', JSON.stringify(city));
    this.selectedCitySubject.next(city);
  }

  updateWeatherData(weatherData: any) {
    const timestamp = new Date().getTime(); 
    const dataToStore = { weatherData, timestamp };
    localStorage.setItem('weatherData', JSON.stringify(dataToStore));
    this.weatherDataSubject.next(weatherData);
  }

  shouldFetchNewWeatherData(): boolean {
    const cachedData = localStorage.getItem('weatherData');
    if (!cachedData) return true; 
  
    const { timestamp } = JSON.parse(cachedData);
    const now = new Date().getTime();
    return now - timestamp > 10 * 60 * 1000; 
  }

  fetchWeatherData(lat: number, lon: number) {
    if (this.shouldFetchNewWeatherData()) {
      this.apiService.getWeatherData(lat, lon).subscribe(data => {
        this.updateWeatherData(data);
      });
    } else {
      const cachedData = JSON.parse(localStorage.getItem('weatherData')!);
      this.weatherDataSubject.next(cachedData.weatherData);
    }
  }
}
