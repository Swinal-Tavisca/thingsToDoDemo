import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { Airport } from '../airport.service';
import { DataService } from '../dataService.service';
import { HttpClient } from '@angular/common/http';
import {Inject} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

export interface DialogData {
  phonenumber:number;
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  phonenumber:number;
  value:any;
  response:any;
  panelColor = new FormControl('red');
  airportArea: string = 'InsideOutsideAirport';

  myControl = new FormControl();
  options: string[] = ['Bar', 'Spa', 'Store'];
  filteredOptions: Observable<string[]>;

  type:any;
  location:any;
  arrivalDatetime:any;
  DepartureDateTime:any;
  durationminutes:any;
  arrivalterminal:any;
  departureterminal:any;

  constructor(public airportServices: Airport,private route: ActivatedRoute,private http: HttpClient, public dataService: DataService,public dialog: MatDialog) {}
  
  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value))
    );
  }
  SetReminder(){
    this.http.get('/api/Data/reminder/' + this.phonenumber + '/')
    .subscribe();
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(DialogOverview, {
      width: '250px',
      data: {phonenumber: this.phonenumber}

    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.phonenumber = result;
      console.log(this.phonenumber);
      window.open("https://wa.me/14155238886?text=join%20lemon-mule");
      this.SetReminder();
    });
  }

  setAirportArea(area) {
    this.airportServices.setArea(area);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().indexOf(filterValue) === 0);
  }


  selected = 'outside';
  isExpanded = false;

  check() {
    this.airportServices.setInput(this.value);
     this.location = this.route.snapshot.queryParamMap.get('location');
     this.arrivalDatetime = this.route.snapshot.queryParamMap.get('ArrivalDateTime');
     this.DepartureDateTime = this.route.snapshot.queryParamMap.get('DepartureDateTime');
     this.arrivalterminal = this.route.snapshot.queryParamMap.get('ArrivalTerminal');
     this.departureterminal = this.route.snapshot.queryParamMap.get('DepartureTerminal');
    this.http.get('thingstodoproject-dev.ap-south-1.elasticbeanstalk.com/api/Data/search/'+ this.location +' / ' + this.arrivalDatetime +' / ' +  this.DepartureDateTime +' / ' + this.airportServices.getInput()).
   subscribe((response)=>
   {
     this.response=response;
     this.dataService.response=this.response;
   });
     
    
 
   }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  title = 'ClientApp things ';

}


@Component({
  selector: 'DialogOverview',
  templateUrl: 'DialogOverview.html',
})
export class DialogOverview {

  constructor(
    public dialogRef: MatDialogRef<DialogOverview>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

}
