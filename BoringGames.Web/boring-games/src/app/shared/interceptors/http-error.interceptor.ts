import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
    HttpErrorResponse
   } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { ToastController } from '@ionic/angular';
import { Injectable } from '@angular/core';

export enum SeverityEnum {
    CRITICAL, WARNING, SUCCESS
}

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    /**
     * Constructor
     */
    constructor(private toast: ToastController) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return next.handle(request)
        .pipe(
            retry(0),

            catchError((error: HttpErrorResponse) => {
                let errorMessage = '';
                if (error.error instanceof ErrorEvent) {
                    // client-side error
                    console.log('Client-side');
                    errorMessage = `Error: ${error.error.message}`;
                } else {
                    switch (error.status) {
                        case 0: errorMessage = `Couldn\'t connect to server.`; break;
                        default: errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
                    }
                    console.log('Server-side error', error);
                    this.presentToast(errorMessage, SeverityEnum.CRITICAL);
                }
                return throwError(errorMessage);
            })
        );
    }

    /**
     * Presents the toaster
     * @param messageText Message to show
     * @param severity Severity
     */
    private async presentToast(messageText: string, severity: SeverityEnum) {

        switch (severity) {
            case SeverityEnum.CRITICAL: await this.presentErrorToast(messageText); break;
            case SeverityEnum.WARNING: await this.presentWarningToast(messageText); break;
            case SeverityEnum.SUCCESS: await this.presentSuccessToast(messageText); break;
        }

    }

    /**
     * Shows error toaster with dismiss button
     * @param messageText Message
     */
    private async presentErrorToast(messageText: string) {

        const toast = await this.toast.create({
            message: messageText,
            color: 'danger',
            position: 'top',
            buttons: [
                {
                    text: 'Ok',
                    role: 'cancel'
                }
            ]
          });

        toast.present();

    }

    /**
     * Shows a warning toaster
     * @param messageText Message
     */
    private async presentWarningToast(messageText: string) {

        const toast = await this.toast.create({
            message: messageText,
            color: 'warning',
            duration: 10000,
            position: 'top'
          });

        toast.present();

    }

    /**
     * Shows a success toaster
     * @param messageText Message
     */
    private async presentSuccessToast(messageText: string) {

        const toast = await this.toast.create({
            message: messageText,
            color: 'success',
            duration: 5000,
            position: 'top'
          });

        toast.present();

    }
}
