import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SinglePlaylistPageComponent } from './single-playlist-page.component';

describe('SinglePlaylistPageComponent', () => {
  let component: SinglePlaylistPageComponent;
  let fixture: ComponentFixture<SinglePlaylistPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SinglePlaylistPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SinglePlaylistPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
