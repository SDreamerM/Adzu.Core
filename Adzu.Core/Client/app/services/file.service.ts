import { Http, Headers, RequestOptions } from "@angular/http";
import { Inject, Injectable } from "@angular/core";

@Injectable()
export class FileService {
    constructor(private http: Http) { }

    public createFile(files: any) {
        let formData: FormData = new FormData();
        for (let file of files) {
            formData.append(file.name, file);
        }

        return this.http.post('http://localhost:59741/api/files', formData);
    }
}