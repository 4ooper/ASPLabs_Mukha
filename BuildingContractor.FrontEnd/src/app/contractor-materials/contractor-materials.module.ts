import { ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { SharedModule } from './../../@shared/shared.module';
import { ContractorMaterialRoutingModule } from './contractor-materials.routing.module';
import { ContractorMaterialsComponent } from './contractor-materials.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';



@NgModule({
  declarations: [
    ContractorMaterialsComponent
  ],
  imports: [
    CommonModule,
    ContractorMaterialRoutingModule,
    SharedModule,
    NgxDatatableModule,
    ReactiveFormsModule,
    MatAutocompleteModule
  ]
})
export class ContractorMaterialsModule { }
