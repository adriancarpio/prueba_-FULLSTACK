import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SolicitudService } from 'src/app/service/solicitud.service';

@Component({
  selector: 'app-form-input-edit',
  templateUrl: './form-input-edit.component.html',
  styleUrls: ['./form-input-edit.component.css']
})
export class FormInputEditComponent {
  formId: string | null = '';
  inputId: string | null = '';
  input: any = { name: '', type: '' };

  constructor(
    private solicitudService: SolicitudService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.formId = this.route.snapshot.paramMap.get('id');
    this.inputId = this.route.snapshot.paramMap.get('inputId');
    if (this.inputId) {
      this.getInput();
    }
  }

  getInput(): void {
    this.solicitudService.getInput(this.inputId).subscribe(data => {
      this.input = data;
    });
  }

  saveInput(): void {
    if (this.inputId) {
      //this.solicitudService.updateInput(this.inputId, this.input).subscribe();
    } else {
      this.solicitudService.createInput(this.input).subscribe();
    }
    this.router.navigate([`/form-input-list/${this.formId}`]);
  }
}
