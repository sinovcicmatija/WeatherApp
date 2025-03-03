import { Component } from '@angular/core';

@Component({
  selector: 'app-start-page',
  templateUrl: './start-page.component.html',
  styleUrl: './start-page.component.scss',
  standalone: false
})
export class StartPageComponent {
  

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
