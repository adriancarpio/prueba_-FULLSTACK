import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SolicitudService } from 'src/app/service/solicitud.service';

@Component({
  selector: 'app-form-input-list',
  templateUrl: './form-input-list.component.html',
  styleUrls: ['./form-input-list.component.css']
})
export class FormInputListComponent {
  formId: string | null = '';
  input: any;

  constructor(
    private solicitudService: SolicitudService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.formId = this.route.snapshot.paramMap.get('formId');
    if (this.formId) {
      this.getInputs();
    }
  }

  getInputs(): void {
    this.solicitudService.getInput(this.formId).subscribe(data => {
      this.input = data.resultado;
    });
  }

}
