import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MovieService } from '../service/movie.service';
import { UserDataService } from '../service/userdata.service';
import { MovieList } from '../home/movielist.model';
import { Movie } from '../home/movie.model';
import { Observable } from 'rxjs/internal/Observable';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

movies:Movie[];

  constructor(private router: Router, private movieService:MovieService,public userDataService:UserDataService) { }


  ngOnInit() {

    // if(this.userDataService.tokendto!=undefined && !this.userDataService.tokendto.token)
    // {
    //   this.router.navigate(['/login']); // Auth Guard can be used here to redirect user who dont have permiession to access
    // }

    this.getMovieList();
  } 

  getMovieList()
  {
   
    var data=  this.movieService.getMovies()
    .subscribe((res)=>{this.Success(res)},(err)=>{this.Error(err)});
  }
 

  Error(res) {
    //alert('eror');
    console.log("err");
  }
  Success(res:MovieList) {
    //alert('succs');
    console.log(res.movies);
   this.movies=res.movies;
  }

}
