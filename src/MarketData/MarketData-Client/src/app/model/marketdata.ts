import { DecimalPipe } from "@angular/common";

export interface FxData {
    id : number;
    currency : string;
    ask: number;
    bid: number;
    quoteDateTime: string;
}