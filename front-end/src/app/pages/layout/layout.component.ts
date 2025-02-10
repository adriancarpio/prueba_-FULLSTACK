import { Component, OnInit, ViewChild } from '@angular/core';
import { SolicitudService } from 'src/app/service/solicitud.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  forms: any[] = [];

  constructor(
    private solicitudService: SolicitudService, private router: Router){}

  ngOnInit(): void {
    this.getForms();
  }

  getForms(): void {
    this.solicitudService.getForms().subscribe(data => {
      if (data.esValida) {
        this.forms = data.resultado;
      }
    });
  }

  onSelectForm(formId: string): void {
    this.router.navigate(['/form-input-list', formId]);
  }
}
