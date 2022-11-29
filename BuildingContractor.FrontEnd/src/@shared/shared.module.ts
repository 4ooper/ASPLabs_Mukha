import { EditComponent } from './edit/edit.component';
import { CommonModule } from '@angular/common';
import { AddComponent } from './add/add.component';
import { MatTableModule } from '@angular/material/table';
import { TableComponent } from './table/table.component';
import { NavComponent } from './nav/nav.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { NgModule } from '@angular/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon'
import { ReactiveFormsModule } from '@angular/forms';

const components = [
          HeaderComponent,
          FooterComponent,
          NavComponent,
          TableComponent,
          AddComponent,
          EditComponent
      ]

@NgModule({
  imports: [MatTableModule, NgxDatatableModule, MatSidenavModule, MatToolbarModule, MatIconModule, CommonModule, ReactiveFormsModule],
  exports: components,
  declarations: components,
  providers: [],
})
export class SharedModule { }
