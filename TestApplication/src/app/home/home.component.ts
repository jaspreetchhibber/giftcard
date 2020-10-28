import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from "src/app/_models/user.model";
import { AuthenticationService } from 'src/app/_services/authentication.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    currentUser: User;
    giftcards = [];
    dtOptions: DataTables.Settings = {};

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.getGiftCards();

        this.dtOptions = {
            pagingType: 'full_numbers',
            pageLength: 5,
            processing: true
          };      
    }

    deleteGiftCard(id: number) {
        this.userService.deleteGiftCard(id)
            .pipe(first())
            .subscribe(() => this.getGiftCards());
    }

    private getGiftCards() {
        this.userService.getGiftCards(this.currentUser.userId)
            .pipe(first())
            .subscribe(giftcards => this.giftcards = giftcards);
    }

}
