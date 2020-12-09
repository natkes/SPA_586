import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {ActivatedRoute} from '@angular/router';


@Component({
  selector: 'app-add-artist-page',
  templateUrl: './add-artist-page.component.html',
  styleUrls: ['./add-artist-page.component.css']
})
export class AddArtistPageComponent implements OnInit {
  baseUrl = 'https://spa586db.azurewebsites.net/';
  createArtistForm;
  httpG: HttpClient;
  router: Router;
  rootUrl: string;
  artist: Artist;

  constructor(private formBuilder: FormBuilder, http: HttpClient, router: Router, root: ActivatedRoute ) {
    this.createArtistForm  = this.formBuilder.group({
      FirstName: null,
      LastName: ''
    });
    this.httpG = http;
    this.router = router;
    this.rootUrl = root.root.toString();
  }

  ngOnInit(): any {
  }
  onSubmit(Data: Artist): void  {
    if (Data.FirstName == null || Data.FirstName.trim() === '')
    {
      alert('First name must be filled');
    }
    else {
      this.createArtistForm.reset();
      this.httpG.post<Artist>(this.baseUrl + 'api/artists', Data).subscribe(result => {
        this.artist = result;
        this.router.navigateByUrl('/artists');
      }, error => console.error(error));
    }
  }

}

interface Artist {
  FirstName: string;
  LastName: string;
}
