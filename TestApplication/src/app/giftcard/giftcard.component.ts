import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';

import { User } from "src/app/_models/user.model";
import { AuthenticationService } from 'src/app/_services/authentication.service';
import { UserService } from 'src/app/_services/user.service';
import { AlertService } from 'src/app/_services/alert.service';
import { Giftcard } from 'src/app/_models/giftcard.model';

@Component({
  selector: 'app-giftcard',
  templateUrl: './giftcard.component.html',
  styleUrls: ['./giftcard.component.scss']
})
export class GiftCardComponent implements OnInit {
    giftcardForm: FormGroup;
    currentUser: User;
    loading = false;
    submitted = false;
    id: number;
    giftcard: Giftcard;
    isAddMode: boolean;

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private alertService: AlertService,
        private formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() { 
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;
        if (!this.isAddMode) {         
            // this.userService.getGiftCardById(this.id).subscribe((data)=>{
            // this.giftcard = data;
            // });
            this.userService.getGiftCardById(this.id)
            .pipe(first())
            .subscribe(x => this.giftcardForm.patchValue(x));
        }
        this.giftcardForm = this.formBuilder.group({ 
            giftCardId:[''],           
            giftCardNumber: ['', Validators.required],
            value: ['', Validators.required],
            type: ['', Validators.required],
            status: ['', Validators.required],
            userId:['']
        });   
    }
    get f() { return this.giftcardForm.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.giftcardForm.invalid) {
            return;
        }

        this.loading = true;

        if (this.isAddMode) {
            this.giftcardForm.value.giftCardId=0;
            this.giftcardForm.value.userId=this.currentUser.userId;
            this.userService.addGiftCard(this.giftcardForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('giftcard added', true);
                    this.router.navigate(['/home']);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                }); 
        } else {
            this.userService.updateGiftCard(this.giftcardForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('giftcard updated', true);
                    this.router.navigate(['/home']);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
        }
    }
}
