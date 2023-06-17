import { Component, OnInit, ViewChild } from '@angular/core';
import { InicioService } from './inicio.service';
import { TableVirtualScrollDataSource } from 'ng-table-virtual-scroll';
import { MatSort } from '@angular/material/sort';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css'],
})

export class InicioComponent implements OnInit {
  displayedColumns: string[] = ['id', 'estacion','sentido','hora','categoria','cantidad','valorTabulado'];
  dataSource:any;
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  constructor(public inicioService: InicioService) { }
  ngOnInit(): void {
    this.inicioService.getRecaudos().subscribe(data => {
      this.dataSource = new MatTableDataSource<any>(data);
      this.dataSource.paginator = this.paginator;
      console.log(this.dataSource);
    });
  }
  filter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}