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

export class HttpErrorInterceptor implements HttpInterceptor {

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
        .pipe(
            retry(0),

            catchError((error: HttpErrorResponse) => {
                console.log('Error Interceptor', error);
                let errorMessage = '';
                if (error.error instanceof ErrorEvent) {
                    // client-side error
                    console.log('Client-side');
                    errorMessage = `Error: ${error.error.message}`;
                } else {
                    // server-side error
                    console.log('Server-side');
                    errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
                }
                window.alert(errorMessage);
                return throwError(errorMessage);
            })
        );
    }
}
