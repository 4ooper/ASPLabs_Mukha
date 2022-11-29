import { ProducerService } from './../../services/producer.service';
import { trigger, state, style, animate, transition } from '@angular/animations';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ContractorMaterialService } from './../../services/conctractor-material.service';
import { ContractorMaterial } from './../models/contractorMaterials';
import { Page } from 'src/app/models/page';
import { Component, OnInit } from '@angular/core';
import { Producer } from '../models/producers';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-contractor-materials',
  templateUrl: './contractor-materials.component.html',
  styleUrls: ['./contractor-materials.component.scss'],
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
export class ContractorMaterialsComponent implements OnInit {

  public ngxDataTableProperties: any = {
    columns: new Array<any>,
    rows: new Array<ContractorMaterial>,
    loading: false,
    page: new Page()
  };
  public selectedItem!: ContractorMaterial;
  public ColumnMode = ColumnMode;
  public SelectionType = SelectionType;
  public selected = new Array<any>;
  public addVisibility: boolean = false;
  public editVisibility: boolean = false;
  public addAnimationState: string = "close";
  public form!: FormGroup;
  public searchProducers: Array<Producer> = [];
  public AddSelectedProducer: Producer | undefined;
  public EditSelectedProducer: Producer | undefined;

  constructor(private materialService: ContractorMaterialService, private router: Router, private route: ActivatedRoute, private formBuilder:FormBuilder, private producerService: ProducerService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      switch (params['type']) {
        case 'add':
          this.generateAddForm();
          break;
        case 'edit':
          this.generateEditForm();
          break;
        default:
          this.addVisibility = false;
          this.editVisibility = false;
          this.router.navigate(['contractorMaterials']);
      }
      this.setPage({ offset: 0 });
    });
    this.setPage({ offset: 0 });
  }

  public setPage(event: any) {
    this.ngxDataTableProperties.loading = true;
     this.materialService.GetAll(event.offset).subscribe(pagedData => {
       this.generateColumns(Object.keys(pagedData.data[0]));
       this.ngxDataTableProperties.page = pagedData.page;
       this.ngxDataTableProperties.rows = pagedData.data;
       this.ngxDataTableProperties.loading = false;
     });
   }

   public selectProducer(item: Producer) {
    this.AddSelectedProducer = item;
   }

   public getOne(id: number) {
    this.materialService.Get(id).subscribe(data => {
      this.selectedItem = data;
      this.router.navigate(['contractorMaterials'], {queryParams: {type: 'edit'}});
    });
  }

  public Create() {
    this.materialService.Create({...this.form.value, producer: { ...this.AddSelectedProducer } }).subscribe(data => {
      this.router.navigate(['contractorMaterials']);
    });
  }

  public checkClick(event: Event) {
    const target = event.target as HTMLElement;
    if (target.classList.contains('add-background')) {
      this.closeAdd();
    }
    if(target.classList.contains('edit-background')) {
      this.closeEdit();
    }
  }

  public onSelect(event: any) {
    if(this.selected[0] != undefined) {
      this.getOne(this.selected[0].id)
    }
    this.selected = new Array<any>;
  }

  public onSort(event: any) {

  }

  public toShortDate(value: string) {
    return value.split('T')[0];
  }

  public displayWith(value: any) : string {
    return value.name;
  }

  public selectionChange(value : any) {
    this.AddSelectedProducer = value.source.value;
  }

  public onInputProducer(value: string) {
    this.AddSelectedProducer = undefined;
    if(value.length > 2) {
      this.producerService.GetListSearch(value).subscribe(data => {
        this.searchProducers = data.producers;
      });
    }
    else {
      this.searchProducers = [];
    }
  }

  public Update() {
    let materials = {id: this.selectedItem.id, ...this.form.value, producer: {...this.AddSelectedProducer}};
    this.materialService.Update(materials).subscribe(data => {
      this.router.navigate(['contractorMaterials']);
    })
  }


  public Delete() {
    this.materialService.Delete(this.selectedItem.id).subscribe(data => {
      this.router.navigate(['contractorMaterials'])
    })
  }

   private generateColumns(columns: Array<string>) {
    this.ngxDataTableProperties.columns = [];
    columns.forEach(item => {
      this.ngxDataTableProperties.columns.push({name: item, prop: item});
    });
  }

  private closeAdd() {
    this.addAnimationState = 'close';
    this.addVisibility = false;
    this.router.navigate(['contractorMaterials']);
  }

  private closeEdit() {
    this.editVisibility = false;
    this.router.navigate(['contractorMaterials']);
  }

  private generateAddForm() {
    this.addVisibility = true;
    this.addAnimationState = "open";
    this.form = this.formBuilder.group({
        "name" : ['', [Validators.required, Validators.maxLength(100)]],
        "createdDate" : ['', [Validators.required]],
        "validaty": ['', [Validators.required]]
    });
  }

  private generateEditForm() {
    this.editVisibility = true;
    this.form = this.formBuilder.group({
        "name" : [this.selectedItem?.name, [Validators.required, Validators.maxLength(100)]],
        "createdDate" : [formatDate(new Date(this.selectedItem.createdDate), "yyyy-MM-dd", "en"), [Validators.required]],
        "validaty": [formatDate(new Date(this.selectedItem.validaty), "yyyy-MM-dd", "en"), [Validators.required]]
    });
    this.AddSelectedProducer = this.selectedItem.producer;
  }
}
