import { from } from "rxjs";
import { Donacion } from '../Donacion/donacion';

export class Persona {
    Identificacion : string;
    Nombres : string;
    Apellidos : string;
    Sexo : string;
    Edad : number;
    Ciudad : string;
    Donacion : Donacion = new Donacion();
}
