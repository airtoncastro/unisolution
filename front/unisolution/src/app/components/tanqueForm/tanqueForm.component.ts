import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { TanqueService } from 'src/app/services/tanque.service';
import { TipoProdutoService } from '../../services/tipoProduto.service';
import { TipoProdutoComponent } from '../tipoProduto/tipoProduto.component';

@Component({
    selector: 'app-tanqueform',
    templateUrl: './tanqueForm.component.html'
})
export class TanqueFormComponent {
    deposito: '';
    tiposProduto = [];
    operacao = 'new';
    tanqueForm: FormGroup;
    // tslint:disable-next-line: max-line-length
    constructor(public dialogRef: MatDialogRef<TanqueFormComponent>, @Inject(MAT_DIALOG_DATA) public data: any,
        // tslint:disable-next-line: align
        private service: TanqueService, private serviceTipoProduto: TipoProdutoService, private builder: FormBuilder,
        // tslint:disable-next-line: align
        public dialog: MatDialog) {
        this.tanqueForm = this.builder.group({
            deposito: [''],
            capacidade: [''],
            tipoProduto: ['']
        });
        this.getTiposProduto();

        if (data) {
            this.service.getByDeposito(data).subscribe((tanque: any) => {
                if (tanque) {
                    this.operacao = 'update';
                    this.deposito = tanque.deposito;
                    this.tanqueForm.reset(tanque);
                }
                else {
                    this.operacao = 'new';
                }
            });

        }
    }

    getTiposProduto() {
        this.serviceTipoProduto.get().subscribe(response => {
            this.tiposProduto = response;
        });
    }

    public salvar(): void {
        const body = this.tanqueForm.value;
        const command = this.operacao === 'new' ? this.service.novo(body) : this.service.update(body);
        command.subscribe(() => {
            this.dialogRef.close();
        }, error => this.dialogRef.close());
    }
    addNew() {
        const config = {
            height: 'auto',
            width: '600px',
        };
        const dialogRef = this.dialog.open(TipoProdutoComponent, config);
        dialogRef.afterClosed().subscribe(() => {
            this.getTiposProduto();
        });
    }
}
