import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validator, Validators} from "@angular/forms";
import {HttpService} from "../../../../core/services/http.service";
import {environment} from "../../../../../environments/environment";
import {FileResponseInterface} from "../../../../core/interfaces/file-response.interface";

@Component({
  selector: 'app-profile-update',
  templateUrl: './profile-update.component.html',
  styleUrls: ['./profile-update.component.scss']
})
export class ProfileUpdateComponent implements OnInit {
  profileUpdateForm: FormGroup;
  fileValue:any;

  imageUrl:any = '';
  constructor(private fb:FormBuilder, private httpService: HttpService) {
    this.profileUpdateForm = fb.group({
      fullName:['', [Validators.required,Validators.minLength(5),Validators.maxLength(50)]],
      profileImage: ['']
    })
  }

  ngOnInit(): void {
  }
  clickFileControl(controlId:any){
    console.log(controlId);
    document.getElementById(controlId)?.click();
  }
  onFileChange(event:any) {
    if (event.target.files.length > 0) {
      let _file: File = event.target.files[0] as File;
      const file = event.target.files[0];
      this.httpService.postFile(environment.upload_file_configuration.id,environment.upload_file_configuration.name,'user.png',_file).subscribe(x=>{
        let response = x as FileResponseInterface;
        this.imageUrl = environment.file_host+`/api/v1/document/get-file-stream?Id=${response.id}`;
        this.profileUpdateForm.controls['profileImage'].setValue(`/api/v1/document/get-file-stream?Id=${response.id}`);
      });
    }
  }
  submit():void{
    console.log(this.profileUpdateForm.value);
    console.log(this.imageUrl);
  }
}
