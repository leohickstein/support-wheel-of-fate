import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class WheelOfFateService {
  private url = "http://localhost:57693/api/";

  constructor(private http: HttpClient) {}

  //   generateBAUSchedule(): Observable<any> {
  //     return this.http.get<any>(this.url);
  //   }
}
