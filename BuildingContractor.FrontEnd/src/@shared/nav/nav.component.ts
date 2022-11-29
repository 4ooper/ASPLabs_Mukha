import { trigger, state, style, transition, animate } from '@angular/animations';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
  animations: [
    trigger('openClose', [
      state('open', style({
        width: '200px',
        opacity: 1
      })),
      state('closed', style({
        width: '0px',
        opacity: 0
      })),
      transition('closed => open', [
        animate('1s')
      ]),
      transition('* => open', [
        animate('1s')
      ]),
      transition('open => closed', [
        animate('1s')
      ]),
      transition('* => closed', [
        animate('1s')
      ])
    ]),
  ],
})
export class NavComponent implements OnInit {

  public animationState = 'closed';
  public display = 'none';
  constructor() { }

  ngOnInit(): void {
  }

  public togleShow(): void {
    this.animationState = this.animationState === 'open' ? 'closed' : 'open';
    this.display = 'block';
  }

  public done() {
    if(this.animationState === 'closed') {
      this.display = 'none';
    }
  }
}
