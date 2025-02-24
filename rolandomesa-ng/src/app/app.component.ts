import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ForecastRegistry } from './forecast-registry';
import { tap } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  forecastApiBaseUrl = "http://localhost:32771";
  title = 'rolandomesa-ng';
  registries: number = 0;

  constructor (private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.httpClient.get<ForecastRegistry[]>(`${this.forecastApiBaseUrl}/WeatherForecast`).pipe(
      tap((registries: ForecastRegistry[]) => {
        this.registries = registries.length;
      })
    ).subscribe();
  }
}
