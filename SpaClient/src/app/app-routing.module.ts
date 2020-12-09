import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuthGuard} from '@auth0/auth0-angular';
import {ArtistsPageComponent} from './components/artists-page/artists-page.component';
import {SingleArtistPageComponent} from './components/single-artist-page/single-artist-page.component';
import {PlaylistsPageComponent} from './components/playlists-page/playlists-page.component';
import {SinglePlaylistPageComponent} from './components/single-playlist-page/single-playlist-page.component';
import {HomePageComponent} from './components/home-page/home-page.component';
import {AddArtistPageComponent} from './components/add-artist-page/add-artist-page.component';
import {AddSongPageComponent} from './components/add-song-page/add-song-page.component';
import {SongsPageComponent} from './components/songs-page/songs-page.component';
import {AddPlaylistComponent} from './components/add-playlist/add-playlist.component';
import {UpdatePlaylistComponent} from './components/update-playlist/update-playlist.component';

const routes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'artists', component: ArtistsPageComponent, canActivate: [AuthGuard]},
  {path: 'songs', component: SongsPageComponent, canActivate: [AuthGuard]},
  {path: 'playlists', component: PlaylistsPageComponent, canActivate: [AuthGuard]},
  { path: 'artists/:id', component: SingleArtistPageComponent, canActivate: [AuthGuard]},
  { path: 'playlists/:id', component: SinglePlaylistPageComponent, canActivate: [AuthGuard]},
  { path: 'addArtist', component: AddArtistPageComponent, canActivate: [AuthGuard]},
  { path: 'addSong', component: AddSongPageComponent, canActivate: [AuthGuard]},
  { path: 'addPlaylist', component: AddPlaylistComponent, canActivate: [AuthGuard]},
  { path: 'updatePlaylist/:id', component: UpdatePlaylistComponent , canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
