import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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

  formProducto: FormGroup = this.fb.group({
    nombreProductos: undefined,
    descripcion: undefined,
    existencia: undefined,
    precio: undefined,
    nombreTipoProducto: undefined,
    tipoProducto_Id: undefined,
  })
  constructor(
    private route: ActivatedRoute,
    private productosService: ProductosServices,
    private fb: FormBuilder
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
        this.formProducto = this.fb.group({
          nombreProductos: this.productos[0].nombreProductos,
          nombreTipoProducto: this.productos[0].nombreTipoProducto,
          descripcion: this.productos[0].descripcion,
          existencia: this.productos[0].existencia,
          precio: this.productos[0].precio,
          tipoProducto_Id: this.productos[0].tipoProducto_Id,
        })
      }
    })
  }

  modificarProducto(form: FormGroup) {
    let producto: IProducto = form.value as IProducto;
    this.productosService.modificarProducto(producto, this.id).subscribe({
      next: () => {
        alert("Producto modificado correctamente");
      }
    })
  }
  lstDatos: any[] = [
    {
      dato1: "Nombre:", input1: "Teclea el Nombre",
      dato2: "Descripción:", input2: "Teclea la Descripción",
      dato3: "Precio:", input3: "Teclea el Precio",
      dato4: "Existencia:", input4: "Teclea la Existencia",
      dato5: "Tipo de Producto:", input5: "Teclea el IdTipoProducto",
      dato6: "Nombre de TipoProducto:", input6: "Teclea el IdTipoProducto"
    }
  ]
}
