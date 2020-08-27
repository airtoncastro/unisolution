import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { TanqueService } from '../../services/tanque.service';
import { TanqueFormComponent } from '../tanqueForm/tanqueForm.component';

@Component({
  selector: 'app-tanque',
  templateUrl: './tanque.component.html'
})
export class TanqueComponent implements OnInit {
  tanquesList: any[] = [];

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  dataSource = new MatTableDataSource<any>(this.tanquesList);

  displayedColumns: string[] = ['deposito', 'capacidade', 'tipoProdutoDescricao', 'action'];

  constructor(public dialog: MatDialog, private service: TanqueService) { }

  ngOnInit() {
    this.getTanques();
  }

  getTanques() {
    const get = this.service.get().subscribe(response => {
      this.loadTanques(response);
    }, error => {
      console.log(error);
    });
  }

  loadTanques(response) {
    this.tanquesList = response;
    this.dataSource = new MatTableDataSource<any>(this.tanquesList);
    setTimeout(() => { this.dataSource.paginator = this.paginator; }, 0);
  }

  addNew() {
    const config = {
      height: 'auto',
      width: '300px',
      disableClose: true,
    };
    const dialogRef = this.dialog.open(TanqueFormComponent, config);
    dialogRef.afterClosed().subscribe(() => {
      this.getTanques();
    });
  }
  edit(item) {
    const config = {
      height: 'auto',
      width: '300px',
      data: item,
      disableClose: true,
    };
    const dialogRef = this.dialog.open(TanqueFormComponent, config);
    dialogRef.afterClosed().subscribe(() => {
      this.getTanques();
    });
  }
  delete(deposito) {
    this.service.delete(deposito).subscribe(() => this.getTanques());
  }
}
