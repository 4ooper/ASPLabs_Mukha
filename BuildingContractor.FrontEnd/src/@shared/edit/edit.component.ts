import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Component, Input, OnInit, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { Producer } from 'src/app/models/producers';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit, OnChanges {
  @Input() public selectedId: number | undefined;
  @Input() public displayData: Array<any> = [];
  @Input() public visible: boolean = false;
  @Output() public delete: EventEmitter<number> = new EventEmitter();
  @Output() public save: EventEmitter<Producer> = new EventEmitter();
  public form!: FormGroup;
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({});
    this.displayData.forEach(item => {
      this.form.addControl(item.controlName, new FormControl('', Validators.required));
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.form = this.formBuilder.group({});
    this.form.addControl("id", new FormControl(this.selectedId, Validators.required));
    this.displayData.forEach(item => {
      this.form.addControl(item.controlName, new FormControl(item.value, Validators.required));
    });
  }

  public onSave() {
    this.save.emit(this.form.value);
  }

  public onDelete() {
    this.delete.emit(this.form.value['id']);
  }
}
