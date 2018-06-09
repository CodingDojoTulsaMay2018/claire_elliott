from flask import Flask, render_template, session, request, redirect
from random import randint

app = Flask(__name__)
app.secret_key = "TotallySoSecret"

@app.route('/')
def index():
    if 'answer' not in session:
        session.clear()
        session['answer'] = randint(1,100)
    return render_template('index.html', session=session)

@app.route('/process', methods=['POST'])
def guess():
    if request.form['action'] == 'submit':
        session['guess'] = int(request.form['player_guess'])        
        return redirect('/')
    else:
        session.clear()
        return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)