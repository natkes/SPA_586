import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '@auth0/auth0-angular';

@Component({
  selector: 'app-artists-page',
  templateUrl: './artists-page.component.html',
  styleUrls: ['./artists-page.component.css']
})
export class ArtistsPageComponent implements OnInit {

  baseUrl = 'https://spa586db.azurewebsites.net/';
  public artistsSongs: ArtistsSongs[];

  constructor(http: HttpClient, public auth: AuthService) {
    http.get<ArtistsSongs[]>(this.baseUrl + 'api/artists').subscribe(result => {
      this.artistsSongs = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface ArtistsSongs {
  id: number;
  name: string;
}

