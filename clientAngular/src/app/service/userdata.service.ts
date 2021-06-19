import {  Injector, Injectable  } from '@angular/core';
import { TokenDto } from 'src/app/service/token.model';

@Injectable()
export  class UserDataService {
  tokendto : TokenDto = new TokenDto();
}
