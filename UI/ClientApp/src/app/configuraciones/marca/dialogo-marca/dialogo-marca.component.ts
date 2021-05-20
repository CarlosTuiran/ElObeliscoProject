import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IMarca } from '../marca.component';
import { MarcaService } from '../marca.service';

@Component({
  selector: 'app-dialogo-marca',
  templateUrl: './dialogo-marca.component.html',
  styleUrls: ['./dialogo-marca.component.css']
})
export class DialogoMarcaComponent implements OnInit {

  constructor(private fb: FormBuilder, private marcaService: MarcaService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService) { }

  modoEdicion: boolean = false;
  idMarca: number;

  formGroup = this.fb.group({
    nombre: ['', [Validators.required]]
  });
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.idMarca = params["id"];
      this.marcaService.getMarca(this.idMarca).subscribe(marca => this.cargarFormulario(marca),
        error => this.alertService.error(error.error));
    });
  }

  cargarFormulario(marca: IMarca) {
    this.formGroup.patchValue({
      nombre: marca.nombre
    });
  }

  save() {
    let marca: IMarca = Object.assign({}, this.formGroup.value);
    console.table(marca);
    if (this.modoEdicion) {
      // edita
      marca.id = this.idMarca;
      this.marcaService.updateMarca(marca)
        .subscribe(marca => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
    } else {
      // crea
      this.marcaService.createMarca(marca)
        .subscribe(marca => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/marcas"]);
    this.alertService.success("Guardado Exitoso");
  }
}
