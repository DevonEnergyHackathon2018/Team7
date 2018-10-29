import { Injectable } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";
import { Message } from "primeng/primeng";

@Injectable()
export class MessageService {
  public msgs: Message[] = [];

  public AddSuccess(summary: string, detail: string, growl: boolean = true) {
    if (growl) {
      if (!this.msgs) {
        this.msgs = [];
      }
      this.msgs.push({ severity: "success", summary: summary, detail: detail });
    }
    console.log(`${summary}: ${detail}`);
  }

  public AddInfo(summary: string, detail: string) {
    if (!this.msgs) {
      this.msgs = [];
    }
    this.msgs.push({ severity: "info", summary: summary, detail: detail });
    console.log(`${summary}: ${detail}`);
  }

  public AddWarning(summary: string, detail: string) {
    if (!this.msgs) {
      this.msgs = [];
    }
    this.msgs.push({ severity: "warn", summary: summary, detail: detail });
    console.warn(`${summary}: ${detail}`);
  }

  public AddError(summary: string, error: Error) {
    if (!this.msgs) {
      this.msgs = [];
    }
    const detailType = typeof error;
    switch (detailType) {
      case "object":
        if (error.name) {
          if (error.name === "HttpErrorResponse") {
            const response = error as HttpErrorResponse;
            let message = "HTTP Error";
            if (response.error) {
              if (response.error.error) {
                if (response.error.error.message) {
                  message = response.error.error.message;
                }
                if (response.error.error.innererror) {
                  message += `<br />${response.error.error.innererror.message}`;
                }
              }
            } else if (response.message) {
              message = response.message;
            } else if (response.statusText) {
              message = response.statusText;
            }

            this.msgs.push({
              severity: "error",
              summary: summary,
              detail: message
            });
          }
        }
        break;
      case "string":
        this.msgs.push({
          severity: "error",
          summary: summary,
          detail: error.message
        });
        break;
      default:
        this.msgs.push({
          severity: "error",
          summary: summary,
          detail: "No error details."
        });
        break;
    }
    console.error(`${summary}: ${error.message}`);
  }
}
