import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
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
  isEdit: boolean = false;
  countryForm: FormGroup;

  // We use this trigger because fetching the list of persons can be quite long,
  // thus we ensure the data is fetched before rendering
  dtTrigger: Subject<any> = new Subject<any>();

  //@ViewChild('verticallyCenteredModal') public verticallyCenteredModal: ModalToggleDirective ;

  constructor(private http: HttpService , private fb: FormBuilder) {
    this.countryForm = this.fb.group({
      name: ['',[Validators.required,Validators.maxLength(20),Validators.minLength(5)]],
      code: ['',[Validators.required,Validators.maxLength(3),Validators.minLength(3)]],
      remarks: [''],
    })
  }
  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }
  ngOnInit(): void {
    this.LoadData();
    };

  LoadData() {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
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
  }

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
    onSubmit(modalId:any):void{
      const localmodalId = modalId;
        if(this.countryForm.valid){
          console.log(this.countryForm.value);
          this.http.post('api/v1/country',this.countryForm.value).subscribe(x=>{
            console.log("Hello");
            localmodalId.visible = false;
            //this.dtTrigger.unsubscribe();
            this.LoadData();
          });
        }
    }

    edit(modalId:any, person:any):void {
      this.isEdit = true;
      const localmodalId = modalId;
      console.log(person.id)
      this.http
        .getById('api/v1/country',person.id)
        .subscribe(res => {
          
        });
        localmodalId.visible = true;
    }
  

  }

