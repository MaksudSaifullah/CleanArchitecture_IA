import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { accessPrivilegeConfig } from 'src/app/core/interfaces/security/access-privilege.interface'
import {AlertService} from '../../../../core/services/alert.service';
import { HttpService } from 'src/app/core/services/http.service';
@Component({
  selector: 'app-access-privilege',
  templateUrl: './access-privilege.component.html',
  styleUrls: ['./access-privilege.component.scss']
})
export class AccessPrivilegeComponent implements OnInit {
  accessPrivilegeConfig: any ;
  accessPrivilegeForm: FormGroup;
  formService: FormService = new FormService();

  
  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.accessPrivilegeForm = this.fb.group({
      id: [''],
      name: ['',[Validators.required,Validators.maxLength(50),Validators.minLength(2)]],
      description: ['',[Validators.required]]      
    })
  }
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.LoadData();
  };

  onSubmit():void 
  {
    //const localmodalId = modalId;
      if(this.accessPrivilegeForm.valid){        
        
        
      }
      else{
        this.AlertService.error('Invalid Information');
      }
  }
  LoadData() {
    this.http.get('accessPrivilege').subscribe(resp => {
      let convertedResp = resp as unknown as accessPrivilegeConfig;
      this.accessPrivilegeConfig = convertedResp;
    })
  }
  // onCheckAlphabet():void{
  //   var checkBox = document.getElementById("alphabet");
  //   var maxAlphabet = document.getElementById("maxAlphabet");
  //   if (checkBox.chec == true){
  //     maxAlphabet.style.display = "block";
  //   } else {
  //     maxAlphabet.style.display = "none";
  //   }
  // }

}
