import { Injectable } from '@angular/core';
import { Helper } from './helper';

@Injectable()
export class LocalStoreManager {

    public localStorageSetItem(key: string, data: any) {
        localStorage.setItem(key, JSON.stringify(data));
    }

    public sessionStorageSetItem(key: string, data: any) {
        sessionStorage.setItem(key, JSON.stringify(data));
    }


    public localStorageGetItem(key: string) {
        return Helper.JSonTryParse(localStorage.getItem(key));
    }

    public sessionStorageGetItem(key: string) {
        return Helper.JSonTryParse(sessionStorage.getItem(key));
    }

    public exists(key = null) {

        let data = sessionStorage.getItem(key);

        if (data == null) {
            data = localStorage.getItem(key);
        }

        return data != null;
    }


    public clearAll() {
        sessionStorage.clear();
        localStorage.clear();
    }

}
