import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-yes-no-buttons',
  imports: [CommonModule],
  templateUrl: './yes-no-buttons.component.html',
  styleUrl: './yes-no-buttons.component.css',
})
export class YesNoButtonsComponent {
  @Input() question: string = '';
  @Input() yesLabel: string = 'Yes?';
  @Input() noLabel: string = 'No?';

  @Output() answer = new EventEmitter<boolean>();

  onYes() {
    this.answer.emit(true);
  }

  onNo() {
    this.answer.emit(false);
  }
}
