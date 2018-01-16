import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { FileService } from '../../services/file.service';

@Component({
    selector: 'user-setup',
    providers: [FileService],
    templateUrl: './user-setup.component.html'
})

export class UserSetupComponent {
    formGroup: FormGroup;

    constructor(private fileService: FileService) {
        this.formGroup = new FormGroup({
            'email': new FormControl(''),
            'lastName': new FormControl(''),
            'firstName': new FormControl('')
        });
    }

    onFileChange(files: any) {
        this.fileService.createFile(files).subscribe(fileId => {
        });
    }
}
