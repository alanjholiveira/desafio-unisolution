import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';


import { TanqueService } from '../services/tanque.service';
import { Tanque } from '../model/tanque.model';
import { TanqueFormComponent } from '../tanque-form/tanque-form.component';

@Component({
  selector: 'app-tanque-list',
  templateUrl: './tanque-list.component.html',
  styleUrls: ['./tanque-list.component.scss'],
  providers: [DialogService, MessageService]
})
export class TanqueListComponent implements OnInit {

  tanques: Tanque[];
  ref: DynamicDialogRef;


  constructor(
    private tanqueService: TanqueService,
    private router: Router,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private dialogService: DialogService

  ) { }

  ngOnInit(): void {
    this.listarTanques();
  }

  ngOnDestroy(): void {
    if (this.ref) {
        this.ref.close();
    }
  }

  openForm(): void {
    this.ref = this.dialogService.open(TanqueFormComponent, {
      header: 'Cadastrar Novo Tanque',
      closable: false,
      width: '80%'
    });
  }

  openFormEdit(tanque: Tanque): void {
    this.ref = this.dialogService.open(TanqueFormComponent, {
      data: tanque,
      closable: false,
      header: `Editar Tanque ${tanque.descricao}`,
      width: '80%'
    });

    this.ref.onClose.subscribe(() => {
      this.listarTanques();
    })

  }

  deletar(tanque: Tanque): void {
    this.confirmationService.confirm({
      message: 'Tem certeza que você deseja excluir este registro?',
      header: 'Confirmação de exclusão',
      icon: 'fa fa-trash',
      acceptLabel: "Confirmar",
      rejectLabel: "Cancelar",
      accept: () => {
        this.tanqueService.deletar(tanque.id).subscribe(() => {
          this.removeItemTable(tanque.id);
            this.messageService.add(
              {
                severity:'success',
                detail: `Tanque ${tanque.descricao} removido com sucesso`
              }
            )
          }, err => {
            this.messageService.add({
              severity: 'error',
              detail: `Não e possivel excluir tanque: ${tanque.descricao}`
            });
          }
        );
      },
    });
  }


  private listarTanques() {
    this.tanqueService.listar().subscribe((tanque: Tanque[]) => {
      this.tanques = tanque;
    })
  }

  private removeItemTable(id: number) {
    this.tanques = this.tanques.filter(tanque => tanque.id !== id);
  }

}
