import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })
export class WeatherService {
    
    getWindDirection(deg: number): string {
        const directions = ['N', 'NE', 'E', 'SE', 'S', 'SW', 'W', 'NW'];
        const index = Math.round(deg / 45) % 8;
        return directions[index];
    }
}
