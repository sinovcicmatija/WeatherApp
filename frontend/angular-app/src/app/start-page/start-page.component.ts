import { Component, OnInit } from '@angular/core';
import { CityService } from '../services/city.service';
import { City } from '../models/city.model';
import { WeatherData } from '../models/weather.model';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrl: './start-page.component.scss',
  standalone: false
})
export class StartPageComponent {
  selectedCity: City | null = null;
  weatherData: WeatherData | null = null;

  constructor(private cityService: CityService) {}

  ngOnInit()
  {
    this.cityService.selectedCity$.subscribe(city => {
      if(city) {
        this.selectedCity = city;
        console.log("Odabrani grad u StartPageComponent:", city);
      }
    })

    this.cityService.weatherData$.subscribe(data => {
      if (data) {
        this.weatherData = data;
        console.log("Primljeni podaci o vremenu:", data);
      }
    })
    
  }
  

  hourlyForecast = [
    { time: "03:00", icon: "url", temp: 12, rainChance: 10 },
    { time: "06:00", icon: "url", temp: 14, rainChance: 20 },
    { time: "09:00", icon: "url", temp: 16, rainChance: 30 },
    { time: "12:00", icon: "url", temp: 18, rainChance: 25 },
    { time: "15:00", icon: "url", temp: 20, rainChance: 15 },
    { time: "18:00", icon: "url", temp: 17, rainChance: 10 },
    { time: "21:00", icon: "url", temp: 14, rainChance: 5 },
    { time: "00:00", icon: "url", temp: 12, rainChance: 5 },
  ];
  
  dailyForecast = [
    { day: "Ponedjeljak", icon: "url", minTemp: 10, maxTemp: 18, rainChance: 20 },
    { day: "Utorak", icon: "url", minTemp: 12, maxTemp: 20, rainChance: 30 },
    { day: "Srijeda", icon: "url", minTemp: 8, maxTemp: 17, rainChance: 40 },
    { day: "Četvrtak", icon: "url", minTemp: 9, maxTemp: 19, rainChance: 25 },
    { day: "Petak", icon: "url", minTemp: 11, maxTemp: 22, rainChance: 10 },
  ];

}
