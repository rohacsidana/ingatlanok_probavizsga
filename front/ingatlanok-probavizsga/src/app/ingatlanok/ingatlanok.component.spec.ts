import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngatlanokComponent } from './ingatlanok.component';

describe('IngatlanokComponent', () => {
  let component: IngatlanokComponent;
  let fixture: ComponentFixture<IngatlanokComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngatlanokComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IngatlanokComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
