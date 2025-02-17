import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
  standalone: false
})
export class HeaderComponent {
  @Output() menuClicked = new EventEmitter<void>();

  toggleSidenav() {
    this.menuClicked.emit();
  }
}
