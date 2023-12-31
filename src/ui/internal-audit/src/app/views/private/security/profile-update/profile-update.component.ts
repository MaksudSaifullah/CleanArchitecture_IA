import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validator, Validators} from "@angular/forms";
import {HttpService} from "../../../../core/services/http.service";
import {environment} from "../../../../../environments/environment";
import {FileResponseInterface} from "../../../../core/interfaces/file-response.interface";
import {AlertService} from "../../../../core/services/alert.service";
import {ProfileUpdateResponse} from "../../../../core/interfaces/security/user-registration.interface";
import {HelperService} from 'src/app/core/services/helper.service'
import { UploadedDocumentList, DocumentGet, UploadDocumentRequest, UploadedDocumentsNotify, DocumentSource } from 'src/app/core/interfaces/uploaded-document.interface';
import {UserStore} from "../../../../shared/user.store";

@Component({
  selector: 'app-profile-update',
  templateUrl: './profile-update.component.html',
  styleUrls: ['./profile-update.component.scss']
})
export class ProfileUpdateComponent implements OnInit {
  profileUpdateForm: FormGroup;
  fileValue:any;
  documentRawSourceInfo: DocumentSource = {};

  imageUrl:any = '';
  designation: string | undefined;
  constructor(private helper:HelperService,private userStore:UserStore,private fb:FormBuilder, private httpService: HttpService,private alertService: AlertService) {
    this.profileUpdateForm = fb.group({
      fullName:['', [Validators.required,Validators.minLength(5),Validators.maxLength(50)]],
      ProfileImageUrl: ['']
    })
  }

  async ngOnInit() {
    this.httpService.get<any>('UserRegistration/GetUserProfile').subscribe(x=>{
      let convertedResponse = x as ProfileUpdateResponse;
      this.profileUpdateForm.patchValue(convertedResponse);
     // this.profileUpdateForm.controls['ProfileImageUrl'].setValue(`/api/v1/document/get-file-stream?Id=${environment.file_host+ convertedResponse.profileImageUrl}`);
      this.imageUrl =  convertedResponse.profileImageUrl;
      this.designation = convertedResponse.designationName;
    })
    this.documentRawSourceInfo=await this.helper.getDocumentSource('Profile_Picture') as DocumentSource;
  }
  clickFileControl(controlId:any){
    document.getElementById(controlId)?.click();
  }
  onFileChange(event:any) {
    if (event.target.files.length > 0) {
      let doc=this.documentRawSourceInfo;
      let _file: File = event.target.files[0] as File;
      const file = event.target.files[0];
      this.httpService.postFile(doc.id == null ? '':doc.id,doc.name== null ? '':doc.name,'user.png',_file,'Document').subscribe(x=>{
        let response = x as FileResponseInterface;
        this.imageUrl = environment.file_host+`/api/v1/document/get-file-stream?Id=${response.id}`;
        this.profileUpdateForm.controls['ProfileImageUrl'].setValue(`/api/v1/document/get-file-stream?Id=${response.id}`);
      });
    }
  }
  submit():void{
    if(this.profileUpdateForm.valid){
      let data = this.profileUpdateForm.value as ProfileUpdateResponse;
      data.profileImageUrl = this.imageUrl;
      this.httpService.post('UserRegistration/UpdateUserProfile',data).subscribe(x=>{
        if(x == true){
          this.alertService.success('Profile update successful');
        }
        this.httpService.get<any>('UserRegistration/GetUserProfile').subscribe(x=>{
          let convertedResponse = x as ProfileUpdateResponse;
          this.userStore.update({
            fullName: convertedResponse.fullName,
            profileImage:convertedResponse.profileImageUrl,
            designation:convertedResponse.designationName
          });
        })
      });
    }

  }
}
