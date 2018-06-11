from flask import Flask, flash, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = 'FuguKing'

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/results', methods=['POST'])
def create_results():
    
    answers = {'fname' : request.form['fname'],
        'lname' : request.form['lname'],
        'meaning' : request.form['meaning'],
        'toxin' : request.form['toxin'],
        'deaths' : request.form['deaths'],
        'country' : request.form['country']
        }
    trigger = 0
    if len(answers['fname']) < 1:
        flash("Name cannot be blank.", "fnameAlert")
        trigger = 1
    if not answers['deaths'].isnumeric():
        flash("Number of people must be a numeric value.", "numericAlert")
        trigger = 1
    if trigger == 1:
        return redirect('/')
    else:
        flash("Input successful")
        return render_template('results.html', answers = answers)

@app.route('/danger')
def danger():
    print("User reached the danger zone")
    return redirect('/')


if __name__ == "__main__":
    app.run(debug=True)