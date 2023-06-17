import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InicioRoutingModule } from './inicio-routing.module';
import { InicioComponent } from './inicio.component';
import { MatTableModule } from  '@angular/material/table';
import { MatPaginatorModule } from  '@angular/material/paginator';

@NgModule({
  declarations: [
    InicioComponent
  ],
  imports: [
    CommonModule,
    InicioRoutingModule,
    MatTableModule,
    MatPaginatorModule
  ],
  exports:[InicioComponent],
})
export class InicioModule { }
