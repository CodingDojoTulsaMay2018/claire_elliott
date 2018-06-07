from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html', color="blue",number=3)

@app.route('/<number>')
def numbers(number):
    return render_template('index.html',number=int(number),color="blue")

@app.route('/<number>/<color>')
def colors_and_numbers(number,color):
    return render_template('index.html',number=int(number),color=color)

if name == "(__main__)":
    app.run(debug=True)