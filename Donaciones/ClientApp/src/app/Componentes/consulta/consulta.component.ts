import { Component, OnInit } from '@angular/core';
import { PersonaService } from '../../Servicios/persona.service';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent implements OnInit {

  constructor(private personaService : PersonaService) { }
  personas = [];
  ngOnInit(): void {
    this.personaService.get().subscribe(result => {
      this.personas = result;
    });
  }

}
