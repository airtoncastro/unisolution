import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { TipoProdutoService } from 'src/app/services/tipoProduto.service';

@Component({
  selector: 'app-tipoprodutoform',
  templateUrl: './tipoProdutoForm.component.html'
})
export class TipoProdutoFormComponent {
  id: '';
  tiposProduto = [];
  operacao = 'new';
  tipoProdutoForm: FormGroup;
  // tslint:disable-next-line: max-line-length
  constructor(public dialogRef: MatDialogRef<TipoProdutoFormComponent>, @Inject(MAT_DIALOG_DATA) public data: any,
    // tslint:disable-next-line: align
    private service: TipoProdutoService, private serviceTipoProduto: TipoProdutoService, private builder: FormBuilder,
    // tslint:disable-next-line: align
    public dialog: MatDialog) {
    this.tipoProdutoForm = this.builder.group({
      descricao: [''],
    });

    if (data) {
      this.operacao = 'update';
      this.id = data.id;
      this.tipoProdutoForm.reset(data);
    }
    else {
      this.operacao = 'new';
    }

  }

  public salvar(): void {
    const body = this.tipoProdutoForm.value;
    body.id = this.id;
    const command = this.operacao === 'new' ? this.service.novo(body) : this.service.update(body);
    command.subscribe(() => {
      this.dialogRef.close();
    }, error => this.dialogRef.close());
  }
}
