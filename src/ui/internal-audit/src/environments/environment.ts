// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  hostName: 'https://localhost:7049/api/v1',
  captcha_public_key:'6Lfmr4AgAAAAAKy7KpD1F6qGRQ5ahAQEAP7nVLrq',
  upload_file_configuration :{
    "id": "24eb5c76-2107-ed11-b3b2-00155d610b18",
    "name": "Profile_Picture"
  },
  file_upload_url: 'Document',
  file_host: 'https://localhost:7049'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
