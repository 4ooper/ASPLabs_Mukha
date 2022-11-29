import { ContractorMaterialsComponent } from './contractor-materials.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: ContractorMaterialsComponent },
  { path: '**', component: ContractorMaterialsComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ContractorMaterialRoutingModule {}
