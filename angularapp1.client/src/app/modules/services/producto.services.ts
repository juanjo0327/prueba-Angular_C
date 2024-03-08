import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, observable, Observable } from "rxjs";
import { enviroment } from "../../enviroments/enviroments";
import { MyResponse } from "../../interfaces";
import { IProducto } from "../Inicio/models/productos";


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
}

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
  //Aqui se consume el endPointhttps://localhost:7206/api/productos
  obtenerProductos(): Observable<IProducto[]> {
    let url = `${this.api}/productos`;

    return this.http.get<IProducto[]>(url).pipe(
      catchError((error: any) => {
        console.error("Error al obtener productos:", error);
        throw error;
      })
    );
  }

  //agregar Productos
  //Aqui consule el endPoint: https://localhost:7206/api/productos/agregar
  agregarProductos(producto: IProducto) {
    let url = `${this.api}/productos/agregar`;
    return this.http.post(url, {
      ...producto
    })
  }

  //busqueda Productos
  //Aqui se consume el endPoint: https://localhost:7206/api/productos/busquedaProductos?valor=${valor}
  busquedaProducto(id: number, valor: string): Observable<any> {
    let url = `${this.api}/busquedaProductos?id=${id}&valor=${valor}`;
    return this.http.get(url);
  }

  //obtener Datos del Producto para la pantalla modificarProducto
  //Aqui se consume el endPoint: https://localhost:7206/api/productos/obtenerDatos?id={id}
  obtenerDatosProducto(id: number): Observable<any> {
    let url = `${this.api}/obtenerDatos?id=${id}`;
    return this.http.get(url);
  }

  //eliminar Producto
  //Aqui se consume el endPoint: https://localhost:7206/api/productos/eliminarProducto?id={id}
  eliminarProducto(id: number): Observable<any> {
    let url = `${this.api}/eliminarProducto?id=${id}`
    return this.http.post(url, id);
  }


}
