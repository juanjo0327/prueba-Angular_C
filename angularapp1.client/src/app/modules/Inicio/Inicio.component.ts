import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ProductosServices } from '../services/producto.services';
import { IProducto } from './models/productos';

@Component({
  selector: 'inicio',
  templateUrl: './Inicio.component.html',
  styleUrls: ['./Inicio.component.css']
})


export class InicioComponent {
  productos: IProducto[] = [];

  constructor(
    private productosService: ProductosServices) {
    this.obtenerProductos();
  }

  obtenerProductos() {
    this.productosService.obtenerProductos().subscribe({
      next: (result) => {
        this.productos = result;
      }
    })
  }

  lstDatos: any[] = [
    {
      dato1: "Id",
      dato2: "nombre_Producto",
      dato3: "tipo_Producto",
      dato4: "Descripcion",
      dato5: "Existencia"
    }
  ]
}
