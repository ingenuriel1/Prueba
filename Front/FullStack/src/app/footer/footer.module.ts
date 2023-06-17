import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FooterRoutingModule } from './footer-routing.module';
import { FooterComponent } from './footer.component';
import { ReactiveFormsModule, FormsModule  } from "@angular/forms";


@NgModule({
  declarations: [
    FooterComponent
  ],
  imports: [
    CommonModule,
    FooterRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports:[FooterComponent]
})
export class FooterModule { }
