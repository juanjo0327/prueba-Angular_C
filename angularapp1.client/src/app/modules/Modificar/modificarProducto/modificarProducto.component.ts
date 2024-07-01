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

  tipoProductoId: { tipoProducto_Id: number }[] = [];
  nombreTipoProducto: { nombreTipoProducto: any }[] = [{
    nombreTipoProducto: "Cosas para barrer"
  }];

  constructor(
    private route: ActivatedRoute,
    private productosService: ProductosServices,
    private fb: FormBuilder
  ) {this.obtenerProductos()}

  ngOnInit() {
    this.route.params.subscribe((params: { [x: string]: number; }) => {
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
          tipoProducto_Id: 1,
        })
      }
    })
  }

  modificarProducto(form: FormGroup) {
    let producto: IProducto = form.value as IProducto;

    if (producto.nombreProductos != '' && producto.descripcion != ''
      && producto.precio != undefined && producto.existencia != undefined
      && producto.tipoProducto_Id != undefined && producto.precio.toString() != ''
      && producto.existencia.toString() != '' && producto.tipoProducto_Id.toString() != '') {
      if (producto.precio != 0 && producto.existencia != 0 && producto.tipoProducto_Id != 0) {
        this.productosService.modificarProducto(producto, this.id).subscribe({
          next: () => {
            alert("Producto modificado correctamente");
          }
        })
      } else {
        alert("Error, los campos precio, existencia no pueden ir en 0, favor de rectificar");
      }
    }
    else {
      alert("Error, hay campos vacios");
    }
  }

  seleccionarTipoProducto(valorSeleccionado: any) {
    if (valorSeleccionado !== null && valorSeleccionado !== undefined) {
      const valorSeleccionado = this.formProducto.get('tipoProducto_Id')?.value;
      this.productosService.obtenerNombreTipoProd(valorSeleccionado).subscribe({
        next: (result) => {
          console.log(result);
          this.nombreTipoProducto = result;
        }
      })
    }
  }

  obtenerProductos() {
    this.productosService.obtenerTipoProductoId().subscribe({
      next: (result) => {
        this.tipoProductoId = result;
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

  lstDatos: any[] = [
    {
      dato1: "Nombre:", input1: "Teclea el Nombre",
      dato2: "Descripción:", input2: "Teclea la Descripción",
      dato3: "Precio:", input3: "Teclea el Precio",
      dato4: "Existencia:", input4: "Teclea la Existencia",
      dato5: "Tipo de Producto:", input5: "Teclea el IdTipoProducto",
      dato6: "Nombre TipoProducto:", input6: "Teclea el IdTipoProducto"
    }
  ]
}
