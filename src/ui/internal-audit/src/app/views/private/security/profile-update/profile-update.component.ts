import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validator, Validators} from "@angular/forms";

@Component({
  selector: 'app-profile-update',
  templateUrl: './profile-update.component.html',
  styleUrls: ['./profile-update.component.scss']
})
export class ProfileUpdateComponent implements OnInit {
  profileUpdateForm: FormGroup;
  fileValue:any;

  imageUrl:any = '';
  constructor(private fb:FormBuilder) {
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
      let reader:FileReader = new FileReader();
      reader.onloadend = () =>{
        this.imageUrl =  reader?.result;
      }
      const file = event.target.files[0];
      reader.readAsDataURL(file);

    }

  }
  submit():void{
    console.log(this.profileUpdateForm.value);
    console.log(this.imageUrl);
  }
}
