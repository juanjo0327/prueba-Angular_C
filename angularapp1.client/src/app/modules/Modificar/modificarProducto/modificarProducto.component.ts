import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProducto } from '../../Inicio/models/productos';
import { ProductosServices } from '../../services/producto.services';


@Component({
  selector: 'modificarProducto',
  templateUrl: './modificarProducto.component.html',
  styleUrls: ['./modificarProducto.component.css']
})
export class ModificarProducto {
  id: number = 0;
  productos: IProducto[] = [];
  constructor(
    private route: ActivatedRoute,
    private productosService: ProductosServices
  ) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.id = params['id']; // Convierte el parámetro id a número
      this.obtenerDatos(this.id);
    });
  }

  obtenerDatos(id: number) {
    this.productosService.obtenerDatosProducto(this.id).subscribe({
      next: (result) => {
        this.productos = result;
      }
    })
  }
  lstDatos: any[] = [
    {
      dato1: "Nombre:", input1: "Teclea el Nombre",
      dato2: "Descripción:", input2: "Teclea la Descripción",
      dato3: "Precio:", input3: "Teclea el Precio",
      dato4: "Existencia:", input4: "Teclea la Existencia",
      dato5: "Tipo de Producto:", input5: "Teclea el IdTipoProducto"
    }
  ]
}
