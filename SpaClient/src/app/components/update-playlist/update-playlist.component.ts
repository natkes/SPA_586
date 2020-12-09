import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '@auth0/auth0-angular';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-playlist',
  templateUrl: './update-playlist.component.html',
  styleUrls: ['./update-playlist.component.css']
})
export class UpdatePlaylistComponent implements OnInit {


  baseUrl = 'https://spa586db.azurewebsites.net/';
  public playlist: Playlist;
  id: number;
  private sub: any;
  public  songs: Song[];
  addSongsForm;
  httpG: HttpClient;
  public songToAdd: Link;
  router: Router;

  constructor(http: HttpClient, public auth: AuthService, private route: ActivatedRoute, router: Router) {
    this.sub = this.route.paramMap.subscribe(params => {
      this.id = +params.get('id');
      http.get<Playlist>(this.baseUrl + 'api/playlistswithsongs/' + this.id).subscribe(result => {
        this.playlist = result;
      }, error => console.error(error));
    });
    http.get<Song[]>(this.baseUrl + 'api/songsnotinpl/' + this.id).subscribe(result => {
      this.songs = result;
    }, error => console.error(error));
    this.httpG = http;
    this.router = router;
  }

  ngOnInit(): void {
  }
  onAdd(Data): void  {
    this.songToAdd = {
      playlistID: this.id,
        songId: Data
    };
    this.httpG.post<Link>(this.baseUrl + 'api/playlistsonglists', this.songToAdd).subscribe(
      () => {
        this.httpG.get<Song[]>(this.baseUrl + 'api/songsnotinpl/' + this.id).subscribe(result => {
          this.songs = result;
        }, error => console.error(error));
        this.httpG.get<Playlist>(this.baseUrl + 'api/playlistswithsongs/' + this.id).subscribe(result => {
          this.playlist = result;
        }, error => console.error(error));
      });
}
  onDelete(Data): void  {
    this.httpG.delete<Link>(this.baseUrl + 'api/playlistsonglists/' + this.id + '/' + Data).subscribe(
      () => {
        this.httpG.get<Song[]>(this.baseUrl + 'api/songsnotinpl/' + this.id).subscribe(result => {
          this.songs = result;
        }, error => console.error(error));
        this.httpG.get<Playlist>(this.baseUrl + 'api/playlistswithsongs/' + this.id).subscribe(result => {
          this.playlist = result;
        }, error => console.error(error));
      });
  }
}

interface Playlist {
  id: number;
  name: string;
  songs: Song[];
}

interface Song {
  id: number;
  name: string;
  artist_Name: string;
  year: number;
}
interface Link {
  playlistID: number;
  songId: number;
}
