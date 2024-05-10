import { Component } from '@angular/core';

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

  datosProductos: any[] = [
    {
      nombre: "Escoba",
      descripcion: "Utencilio de limpieza",
      precio: 8,
      src: '../../../assets/AssetsCarrito/Escoba.jpg'
    },
    {
      nombre: "holaa",
      descripcion: "Utencilio de limpieza",
      precio: 8,
      src: '../../../assets/AssetsCarrito/trapeador.jpg'
    },
    {
      nombre: "holaa",
      descripcion: "pez",
      precio: 8,
      src: '../../../assets/AssetsCarrito/Escoba.jpg'
    },
    {
      nombre: "holaa",
      descripcion: "pez",
      precio: 8,
      src: '../../../assets/AssetsCarrito/trapeador.jpg'
    }
  ]

  sumar(elemento: any) {
    console.log("Entro a sumar");
  }

  restar(elemento: any) {
    console.log("Entro a restar");
  }
}
