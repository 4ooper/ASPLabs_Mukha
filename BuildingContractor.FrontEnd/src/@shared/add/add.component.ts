import { ActivatedRoute, Router } from '@angular/router';
import { trigger, state, style, transition, animate, query } from '@angular/animations';
import { Component, Input, OnInit, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
  animations: [
    trigger('expandedPanel', [
      state('open', style({
        'margin-top': '50px',
        opacity: 1,
      })),
      state('closed', style({
        'margin-top': '-1000px',
        opacity: 0
      })),
      transition('closed => open', [
        animate('0.4s')
      ]),
      transition('* => open', [
        animate('0.4s')
      ]),
      transition('open => closed', [
        animate('0.4s')
      ]),
      transition('* => closed', [
        animate('0.4s')
      ])
    ]),
  ],
})
export class AddComponent implements OnInit, OnChanges {
  @Input() public title: string = "";
  @Input() public displayData: Array<any> = [];
  @Input() public visible: boolean = false;
  @Output() public sendData: EventEmitter<any> = new EventEmitter();
  @Output() public closeEvent: EventEmitter<any> = new EventEmitter();
  public animationState: string = 'closed';
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private route: ActivatedRoute) { }

  public ngOnInit(): void {
    this.form = this.formBuilder.group({});
    this.displayData.forEach(item => {
      this.form.addControl(item.controlName, new FormControl('', Validators.required));
    });
   }

   public ngOnChanges(changes: SimpleChanges): void {
    switch(changes['visible'].currentValue) {
      case true:
        this.animationState = 'open';
        break;
      default:
        this.animationState = 'close';
    }
  }

  public checkData() {
    this.animationState = 'close';
    this.sendData.emit(this.form.value);
    this.resetForm();
  }

  public close() {
    this.animationState = 'close';
    this.closeEvent.emit();
    this.resetForm();
  }

  public togleShow() {
    this.form = this.formBuilder.group({});
    this.displayData.forEach(item => {
      this.form.addControl(item.controlName, new FormControl('', Validators.required));
    });
  }

  public checkClick(event: Event) {
    const target = event.target as HTMLElement;
    if(target.classList.contains('background')) {
      this.close();
    }
  }

  private resetForm() {
    this.form.reset();
  }
}
