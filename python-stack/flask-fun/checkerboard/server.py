from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def checker8():
    x = 8
    y = 8
    return render_template('index.html',x=int(x),y=int(y))

@app.route('/<x>/<y>')
def checkerXY(x,y):
    return render_template('index.html',x=int(x),y=int(y))

app.run(debug=True)