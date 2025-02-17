import { Component, ViewChild, Input } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss',
  standalone: false
})
export class NavigationComponent {
   @ViewChild('sidenav') sidenav!: MatSidenav;
   @Input() isMobile!: boolean;
   isOpened = false;
   isCollapsed = true;

   ngOnChanges() {
    if (this.sidenav) {
      if (!this.isMobile) {
        this.isCollapsed = !this.sidenav.opened;
      }
    }
  }

  constructor(private cdr: ChangeDetectorRef) {}

  toggleSidenav() {
    if(this.isMobile){
      this.sidenav.toggle();
      this.isCollapsed = false;
    } else {
      this.sidenav.open();
      this.isCollapsed = !this.isCollapsed;
    }

    this.cdr.detectChanges(); 
  }
}