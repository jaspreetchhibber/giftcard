import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';

import { User } from "src/app/_models/user.model";
import { Giftcard } from "src/app/_models/giftcard.model";
@Injectable({
  providedIn: 'root'
})
export class UserService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(private http: HttpClient) { }

  getGiftCards(userId:number) {
    return this.http.get<Giftcard[]>(`${env.baseUrl}/Account/GetGiftCards/${userId}`);
  }

  updateGiftCard(giftcard: Giftcard) {
      return this.http.put(`${env.baseUrl}/Account/UpdateGiftCard`, JSON.stringify(giftcard), this.httpOptions);
    }

    deleteGiftCard(giftcardId: number) {
        return this.http.delete(`${env.baseUrl}/Account/DeleteGiftCard/${giftcardId}`);
    }
    getGiftCardById(giftcardId:number) {
      return this.http.get<Giftcard>(`${env.baseUrl}/Account/GetGiftCardById/${giftcardId}`);
    }
    addGiftCard(giftcard: Giftcard) {
      return this.http.post(`${env.baseUrl}/Account/AddGiftCard`, JSON.stringify(giftcard), this.httpOptions);
    }
}
