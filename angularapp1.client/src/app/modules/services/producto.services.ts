import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable } from "rxjs";
import { enviroment } from "../../enviroments/enviroments";
import { IProducto } from "../Inicio/models/productos";



@Injectable({
  providedIn: 'root'
})

export class ProductosServices {
  //Se creo el proceso de obtener Productos
  api: string = '';

  constructor(private http: HttpClient) {
    this.api = enviroment.tiendaApiUrl;
  }

  //obtener Productos
  //Aqui se consume la url de la api https://localhost:7206/api
  obtenerProductos(): Observable<IProducto[]> {
    let url = `${this.api}/productos`;

    return this.http.get<IProducto[]>(url).pipe(
      catchError((error: any) => {
        console.error("Error al obtener productos:", error);
        throw error;
      })
    );
  }
}
