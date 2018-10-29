import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { Compressor } from "../data/compressor.data";
import { of } from "rxjs/observable/of";

@Injectable()
export class CompressorService {
  constructor(private httpClient: HttpClient) {}

  public GetCompressorRankings(RankedOn: Date): Observable<Compressor[]> {
    // return this.httpClient.get<Compressor[]>(`http://5000/Compressor?RankedOn=${(RankedOn || new Date()).toISOString()}`);
    return of([
      {
        Id: 1,
        CompressorId: "comp1",
        CompressorName: "name1",
        RiskRanking: 0,
        RankedOn: RankedOn
      },
      {
        Id: 2,
        CompressorId: "comp2",
        CompressorName: "name2",
        RiskRanking: 1,
        RankedOn: RankedOn
      },
      {
        Id: 3,
        CompressorId: "comp3",
        CompressorName: "name3",
        RiskRanking: 2,
        RankedOn: RankedOn
      },
      {
        Id: 4,
        CompressorId: "comp4",
        CompressorName: "name4",
        RiskRanking: 3,
        RankedOn: RankedOn
      },
      {
        Id: 5,
        CompressorId: "comp5",
        CompressorName: "name5",
        RiskRanking: 3,
        RankedOn: RankedOn
      },
      {
        Id: 6,
        CompressorId: "comp6",
        CompressorName: "name6",
        RiskRanking: 3,
        RankedOn: RankedOn
      },
      {
        Id: 7,
        CompressorId: "comp7",
        CompressorName: "name7",
        RiskRanking: 3,
        RankedOn: RankedOn
      },
      {
        Id: 8,
        CompressorId: "comp8",
        CompressorName: "name8",
        RiskRanking: 3,
        RankedOn: RankedOn
      },
      {
        Id: 9,
        CompressorId: "comp9",
        CompressorName: "name9",
        RiskRanking: 3,
        RankedOn: RankedOn
      }
    ]);
  }
}
