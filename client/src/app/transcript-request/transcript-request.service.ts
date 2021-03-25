import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { School } from '../shared/models/school';

@Injectable({
  providedIn: 'root'
})
export class TranscriptRequestService {
  baseUrl = 'https://localhost:5001/api/v1/';

  constructor(private http: HttpClient) { } 


  getSchools() : Observable<School[]> {
    return this.http.get<School[]>(this.baseUrl + 'schoolmanagement/getschools');
  }
}
