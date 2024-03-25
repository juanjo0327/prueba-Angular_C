import { Component } from '@angular/core';
import { FormGroup, FormBuilder} from '@angular/forms';
import { IProducto } from '../Inicio/models/productos';
import { ProductosServices } from '../services/producto.services';

@Component({
  selector: 'agregar',
  templateUrl: './agregar.component.html',
  styleUrls: ['./agregar.component.css'],
})
export class AgregarComponent {

  formProducto: FormGroup = this.fb.group({
    nombreProductos: '',
    descripcion: '',
    existencia: undefined,
    precio: undefined,
    tipoProducto_Id: 1,
    nombreTipoProducto: '',
  })

  tipoProductoId: { tipoProducto_Id: number }[] = [];
  nombreTipoProducto: { nombreTipoProducto: any }[] = [{
    nombreTipoProducto
      :
      "Cosas para barrer"
}];

  constructor(
    private fb: FormBuilder,
    private productosService: ProductosServices)
  {
    this.obtenerProductos();
  }

  seleccionarTipoProducto(valorSeleccionado: any) {
    

    if (valorSeleccionado !== null && valorSeleccionado !== undefined) {
      const valorSeleccionado = this.formProducto.get('tipoProducto_Id')?.value;
      this.productosService.obtenerNombreTipoProd(valorSeleccionado).subscribe({
        next: (result) => {
          this.nombreTipoProducto = result;
          console.log(this.nombreTipoProducto);
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


  enviarDatos(form: FormGroup) {
    let producto: IProducto = form.value as IProducto;

    if (producto.nombreProductos != '' && producto.descripcion != ''
      && producto.precio != undefined && producto.existencia != undefined
      && producto.tipoProducto_Id != undefined && producto.precio.toString() != ''
      && producto.existencia.toString() != '' && producto.tipoProducto_Id.toString() != '') {
      if (producto.precio != 0 && producto.existencia != 0 && producto.tipoProducto_Id != 0) {
        this.productosService.agregarProductos(producto).subscribe({
          next: () => {
            alert("Se agrego el producto correctamente!");
            this.formProducto = this.fb.group({
              idProducto: [''],
              nombreProductos: [''],
              descripcion: [''],
              existencia: [''],
              precio: [''],
              tipoProducto_Id: [1],
              nombreTipoProducto: ["Cosas para barrer"],
            })
          },
          error: (error) => {
            console.error("Error al enviar datos:", error);
          }
        })
      }
      else {
        alert("Error, los campos precio, existencia o Tipo de Producto no pueden ir en 0, favor de rectificar");
      }
    }
    else {
      alert("Error, faltan campos por llenar");
    }
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
      dato6: "", input6:"Nombre Tipo Prod"
    }
  ]
}
