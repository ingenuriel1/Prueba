import { Component, OnInit, ViewChild } from '@angular/core';
import { ReporteService } from './reporte.service';
import { TableVirtualScrollDataSource } from 'ng-table-virtual-scroll';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.css']
})
export class ReporteComponent implements OnInit {
  displayedColumns: string[] = ['id', 'estacion', 'sentido', 'hora', 'categoria', 'cantidad', 'valorTabulado', 'fecha'];
  dataSource: any;
  length = 50;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  hidePageSize = false;
  showPageSizeOptions = true;
  showFirstLastButtons = true;
  disabled = false;
  pageEvent: PageEvent | undefined;
  fechas:any| undefined;
  estaciones:any| undefined;
  Totales:any| undefined;
  estacionDetalle:any| undefined;

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  constructor(public reporteService: ReporteService) { }
  ngOnInit(): void {
    this.reporteService.getRecaudos().subscribe(data => {
      this.dataSource = new MatTableDataSource<any>(data);
      this.dataSource.paginator = this.paginator;
      console.log(this.dataSource);
    });
    this.reporteService.getTotales().subscribe(data => {
      this.Totales = data;
      console.log(data);
    });
    this.reporteService.getFechas().subscribe(data => {
      this.fechas = data;
      console.log(data);
    });
    this.reporteService.getEstaciones().subscribe(data => {
      this.estaciones = data;
      console.log(data);
    });
  }
  filter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  handlePageEvent(e: PageEvent) {
    this.pageEvent = e;
    this.length = e.length;
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
  }
}