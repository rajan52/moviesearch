import {  Injector, Injectable  } from '@angular/core';
import {HttpClient} from "@angular/common/http"
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export  class MovieService {
  private apiUrl="https://localhost:44305/api"
  constructor(private httpc:HttpClient )
  {

  }

  getMovies():Observable<any>
  {
   return this.httpc.get(`${this.apiUrl}`+"/movie");
  }

}

