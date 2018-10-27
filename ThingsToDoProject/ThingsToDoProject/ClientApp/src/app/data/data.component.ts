
import { Component, OnInit, Output, EventEmitter, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
// import { HttpClient } from '@angular/common/http';
import { Airport } from '../airport.service';
import { DataService } from '../dataService.service';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.css']
})
export class DataComponent implements OnInit {
  // response: any;
  // type:any;
  // location:any;
  // arrivalDatetime:any;
  // DepartureDateTime:any;
  // durationminutes:any;
  // arrivalterminal:any;
  // departureterminal:any;
  
  @Output() toggle: EventEmitter<null> = new EventEmitter();
  @Output() info: EventEmitter<string> = new EventEmitter<string>();

  @HostListener('click')
  click() {
    this.toggle.emit();
  }

  constructor(public airportServices: Airport,private route: ActivatedRoute, private router: Router ,public dataService: DataService) { 
    // this.type= this.router.url.substring(1,this.router.url.indexOf('?'));
    // this.location = this.route.snapshot.queryParamMap.get('location');
    // this.arrivalDatetime = this.route.snapshot.queryParamMap.get('ArrivalDateTime');
    // this.DepartureDateTime = this.route.snapshot.queryParamMap.get('DepartureDateTime');
    // this.arrivalterminal = this.route.snapshot.queryParamMap.get('ArrivalTerminal');
    // this.departureterminal = this.route.snapshot.queryParamMap.get('DepartureTerminal');
    // console.log(this.durationminutes = this.route.snapshot.queryParamMap.get('DurationMinutes'));
    // console.log(this.arrivalterminal);
    // console.log(this.departureterminal);
}

  ngOnInit() {
    // this.http.get('http://localhost:52216/api/Data/'+ this.airportServices.area + '/' + this.location +'/' + this.arrivalDatetime +'/' +  this.DepartureDateTime +'/' + this.type).
    // subscribe((response)=>
    // {
    //   this.response = response;
    // console.log(response);
    // })
    // this.dataService.response=this.response;
  }

  MoreInfo(placeid: string) {
    this.info.emit(placeid);
  }
}
