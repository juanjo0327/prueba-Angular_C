import { Component } from '@angular/core';

@Component({
  selector: 'agregar',
  templateUrl: './agregar.component.html',
  styleUrls: ['./agregar.component.css'],
})
export class AgregarComponent {
  lstDatos: any[] = [
    {
      dato1: "Nombre:", input1: "Teclea el Nombre",
      dato2: "Descripción:", input2: "Teclea la Descripción",
      dato3: "Precio:", input3: "Teclea el Precio",
      dato4: "Existencia:", input4: "Teclea la Existencia",
      dato5: "Tipo de Producto:", input5: "Teclea el Tipo Producto"
    }
  ]
}
