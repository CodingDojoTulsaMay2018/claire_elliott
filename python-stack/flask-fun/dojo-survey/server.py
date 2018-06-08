from flask import Flask, render_template, request, redirect

app = Flask(__name__)

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

    return render_template('results.html', answers = answers)

@app.route('/danger')
def danger():
    print("User reached the danger zone")
    return redirect('/')


if __name__ == "__main__":
    app.run(debug=True)