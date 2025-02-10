import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SolicitudService } from 'src/app/service/solicitud.service';

@Component({
  selector: 'app-form-edit',
  templateUrl: './form-edit.component.html',
  styleUrls: ['./form-edit.component.css']
})
export class FormEditComponent {
  formId: string | null = '';
  form: any = { name: '', description: '' };

  constructor(
    private solicitudService: SolicitudService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.formId = this.route.snapshot.paramMap.get('id');
    if (this.formId) {
      this.getForm();
    }
  }

  getForm(): void {
    this.solicitudService.getForm(this.formId).subscribe(data => {
      this.form = data;
    });
  }

  saveForm(): void {
    if (this.formId) {
      this.solicitudService.updateForm(this.form).subscribe();
    } else {
      this.solicitudService.createForm(this.form).subscribe();
    }
  }
}
