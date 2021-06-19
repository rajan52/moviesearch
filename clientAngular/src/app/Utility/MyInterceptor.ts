import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDataService } from 'src/app/service/userdata.service';

@Injectable()
export class MyInterceptor implements HttpInterceptor {
    constructor(private userDataService: UserDataService)
    {

    }
  
  intercept(request: HttpRequest<any>, next: HttpHandler):  Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        'Authorization': 'Bearer '+this.userDataService.tokendto.token
      }
    });
    return next.handle(request);
  }
}