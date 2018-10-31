import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Compressor } from "../data/compressor.data";

@Injectable()
export class CompressorService {
  constructor(private httpClient: HttpClient) {}

  public GetAll(): Observable<Compressor[]> {
    return this.httpClient.get<Compressor[]>(
      "https://greidyapi.azurewebsites.net/api/CompressorUpload"
    );
  }

  public Dismiss(key: number): Observable<any> {
    return this.httpClient.delete(
      `https://greidyapi.azurewebsites.net/api/CompressorUpload?key=${key}`
    );
  }
}
