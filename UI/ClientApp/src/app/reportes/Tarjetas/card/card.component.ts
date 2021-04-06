import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {
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
export interface ICard{
  icon: string;
  title: string;
  value: number;
  color: string;
  isIncrease: boolean;
  isCurrency: boolean;
  duration: string;
  percentValue: number;
}
export interface ICards{
  card:ICard[]
}
