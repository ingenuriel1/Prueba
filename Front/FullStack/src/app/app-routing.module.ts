import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
const routes: Routes = [
  { path: 'inicio', loadChildren: () => import('./inicio/inicio.module').then(m => m.InicioModule) },
  { path: 'footer', loadChildren: () => import('./footer/footer.module').then(m => m.FooterModule) },
  { path: 'header', loadChildren: () => import('./header/header.module').then(m => m.HeaderModule) },
  { path: 'reporte', loadChildren: () => import('./reporte/reporte.module').then(m => m.ReporteModule) },
 ];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }