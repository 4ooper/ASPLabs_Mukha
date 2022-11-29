import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../../@shared/shared.module';
import { ProducersRoutingModule } from './producers-routing.module';
import { CommonModule } from '@angular/common';
import { ProducersComponent } from './producers.component';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [CommonModule, ProducersRoutingModule, SharedModule, ReactiveFormsModule],
  exports: [],
  declarations: [ProducersComponent],
  providers: [],
})
export class ProducerModule { }
