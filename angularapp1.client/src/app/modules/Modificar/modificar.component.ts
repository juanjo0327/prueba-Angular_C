import { Component } from '@angular/core';
import { IProducto } from '../Inicio/models/productos';
import { ProductosServices } from '../services/producto.services';

@Component({
  selector: 'modificar',
  templateUrl: './modificar.component.html',
  styleUrls: ['./modificar.component.css']
})
export class ModificarComponent {

  busquedaNombre: string = '0';
  busquedaId: number = 0;
  productos: IProducto[] = [];
  constructor(
    private productosService: ProductosServices) {
      this.buscarEnTiempoReal();
    }

  buscarEnTiempoReal() {
    this.productosService.busquedaProducto(this.busquedaId, this.busquedaNombre).subscribe({
      next: (result) => {
        this.productos = result;
      }
    })
  }

  validarSoloDigitos(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    inputElement.value = inputElement.value.replace(/\D/g, ''); // Remover caracteres no numéricos
  }

  validarSoloLetras(event: Event) {
    const inputElement = event.target as HTMLInputElement;
    inputElement.value = inputElement.value.replace(/[^a-zA-Z\s]/g, ''); // Remover caracteres que no son letras
  }
}
