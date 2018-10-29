import { NgModule, Injectable } from "@angular/core";
import { ODataServiceFactory, ODataService } from "angular-odata-es5";

@Injectable()
export class ServiceFactory {
  constructor(private odataSvcFactory: ODataServiceFactory) {}
}
