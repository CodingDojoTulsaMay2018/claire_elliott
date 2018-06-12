from flask import Flask, render_template, redirect, request, session
from random import randint

app = Flask(__name__)
app.secret_key = 'GoldMiningInTheseHills'

@app.route('/')
def index():
    if 'gold' not in session or session['gold'] < 0:
        session['gold'] = 0
    if 'activities' not in session:
        session['activities'] = []
    return render_template('index.html',session=session,length=len(session['activities']))

@app.route('/process', methods=['POST'])
def process():
    if request.form['action'] == 'farm':
        session['action'] = "farming"
        session['earnings'] = randint(10,20)
        session['gold'] += session['earnings']
        session['activities'].insert(0, 'You earned ' + str(session["earnings"]) + ' from ' + session['action'])
        return redirect ('/')
    elif request.form['action'] == 'cave':
        session['action'] = "the cave"
        session['earnings'] = randint(5,10)
        session['gold'] += session['earnings']
        session['activities'].insert(0, 'You earned ' + str(session["earnings"]) + ' from ' + session['action'])
        return redirect('/')
    elif request.form['action'] == 'house':
        session['action'] = "the couch"
        session['earnings'] = randint(2,5)
        session['gold'] += session['earnings']
        session['activities'].insert(0, 'You earned ' + str(session["earnings"]) + ' from ' + session['action'])
        return redirect('/')
    elif session['gold'] == 0 and request.form['action'] == 'casino':
        session['activities'].insert(0, 'Whoa, tiger! Find some gold first before you try and lose it!')
        return redirect('/')
    else:
        return redirect('/casino')

@app.route('/casino')
def casino():
    if session['gold'] == 0:
        session['activities'].insert(0, 'Whoa, tiger! Find some gold first before you try and lose it!')
        return redirect('/')
    session['action'] = "the casino"
    chance = randint(0,1)
    if chance == 0:
        session['earnings'] = randint(1,50)
        session['gold'] += session['earnings']
        session['activities'].insert(0, 'You earned ' + str(session["earnings"]) + ' from ' + session['action'])
    else:
        session['earnings'] = randint(1,50)
        if not session['earnings'] > session['gold']:
            session['gold'] -= session['earnings']
            session['activities'].insert(0, 'You lost ' + str(session["earnings"]) + ' from ' + session['action'] + '. Ouch!')
        else:
            session['activities'].insert(0, 'Shoot! You lost all your money!')
            session['gold'] = 0
    return redirect('/')


if __name__ == '__main__':
    app.run(debug=True)