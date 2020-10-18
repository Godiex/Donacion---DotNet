import { Component, OnInit } from '@angular/core';
import { Persona } from '../../Modelos/Persona/persona';
import { PersonaService } from '../../Servicios/persona.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {
  persona : Persona = new Persona();
  fecha = Date.now();

  constructor(private personaService : PersonaService) { }

  ngOnInit(): void {
  }
  agregarPersona(){
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert('Persona creada!');
        this.persona = p;
      }
      else
      {
        alert("error diego");
      }
    });
  }

}
