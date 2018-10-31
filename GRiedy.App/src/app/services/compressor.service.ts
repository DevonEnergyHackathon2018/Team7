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
      ScoredProbability: 0
    },
    {
      CompressorId: "comp2",
      CompressorName: "name2",
      ScoredProbability: 1
    },
    {
      CompressorId: "comp3",
      CompressorName: "name3",
      ScoredProbability: 2
    },
    {
      CompressorId: "comp4",
      CompressorName: "name4",
      ScoredProbability: 4
    },
    {
      CompressorId: "comp5",
      CompressorName: "name5",
      ScoredProbability: 5
    },
    {
      CompressorId: "comp6",
      CompressorName: "name6",
      ScoredProbability: 6
    },
    {
      CompressorId: "comp7",
      CompressorName: "name7",
      ScoredProbability: 7
    },
    {
      CompressorId: "comp8",
      CompressorName: "name8",
      ScoredProbability: 8
    },
    {
      CompressorId: "comp9",
      CompressorName: "name9",
      ScoredProbability: 9
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
