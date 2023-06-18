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
  fechas =
    [
      { 'fecha': 'fecha1', 'totalCantidad': 'Total C a','totalValor': 'Total C a' },
      { 'fecha': 'fecha2', 'totalCantidad': 'Total C b','totalValor': 'Total C b' },
   
    ]
    fechasTotales =
    [
      { 'estacion':'Estacion1','totalCantidadF': '000000', 'totalValorF': '111111'},
      { 'estacion':'Estacion2','totalCantidadF': '000000', 'totalValorF': '111111'},
      { 'estacion':'Estacion3','totalCantidadF': '000000', 'totalValorF': '111111'},
    ]

    Totales =
    [
      {'totalCantidad':'456','totalValor':'888'},
    ]



  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  constructor(public reporteService: ReporteService) { }
  ngOnInit(): void {
    this.reporteService.getRecaudos().subscribe(data => {
      this.dataSource = new MatTableDataSource<any>(data);
      this.dataSource.paginator = this.paginator;
      console.log(this.dataSource);
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