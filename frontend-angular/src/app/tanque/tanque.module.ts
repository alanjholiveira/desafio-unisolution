import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { CardModule } from 'primeng/card';
import { PanelModule } from 'primeng/panel';

import { TanqueListComponent } from './tanque-list/tanque-list.component';
import { TanqueFormComponent } from './tanque-form/tanque-form.component';


@NgModule({
  declarations: [TanqueListComponent, TanqueFormComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    ConfirmDialogModule,
    InputTextModule,
    ToastModule,
    DynamicDialogModule,
    ButtonModule,
    TableModule,
    CardModule,
    PanelModule
  ],
  providers: [
    ConfirmationService,
    MessageService,
  ],
  entryComponents: [
    TanqueFormComponent
  ]
})
export class TanqueModule { }
