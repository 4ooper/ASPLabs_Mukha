import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../../@shared/shared.module';
import { ContractorsRoutingModule } from './contractors-routing.module';
import { ContractorsComponent } from './contractors.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [ContractorsComponent],
  imports: [
    CommonModule,
    ContractorsRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class ContractorsModule { }
