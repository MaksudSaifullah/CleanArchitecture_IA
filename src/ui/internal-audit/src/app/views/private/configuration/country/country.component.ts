import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { HttpService } from '../../../../core/services/http.service';
import Swal from 'sweetalert2';
import {FormService} from '../../../../core/services/form.service';
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  private datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  countries: country[] = [];
  countryForm: FormGroup;
  formService: FormService = new FormService();
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
            that.countries = (resp as country[]);
            callback({
              recordsTotal: that.countries.length,
              recordsFiltered: that.countries.length,
              data: []
            });
          });
      },
    };

  }

    onSubmit(modalId:any):void{
      const localmodalId = modalId;
        if(this.countryForm.valid){
          if(this.formService.isEdit(this.countryForm.get('id') as FormControl)){
            this.http.put('api/v1/country',this.countryForm.value,null).subscribe(x=>{
              localmodalId.visible = false;
              this.rerender();
            });
          }
          this.http.post('api/v1/country',this.countryForm.value).subscribe(x=>{
            localmodalId.visible = false;
            this.rerender();
          });
        }
    }
    isEdit(){

    }
    edit(modalId:any, person:any):void {
      const localmodalId = modalId;
      console.log(person.id)
      this.http
        .getById('api/v1/country',person.id)
        .subscribe(res => {
            const countryResponse = res as country;
            this.countryForm.setValue({id : countryResponse.id, name : countryResponse.name, remarks: countryResponse.remarks, code: countryResponse.code});
        });
        localmodalId.visible = true;
    }
    delete(id:string){
      const that = this;
      const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
          confirmButton: 'btn btn-success',
          cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
      });

      swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
      }).then((result) => {
        if (result.isConfirmed) {
          this.http.delete('api/v1/country/'+ id ,{}).subscribe(res=>{
            swalWithBootstrapButtons.fire(
              'Deleted!',
              'Your file has been deleted.',
              'success'
            );
            that.datatableElement?.dtInstance.then((dtInstance: DataTables.Api) => {
              dtInstance.draw();
            });
          })
        } else if (
          /* Read more about handling dismissals below */
          result.dismiss === Swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons.fire(
            'Cancelled',
            'Your imaginary file is safe :)',
            'error'
          )
        }
      });
    }
    reset(){
      this.countryForm.reset();
    }
    rerender() {
      this.datatableElement?.dtInstance.then((dtInstance: DataTables.Api) => {
        dtInstance.draw();
      });
    }

  }

