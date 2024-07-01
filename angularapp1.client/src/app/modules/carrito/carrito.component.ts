import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'carritoComponent',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})

export class carritoComponent {

  lstDatos: any[] = [
    {
      dato1: "Id",
      dato2: "nombre_Producto",
      dato3: "nombreTipoProducto",
      dato4: "Descripcion",
      dato5: "Existencia",
      dato6: "precio"
    }
  ]

  formCarrito: FormGroup = this.fb.group({
    cantidad: 3,
  })

  constructor(
    private fb: FormBuilder
  ) { }

  datosProductos: any[] = [
    {
      id: 1,
      nombre: "Escoba",
      descripcion: "Utencilio de limpieza",
      precio: 8,
      src: '../../../assets/AssetsCarrito/Escoba.jpg'
    },
    {
      id: 2,
      nombre: "holaa",
      descripcion: "Utencilio de limpieza",
      precio: 8,
      src: '../../../assets/AssetsCarrito/trapeador.jpg'
    },
    {
      id: 3,
      nombre: "holaa",
      descripcion: "pez",
      precio: 8,
      src: '../../../assets/AssetsCarrito/Escoba.jpg'
    },
    {
      id: 4,
      nombre: "holaa",
      descripcion: "pez",
      precio: 8,
      src: '../../../assets/AssetsCarrito/trapeador.jpg'
    }
  ]

  sumar(elemento: any) {
    const spanElement = document.getElementById(`numero-${elemento.id}`);
    let valorNuevo = parseInt(spanElement?.textContent || "0")
    if (spanElement && valorNuevo) {
      spanElement.textContent = (valorNuevo += 1).toString();
    }
  }

  restar(elemento: any) {
    const spanElement = document.getElementById(`numero-${elemento.id}`);
    let valorNuevo = parseInt(spanElement?.textContent || "0")
    if (valorNuevo == 1) {
      alert("Error")
    } else {
      if (spanElement && valorNuevo) {
        spanElement.textContent = (valorNuevo -= 1).toString();
      }
    }
  }

  agregarCarrito(elemento: any) {
    const cantidadbolsa = document.getElementById('cantidadbolsa');
    const cantidad = document.getElementById(`numero-${elemento.id}`);

    let valorbolsa = parseInt(cantidadbolsa?.textContent || "0")
    let cantidadAgregar = parseInt(cantidad?.textContent || "0")

    if (cantidadbolsa) {
      if (valorbolsa >= 0) {
        cantidadbolsa.textContent = (valorbolsa += cantidadAgregar).toString()
        if (cantidad) {
          cantidad.textContent = (1).toString()
        }
      }
    }

  }
}
