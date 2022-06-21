import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subject } from 'rxjs';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { HttpService } from '../../../../core/services/http.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  persons: country[] = [];

  countryForm: FormGroup | undefined;

  initializeForm(country?: country) {
    this.countryForm = new FormGroup({
      operatorId: new FormControl(country?.id || 0),
      operatorCode: new FormControl(country?.name),
      operatorName: new FormControl(country?.code),
      mobile: new FormControl(country?.remarks)
    });
  }


  // We use this trigger because fetching the list of persons can be quite long,
  // thus we ensure the data is fetched before rendering
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private http: HttpService ) {}
  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }
  ngOnInit(): void {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching:false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
        .get(
          'api/v1/country/all'
        ).subscribe(resp => {
          that.persons = resp as country[];
          this.dtTrigger.next(that.persons);
          callback({
            recordsTotal: that.persons.length,
            recordsFiltered: that.persons.length,
            data: []
          });
        });
      },
    };
    };

    // save(event) {
    //   const result = event.validationGroup.validate();
    //   if (result.isValid) {
    //     this.http.post(this.countryForm.value, 'Operator/Save').pipe(untilDestroyed(this), loader$)
    //     .subscribe(() => {
    //       this.loadIndicatorVisible = false;
    //       this.loadData('');
    //       this.largeModal.hide();
    //     },
    //     (error) => {
    //       this.loadIndicatorVisible = false;
    //     });
    //   } else {
    //     event.event.preventDefault();
    //   }
    // }




  }

