import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '@auth0/auth0-angular';

@Component({
  selector: 'app-playlists-page',
  templateUrl: './playlists-page.component.html',
  styleUrls: ['./playlists-page.component.css']
})
export class PlaylistsPageComponent implements OnInit {

  baseUrl = 'https://localhost:44372/';
  public playlistsSongs: PlaylistsSongs[];
  isVisible = false;

  constructor(http: HttpClient, public auth: AuthService) {
    http.get<PlaylistsSongs[]>(this.baseUrl + 'api/playlistswithsongs').subscribe(result => {
      this.playlistsSongs = result;
    }, error => console.error(error));
  }


  ngOnInit(): void {
  }

}
interface PlaylistsSongs {
  id: number;
  name: string;
  songs: string[];
}

