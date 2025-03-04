import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SavedCitiesComponent } from './saved-cities.component';

describe('SavedCitiesComponent', () => {
  let component: SavedCitiesComponent;
  let fixture: ComponentFixture<SavedCitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SavedCitiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SavedCitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
