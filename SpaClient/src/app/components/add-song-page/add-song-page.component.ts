import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';


@Component({
  selector: 'app-add-song-page',
  templateUrl: './add-song-page.component.html',
  styleUrls: ['./add-song-page.component.css']
})
export class AddSongPageComponent implements OnInit {
  baseUrl = 'https://spa586db.azurewebsites.net/';
  createSongForm;
  httpG: HttpClient;
  artists: Artists[];
  router: Router;
  song: Song;

  constructor(private formBuilder: FormBuilder, http: HttpClient, router: Router ) {
    this.createSongForm  = this.formBuilder.group({
      name: null,
      artistId: null,
      yearCreated: null,
    });
    http.get<Artists[]>(this.baseUrl + 'api/artists').subscribe(result => {
      this.artists = result;
    }, error => console.error(error));
    this.httpG = http;
    this.router = router;
  }

  ngOnInit(): void {
  }
  onSubmit(Data: Song): void  {
    if (Data.name == null || Data.name.trim() === '')
    {
      alert('Song name must be filled');
    }
    else {
      Data.artistId = +Data.artistId;
      this.createSongForm.reset();
      this.httpG.post<Song>(this.baseUrl + 'api/songs', Data).subscribe(result => {
        this.song = result;
        this.router.navigateByUrl('/songs');
      }, error => console.error(error));
    }
  }

}

interface Song {
  name: string;
  artistId: number;
  yearCreated: number;
}

interface Artists {
  id: number;
  name: string;
}
