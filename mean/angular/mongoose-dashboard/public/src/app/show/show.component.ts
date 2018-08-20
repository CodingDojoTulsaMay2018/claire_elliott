import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent implements OnInit {
  selectedShark: any;
  displayEdit = false;
  constructor(
    private _httpService: HttpService,
    private _route: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit() {
    this._route.params.subscribe((params: Params) => {
      this._httpService.getShark(params['id']).subscribe(data => {
        console.log(data);
        this.selectedShark = data;
      })
  });
  }
  shouldDisplayEdit(){
    this.displayEdit = true;
  }
  updateSharkFromService(shark){
    this._httpService.updateShark(shark).subscribe(data => {
      console.log("Subscribed!", data)
      this.selectedShark = data;
      this.ngOnInit();
    })
  }
  deleteSharkFromService(shark){
    this._httpService.deleteShark(shark).subscribe(data => {
      console.log("deleted shark!")
      this.goHome();
    })
  }
  goHome() {
    this._router.navigate(['/sharks']);
  }

}
