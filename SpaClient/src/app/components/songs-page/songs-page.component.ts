import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '@auth0/auth0-angular';

@Component({
  selector: 'app-songs-page',
  templateUrl: './songs-page.component.html',
  styleUrls: ['./songs-page.component.css']
})

export class SongsPageComponent implements OnInit {

  baseUrl = 'https://spa586db.azurewebsites.net/';
  public songs: Songs[];

  constructor(http: HttpClient, public auth: AuthService) {
    http.get<Songs[]>(this.baseUrl + 'api/songswithartists').subscribe(result => {
      this.songs = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface Songs {
  id: number;
  name: string;
  artist_Name: string;
  year: number;
}
