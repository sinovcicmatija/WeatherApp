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

  updateSelectedCity(city: City, oldCity: City | null) {
    localStorage.setItem('selectedCity', JSON.stringify(city));
    this.selectedCitySubject.next(city);
    this.fetchWeatherData(city.lat, city.lon, oldCity);
  }

  updateWeatherData(weatherData: any) {
    const timestamp = new Date().getTime(); 
    const dataToStore = { weatherData, timestamp };
    localStorage.setItem('weatherData', JSON.stringify(dataToStore));
    this.weatherDataSubject.next(weatherData);
  }


  fetchWeatherData(lat: number, lon: number, oldCity: City | null) {
    const cachedData = localStorage.getItem('weatherData');

    if (!oldCity || oldCity.lat !== lat || oldCity.lon !== lon) {
        console.log("Grad se promijenio ili nema starog grada, dohvaćam nove podatke...");
        this.apiService.getWeatherData(lat, lon).subscribe(data => {
            this.updateWeatherData(data);
        });
        return;
    }

    if (!cachedData) {
        console.log("Nema cache podataka, dohvaćam nove...");
        this.apiService.getWeatherData(lat, lon).subscribe(data => {
            this.updateWeatherData(data);
        });
        return;
    }

    const { timestamp } = JSON.parse(cachedData);
    const now = new Date().getTime();

    if (now - timestamp > 10 * 60 * 1000) {
        console.log("Cache podaci su stariji od 10 minuta, dohvaćam nove...");
        this.apiService.getWeatherData(lat, lon).subscribe(data => {
            this.updateWeatherData(data);
        });
    } else {
        console.log("Koristim cache podatke...");
        this.weatherDataSubject.next(JSON.parse(cachedData).weatherData);
    }
}

}
