import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { HttpService } from '../../../../core/services/http.service';
import { ModalDirective }  from 'ngx-bootstrap/modal'
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {
  @ViewChild('largeModal') public largeModal: ModalDirective | undefined;
  @ViewChild('deleteModal') public deleteModal: ModalDirective | undefined;
  @ViewChild(DataTableDirective, {static: false})
  private datatableElement: DataTableDirective | undefined;
  isEdit: boolean = false;
  dtOptions: DataTables.Settings = {};
  persons: country[] = [];
  countryForm: FormGroup;
  dtTrigger: Subject<any> = new Subject<any>();


  constructor(private http: HttpService , private fb: FormBuilder) {
    this.countryForm = this.fb.group({
      id: [''],
      name: ['',[Validators.required,Validators.maxLength(20),Validators.minLength(5)]],
      code: ['',[Validators.required,Validators.maxLength(3),Validators.minLength(3)]],
      remarks: [''],
    })
  }
  ngOnDestroy(): void {

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
            that.persons = (resp as country[]);
            callback({
              recordsTotal: that.persons.length,
              recordsFiltered: that.persons.length,
              data: []
            });
          });
      },
    };

  }

    onSubmit():void{
      this.persons = [];
        if(this.countryForm.valid){
          console.log(this.countryForm.value);
          if(this.isEdit== true){
            this.http.put('api/v1/country',this.countryForm.value,null).subscribe(x=>{
             // localmodalId.visible = false;
             this.largeModal?.hide();
              this.LoadData();
            });
          }
          else{
            this.http.post('api/v1/country',this.countryForm.value).subscribe(x=>{
              this.largeModal?.hide();
              this.rerender();
            });
          }
          
        }
    }
    edit(person:any):void {
      console.log(person.id)
      this.http
        .getById('api/v1/country',person.id)
        .subscribe(res => {
            const countryResponse = res as country;
            this.countryForm.setValue({id : countryResponse.id, name : countryResponse.name, remarks: countryResponse.remarks, code: countryResponse.code});
        });
        this.largeModal?.show();
        this.isEdit = true;
    }

    reset(){
      this.countryForm.reset();
    }
    rerender() {
      this.datatableElement?.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.draw();
      });
    }
  showCreateModal() {
    this.isEdit = false;
     this.countryForm.reset();
    this.largeModal?.show();
  }

  close() {
    this.largeModal?.hide();
    this.isEdit = false;
    this.LoadData();
  }

  remove() {

    this.http.delete('api/v1/country',this.countryForm.value)
    .subscribe(() => {
      this.LoadData();
    });
    this.deleteModal?.hide();
  }

  delete(person:any):void {
    this.http
     .getById('api/v1/country',person.id)
      .subscribe(res => {
        const countryResponse = res as country;
        this.countryForm.setValue({id : countryResponse.id, name : countryResponse.name});
      });
    this.deleteModal?.show();
  }

  }

