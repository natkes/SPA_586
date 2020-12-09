import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';

import {AuthModule} from '@auth0/auth0-angular';
import {environment as env} from '../environments/environment';
import { LoginButtonComponent } from './components/login-button/login-button.component';
import { LogoutButtonComponent } from './components/logout-button/logout-button.component';
import { ArtistsPageComponent } from './components/artists-page/artists-page.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SingleArtistPageComponent } from './components/single-artist-page/single-artist-page.component';
import { PlaylistsPageComponent } from './components/playlists-page/playlists-page.component';
import { SinglePlaylistPageComponent } from './components/single-playlist-page/single-playlist-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { AddArtistPageComponent } from './components/add-artist-page/add-artist-page.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AddSongPageComponent } from './components/add-song-page/add-song-page.component';
import { SongsPageComponent } from './components/songs-page/songs-page.component';
import { AddPlaylistComponent } from './components/add-playlist/add-playlist.component';
import { UpdatePlaylistComponent } from './components/update-playlist/update-playlist.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginButtonComponent,
    LogoutButtonComponent,
    ArtistsPageComponent,
    NavigationComponent,
    SingleArtistPageComponent,
    PlaylistsPageComponent,
    SinglePlaylistPageComponent,
    HomePageComponent,
    AddArtistPageComponent,
    AddSongPageComponent,
    SongsPageComponent,
    AddPlaylistComponent,
    UpdatePlaylistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AuthModule.forRoot({...env.auth}),
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
