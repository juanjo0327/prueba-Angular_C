import { Component } from '@angular/core';
import { IProducto } from '../Inicio/models/productos';
import { ProductosServices } from '../services/producto.services';

@Component({
  selector: 'modificar',
  templateUrl: './modificar.component.html',
  styleUrls: ['./modificar.component.css']
})
export class ModificarComponent {

  busqueda: string = '';
  productos: IProducto[] = [];
  constructor(
    private productosService: ProductosServices) {
      this.buscarEnTiempoReal();
    }

  buscarEnTiempoReal() {
    this.productosService.busquedaProducto(this.busqueda).subscribe({
      next: (result) => {
        this.productos = result;
      }
    })

  }
}
