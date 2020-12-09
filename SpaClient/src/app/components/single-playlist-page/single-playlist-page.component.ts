import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '@auth0/auth0-angular';
import { ActivatedRoute } from '@angular/router';
import {FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-single-playlist-page',
  templateUrl: './single-playlist-page.component.html',
  styleUrls: ['./single-playlist-page.component.css']
})
export class SinglePlaylistPageComponent implements OnInit {

  baseUrl = 'https://spa586db.azurewebsites.net/';
  public playlist: Playlist;
  id: number;
  private sub: any;

  constructor(http: HttpClient, public auth: AuthService, private route: ActivatedRoute, private formBuilder: FormBuilder) {
    this.sub = this.route.paramMap.subscribe(params => {
      this.id = +params.get('id');
    });
    http.get<Playlist>(this.baseUrl + 'api/playlistswithsongs/' + this.id).subscribe(result => {
      this.playlist = result;
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


interface Playlist {
  id: number;
  name: string;
  songs: Songs[];
}
