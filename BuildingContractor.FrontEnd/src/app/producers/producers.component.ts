import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Producer } from './../models/producers';
import { Page } from 'src/app/models/page';
import { ProducerService } from './../../services/producer.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-producers',
  templateUrl: 'producers.component.html',
  styleUrls: ['producers.component.scss'],
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
  ]
})

export class ProducersComponent implements OnInit {
  public ngxDataTableProperties: any = {
    columns: new Array<any>,
    rows: new Array<Producer>,
    loading: false,
    page: new Page()
  };
  public form!: FormGroup;
  public addAnimationState: string = "close";
  public addVisibility: boolean = false;
  public editVisibility: boolean = false;
  public selectedProducer!: Producer
  public selectedId: number | undefined;
  constructor(private producerService: ProducerService, public router: Router, private route: ActivatedRoute, private formBuilder: FormBuilder) {
    this.ngxDataTableProperties.page.pageNumber = 1;
    this.ngxDataTableProperties.page.size = 15;
  }

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      switch (params['type']) {
        case 'add':
          this.generateAddForm();
          break;
        case 'edit':
          this.generateEditForm();
          break;
        default:
          this.router.navigate(['producers']);
      }
      this.addVisibility = params["type"] == 'add';
      this.editVisibility = params["type"] == 'edit';
    })
   }


  public setPage(event: any) {
   this.ngxDataTableProperties.loading = true;
    this.producerService.GetAll(event).subscribe(pagedData => {
      this.generateColumns(Object.keys(pagedData.data[0]));
      this.ngxDataTableProperties.page = pagedData.page;
      this.ngxDataTableProperties.rows = pagedData.data;
      this.ngxDataTableProperties.loading = false;
    });
  }

  public Create() {
    this.producerService.Create(this.form.value).subscribe(data => {
      this.router.navigate(['producers']);
    });
  }

  public getOne(id: number) {
    this.producerService.Get(id).subscribe(data => {
      this.selectedProducer = data;
      this.router.navigate(['producers'], {queryParams: {type: 'edit'}})
    })
  }

  public Delete() {
    this.producerService.Delete(this.selectedProducer.id).subscribe(data => {
      this.setPage(0);
      this.router.navigate(['producers']);
    });
  }

  public Update() {
    let producer = new Producer(this.selectedProducer.id, this.form.value['name']);
    this.producerService.Update(producer).subscribe(data => {
      this.setPage(0);
      this.router.navigate(['producers']);
    });
  }

  public checkClick(event: Event) {
    const target = event.target as HTMLElement;
    if(target.classList.contains('add-background')) {
      this.closeAdd();
    }
    if(target.classList.contains('edit-background')) {
      this.closeEdit();
    }
  }

  private generateColumns(columns: Array<string>) {
    this.ngxDataTableProperties.columns = [];
    columns.forEach(item => {
      this.ngxDataTableProperties.columns.push({name: item.toUpperCase()})
    });
  }

  private generateAddForm() {
    this.addVisibility = true;
    this.addAnimationState = "open";
    this.form = this.formBuilder.group({
        "name" : ['', [Validators.required, Validators.maxLength(100)]]
    });
  }

  private generateEditForm() {
    if(this.selectedProducer == undefined) {
      this.closeEdit();
    }
    else {
      this.editVisibility = true;
      this.form = this.formBuilder.group({
        "name" : [this.selectedProducer.name, [Validators.required, Validators.maxLength(100)]]
      });
    }
  }

  private closeAdd() {
    this.addAnimationState = 'close';
    this.addVisibility = false;
    this.router.navigate(['producers']);
  }

  private closeEdit() {
    this.editVisibility = false;
    this.router.navigate(['producers']);
  }
}
