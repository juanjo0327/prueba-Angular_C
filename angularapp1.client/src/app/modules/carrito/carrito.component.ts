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
}
