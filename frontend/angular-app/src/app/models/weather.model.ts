export interface Coord {
    lon: number;
    lat: number;
  }
  
  export interface Weather {
    description: string;
    icon: string;
  }
  
  export interface WeatherMain {
    temp: number;
    feels_like: number;
    temp_min: number;
    temp_max: number;
    pressure: number;
    humidity: number;
    sea_level: number; 
    grnd_level: number;
  }
  
  export interface Wind {
    speed: number;
    deg: number;
    gust?: number;
  }
  
  export interface Rain {
    '1h'?: number; 
  }
  
  export interface Clouds {
    all: number;
  }
  
  export interface SysInfo {
    country: string;
    sunriseLocalTime: string;
    sunsetLocalTime: string;
  }
  
  export interface WeatherData {
    coord: Coord;
    weather: Weather[];
    main: WeatherMain;
    visibility: number;
    wind: Wind;
    rain?: Rain;
    clouds: Clouds;
    dt: number;
    sys: SysInfo;
    timezone: number;
    name: string;
  }
  