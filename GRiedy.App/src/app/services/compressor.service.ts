import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Compressor } from "../data/compressor.data";
import { of } from "rxjs/observable/of";

@Injectable()
export class CompressorService {
  private static allCompressors = [
    {
      CompressorId: "comp1",
      CompressorName: "name1",
      RiskRanking: 0
    },
    {
      CompressorId: "comp2",
      CompressorName: "name2",
      RiskRanking: 1
    },
    {
      CompressorId: "comp3",
      CompressorName: "name3",
      RiskRanking: 2
    },
    {
      CompressorId: "comp4",
      CompressorName: "name4",
      RiskRanking: 4
    },
    {
      CompressorId: "comp5",
      CompressorName: "name5",
      RiskRanking: 5
    },
    {
      CompressorId: "comp6",
      CompressorName: "name6",
      RiskRanking: 6
    },
    {
      CompressorId: "comp7",
      CompressorName: "name7",
      RiskRanking: 7
    },
    {
      CompressorId: "comp8",
      CompressorName: "name8",
      RiskRanking: 8
    },
    {
      CompressorId: "comp9",
      CompressorName: "name9",
      RiskRanking: 9
    }
  ];

  constructor(private httpClient: HttpClient) {}

  public GetAll(): Observable<Compressor[]> {
    // return this.httpClient.get<Compressor[]>(`http://5000/Compressor`);
    return of(CompressorService.allCompressors);
  }

  public Get(CompressorId: string): Observable<Compressor> {
    // return this.httpClient.get<Compressor>(`http://5000/Compressor?CompressorId=${CompressorId}`);
    return of(
      CompressorService.allCompressors.find(
        c => c.CompressorId === CompressorId
      )
    );
  }
}
