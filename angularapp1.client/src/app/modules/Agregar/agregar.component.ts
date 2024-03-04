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
    nombreProducto: undefined,
    Descripcion: undefined,
    Existencia: undefined,
    Precio: undefined,
    TipoProducto_Id: undefined,
  })

  constructor(
    private fb: FormBuilder,
    private productosService: ProductosServices) {
  }

  enviarDatos(form: FormGroup) {
    let producto: IProducto = form.value as IProducto;

    console.log(producto)
    console.log(producto.existencia);
    //if (!isNaN(Number(producto.existencia)) && producto.existencia != null && producto.existencia !== 0)
    //{
      this.productosService.agregarProductos(producto).subscribe({
        next: () => {
          alert("Producto guardado correctamente");
          this.formProducto = this.fb.group({
            idProducto: [''],
            nombreProducto: [''],
            nombreTipoProducto: [''],
            Descripcion: [''],
            Existencia: [''],
            Precio: [''],
            TipoProducto_Id: [''],
          })
        },
        error: (error) => {
          console.error("Error al enviar datos:", error);
        }
      })
    //}
    //else
    //{
      //console.log(producto.precio);
      //alert("Error, existen campos vacios, Favor de proporcionar todos los datos.")
      
    //}
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
      dato5: "Tipo de Producto:", input5: "Teclea el IdTipoProducto"
    }
  ]
}
