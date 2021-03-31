import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-promedio-ventas',
  templateUrl: './promedio-ventas.component.html',
  styleUrls: ['./promedio-ventas.component.css']
})
export class PromedioVentasComponent implements OnInit {
  @Input() icon: string;
  @Input() title: string;
  @Input() value: number;
  @Input() color: string;
  @Input() isIncrease: boolean;
  @Input() isCurrency: boolean;
  @Input() duration: string;
  @Input() percentValue: number;

  constructor() { }

  ngOnInit() {
  }

}
