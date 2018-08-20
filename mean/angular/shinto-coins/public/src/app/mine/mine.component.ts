import {
  HttpService
} from './../http.service';
import {
  Component,
  OnInit
} from '@angular/core';

@Component({
  selector: 'app-mine',
  templateUrl: './mine.component.html',
  styleUrls: ['./mine.component.css']
})
export class MineComponent implements OnInit {
  isCorrect = false;
  isIncorrect = false;
  correctAnswer: any;
  answer: string;
  selectedQuestion: any;
  constructor(private _httpService: HttpService) {}

  ngOnInit() {
    this.getQuestion();
  }
  isAlpha(c) {
    return (((c >= 'a') && (c <= 'z')) || ((c >= 'A') && (c <= 'Z')));
  }
  isDigit(c) {
    return ((c >= '0') && (c <= '9'));
  }

  getQuestion() {
    let observable = this._httpService.getQuestions();
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.selectedQuestion = data.results[0];
      this.correctAnswer = data.results[0].correct_answer;
      this.answer = "";
      this.isIncorrect = false;
      this.isCorrect = false;
    });
  }
  checkAnswer(){
    if(this.isAlpha(this.correctAnswer)){
      if(this.answer.toLowerCase() == (this.correctAnswer).toLowerCase()){
        this.isIncorrect = false;
        this.isCorrect = true;
        this._httpService.wallet++;
        this._httpService.history.push({action: "Mined", amount: 1, value: this._httpService.coinRate});
        this._httpService.coinRate++;
      }
      else{
        this.isCorrect = false;
        this.isIncorrect = true;
      }
    }
    else{
      if(this.answer == this.correctAnswer){
        this._httpService.wallet++;
        this._httpService.history.push({action: "Mined", amount: 1, value: this._httpService.coinRate});
        this._httpService.coinRate++;
        this.isIncorrect = false;
        this.isCorrect = true;
      }else{
        this.isCorrect = false;
        this.isIncorrect = true;
      }
    }
  }
}
