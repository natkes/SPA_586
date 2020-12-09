import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';


@Component({
  selector: 'app-add-playlist',
  templateUrl: './add-playlist.component.html',
  styleUrls: ['./add-playlist.component.css']
})
export class AddPlaylistComponent implements OnInit {
  baseUrl = 'https://spa586db.azurewebsites.net/';
  createPlaylistForm;
  httpG: HttpClient;
  playlist: Playlist;
  router: Router;

  constructor(private formBuilder: FormBuilder, http: HttpClient, router: Router ) {
    this.createPlaylistForm  = this.formBuilder.group({
      name: null
    });
    this.httpG = http;
    this.router = router;
  }

  ngOnInit(): void {
  }
  onSubmit(Data: Playlist): void  {
    if (Data.name == null || Data.name.trim() === '')
    {
      alert('Playlist name must be filled');
    }
    else {
      this.createPlaylistForm.reset();
      this.httpG.post<Playlist>(this.baseUrl + 'api/playlists', Data).subscribe(result => {
        this.playlist = result;
        this.router.navigateByUrl('/updatePlaylist/' + this.playlist.id);
      }, error => console.error(error));
    }
  }

}

interface Playlist {
  id: number;
  name: string;
}
