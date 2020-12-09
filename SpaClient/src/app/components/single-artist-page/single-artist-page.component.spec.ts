import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleArtistPageComponent } from './single-artist-page.component';

describe('SingleArtistPageComponent', () => {
  let component: SingleArtistPageComponent;
  let fixture: ComponentFixture<SingleArtistPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingleArtistPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleArtistPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
