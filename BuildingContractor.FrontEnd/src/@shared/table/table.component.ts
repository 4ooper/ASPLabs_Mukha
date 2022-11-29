import { Producer } from './../../app/models/producers';
import { Page } from './../../app/models/page';
import { ProducerService } from './../../services/producer.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';

const ViewHelper = [
  {
    table_name: "producers",
    displayColumns: ["No", "Name"]
  },
]


@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent implements OnInit {
  @Output() getPage : EventEmitter<any> = new EventEmitter<any>();
  @Input() public page!: Page;
  @Input() public rows: Array<any> = [];
  @Input() public columns: Array<any> = [];
  @Input() public loading!: boolean;
  @Output() select: EventEmitter<number> = new EventEmitter();
  public ColumnMode = ColumnMode;
  public SelectionType = SelectionType;
  public selected = new Array<any>;
  constructor() { }

  ngOnInit(): void {
    this.setPage({ offset: 0 });
  }

  public setPage(pageInfo: any) {
    this.page.pageNumber = pageInfo.offset;
    this.getPage.emit(this.page.pageNumber);
  }

  public onSort(event: any) {
    console.log(event);
  }

  public onSelect(event : any) {
    if(this.selected[0] != undefined) {
      this.select.emit(this.selected[0].id);
    }
    this.selected = new Array<any>;
  }
}
