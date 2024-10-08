import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private apiUrl = 'https://localhost:44334/api/Position/GetAllPositions'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getPositions(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
