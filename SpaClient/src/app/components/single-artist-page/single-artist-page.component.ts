import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '@auth0/auth0-angular';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-single-artist-page',
  templateUrl: './single-artist-page.component.html',
  styleUrls: ['./single-artist-page.component.css']
})
export class SingleArtistPageComponent implements OnInit {

  baseUrl = 'https://spa586db.azurewebsites.net/';
  public artist: Artist;
  id: number;
  private sub: any;

  constructor(http: HttpClient, public auth: AuthService, private route: ActivatedRoute) {
    this.sub = this.route.paramMap.subscribe(params => {
      this.id = +params.get('id');
    });
    http.get<Artist>(this.baseUrl + 'api/artistswithsongs/' + this.id).subscribe(result => {
      this.artist = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {

  }

}


interface Artist {
  id: number;
  name: string;
  songs: string[];
}
