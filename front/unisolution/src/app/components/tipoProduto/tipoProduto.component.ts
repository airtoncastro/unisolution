import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { TipoProdutoService } from 'src/app/services/tipoProduto.service';
import { TipoProdutoFormComponent } from '../tipoProdutoForm/tipoProdutoForm.component';

@Component({
  selector: 'app-tipoproduto',
  templateUrl: './tipoProduto.component.html',
})
export class TipoProdutoComponent implements OnInit {
  tipoProdutosList: any[] = [];

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  dataSource = new MatTableDataSource<any>(this.tipoProdutosList);

  displayedColumns: string[] = ['id', 'descricao', 'action'];

  constructor(public dialog: MatDialog, private service: TipoProdutoService) { }

  ngOnInit() {
    this.gettipoProdutos();
  }

  gettipoProdutos() {
    const get = this.service.get().subscribe(response => {
      this.loadtipoProdutos(response);
    }, error => {
      console.log(error);
    });
  }

  loadtipoProdutos(response) {
    this.tipoProdutosList = response;
    this.dataSource = new MatTableDataSource<any>(this.tipoProdutosList);
    setTimeout(() => { this.dataSource.paginator = this.paginator; }, 0);
  }

  addNew() {
    const config = {
      height: 'auto',
      width: '300px',
      disableClose: true,
    };
    const dialogRef = this.dialog.open(TipoProdutoFormComponent, config);
    dialogRef.afterClosed().subscribe(() => {
      this.gettipoProdutos();
    });
  }
  edit(item) {
    const config = {
      height: 'auto',
      width: '300px',
      data: item,
      disableClose: true,
    };
    const dialogRef = this.dialog.open(TipoProdutoFormComponent, config);
    dialogRef.afterClosed().subscribe(() => {
      this.gettipoProdutos();
    });
  }
  delete(id) {
    this.service.delete(id).subscribe(() => this.gettipoProdutos());
  }

}
