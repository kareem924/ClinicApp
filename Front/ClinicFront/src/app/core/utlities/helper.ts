import {Injectable} from '@angular/core';


@Injectable()
export class Helper {

    public static JSonTryParse(value: string) {
        try {
            return JSON.parse(value);
        }
        catch (e) {
            if (value === "undefined") {
                return void 0;
            }

            return value;
        }
    }
}