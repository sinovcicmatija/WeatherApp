import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from "../models/city.model";
import { WeatherData } from "../models/weather.model";

const apiurl = environment.apiUrl;

@Injectable({providedIn: 'root'})
export class ApiService {
    constructor(private http: HttpClient) {}

    getCityData(city: string): Observable<City[]>
    {
        return this.http.get<City[]>(`${apiurl}/City/cityData?name=${city}`);
    }

    getWeatherData(lat: number, lon: number): Observable<WeatherData[]>
    {
        return this.http.get<WeatherData[]>(`${apiurl}/Weather/cityWeather?lat=${lat}&lon=${lon}`);
    }
      
}

