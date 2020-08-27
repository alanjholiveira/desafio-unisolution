import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { Location } from '@angular/common';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';

import { TanqueService } from '../services/tanque.service'
import { Tanque } from '../model/tanque.model';

@Component({
  selector: 'app-tanque-form',
  templateUrl: './tanque-form.component.html',
  styleUrls: ['./tanque-form.component.scss'],
  providers: [MessageService]
})
export class TanqueFormComponent implements OnInit {

  public tanque: Tanque = new Tanque();
  public form: FormGroup;

  public title: string = 'Cadastro';
  public submitted: boolean = false;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private messageService: MessageService,
    private tanqueService: TanqueService,
    private location: Location,
    private ref: DynamicDialogRef,
    private config: DynamicDialogConfig
  ) { }

  ngOnInit(): void {
    this.construirForm();

    if(this.config.data != null) {
      this.tanqueService.obterTanque(this.config.data.id)
      .subscribe(data => {
        this.form.get('id').setValue(data.id);
        this.tanque = data;
      }, error => console.log(error));
    }

    this.route.params.subscribe( tanque => {
      if (tanque['id']) {
        this.title = "Atualização";
      }
    })
  }

  public construirForm() {
    this.form = this.formBuilder.group({
      id: [null],
      descricao: ['', [Validators.required, Validators.minLength(1)]],
      quantidade: ['', [Validators.required, Validators.minLength(1)]],
      tipoProduto: ['', [Validators.required, Validators.minLength(1)]],
    })
  }

  public onSubmit() {
    this.submitted = true;
    if (this.form.valid) {
      this.salvar(this.form.value)
    } else {
      this.messageService.add({
        severity: 'error',
        detail: 'Campos preenchido incorretamente'
      });
    }
  }

  onCancel(){
    this.submitted = false;
    this.form.reset();
    this.ref.close();
  }

  private salvar(tanque: Tanque) {
    if (!tanque.id) {
      this.tanqueService.store(tanque).subscribe( data => {
        this.messageService.add(
          {
            severity: 'success',
            detail: `Tanque ${data.descricao} Cadastro(a) com Sucesso`
          }
        )
      });
    } else {
      this.tanqueService.update(tanque).subscribe( data => {
        this.messageService.add({
          severity: 'success',
          detail: `Tanque ${data.descricao} Atualizado(a) com sucesso`
        });
      });
    }
  }

}
