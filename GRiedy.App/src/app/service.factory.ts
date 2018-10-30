import { NgModule, Injectable } from "@angular/core";
import { ODataServiceFactory, ODataService } from "angular-odata-es5";
import { Compressor } from "./data/compressor.data";

@Injectable()
export class ServiceFactory {
  constructor(private odataSvcFactory: ODataServiceFactory) {}

  public CreateCompressorService(): ODataService<Compressor> {
    return this.odataSvcFactory.CreateService("Compressor");
  }
}
