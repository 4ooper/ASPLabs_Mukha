import { AddComponent } from './../@shared/add/add.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'main',
    loadChildren: () => import('../app/main/main.module').then((m) => m.MainModule)
  },
  {
    path: 'contractorMaterials',
    loadChildren: () => import('../app/contractor-materials/contractor-materials.module').then((m) => m.ContractorMaterialsModule)
  },
  {
    path: 'producers',
    loadChildren: () => import('../app/producers/producers.module').then((m) => m.ProducerModule),
  },
  {
    path: 'contractors',
    loadChildren: () => import('../app/contractors/contractors.module').then((m) => m.ContractorsModule)
  },
  { path: '**', redirectTo: 'main' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
