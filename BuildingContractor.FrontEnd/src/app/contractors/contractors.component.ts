import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ContractorService } from './../../services/contractor.service';
import { Contractor } from './../models/contractor';
import { Page } from 'src/app/models/page';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contractors',
  templateUrl: './contractors.component.html',
  styleUrls: ['./contractors.component.scss'],
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
export class ContractorsComponent implements OnInit {
  public ngxDataTableProperties: any = {
    columns: new Array<any>,
    rows: new Array<Contractor>,
    loading: false,
    page: new Page()
  };
  public form!: FormGroup;
  public addVisibility: boolean = false;
  public addAnimationState: string = 'close';
  public editVisibility: boolean = false;
  public selectedContractor!: Contractor;
  constructor(private contractorService: ContractorService, private router: Router, private route: ActivatedRoute, private formBuilder: FormBuilder) {
    this.route.queryParams.subscribe(params => {
      switch (params['type']) {
        case 'add':
          this.generateAddForm();
          break;
        case 'edit':
          this.generateEditForm();
          break;
        default:
          this.router.navigate(['contractors']);
      }
      this.addVisibility = params["type"] == 'add';
      this.editVisibility = params["type"] == 'edit';
    })
  }

  ngOnInit(): void { }

  public setPage(event: any) {
    this.ngxDataTableProperties.loading = true;
     this.contractorService.GetAll(event).subscribe(pagedData => {
       this.generateColumns(Object.keys(pagedData.data[0]));
       this.ngxDataTableProperties.page = pagedData.page;
       this.ngxDataTableProperties.rows = pagedData.data;
       this.ngxDataTableProperties.loading = false;
     });
   }

   public getOne(id: number) {
    this.contractorService.Get(id).subscribe(data => {
      this.selectedContractor = data;
      this.router.navigate(['contractors'], {queryParams: {type: 'edit'}})
    })
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

  public Create() {
    this.contractorService.Create(this.form.value).subscribe(data => {
      this.router.navigate(['contractors']);
    });
  }

  public Delete() {
    this.contractorService.Delete(this.selectedContractor.id).subscribe(data => {
      this.setPage(0);
      this.router.navigate(['contractors']);
    });
  }

  public Update() {
    let contractor: Contractor = {id: this.selectedContractor.id, ...this.form.value};
    this.contractorService.Update(contractor).subscribe(data => {
      this.setPage(0);
      this.router.navigate(['contractors']);
    });
  }

  private closeAdd() {
    this.addAnimationState = 'close';
    this.addVisibility = false;
    this.router.navigate(['contractors']);
  }

  private closeEdit() {
    this.editVisibility = false;
    this.router.navigate(['contractors']);
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
    if(this.selectedContractor == undefined) {
      this.closeEdit();
    }
    else {
      this.editVisibility = true;
      this.form = this.formBuilder.group({
        "name" : [this.selectedContractor.name, [Validators.required, Validators.maxLength(100)]]
      });
    }
  }
}
