import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Compressor } from "../data/compressor.data";

@Injectable()
export class CompressorService {
  constructor(private httpClient: HttpClient) {}

  public GetAll(): Observable<Compressor[]> {
    return this.httpClient.get<Compressor[]>(
      "http://localhost:5000/api/CompressorUpload"
    );
  }
}
