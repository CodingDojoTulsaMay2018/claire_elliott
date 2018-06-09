from flask import Flask, render_template, session, request, redirect

app = Flask(__name__)
app.secret_key = 'SuchSecretMuchHidden'

@app.route('/')
def index():
    if 'visits' not in session:
        session['visits'] = 1
    else:
        session['visits'] += 1
    return render_template('index.html',session=session)

@app.route('/process', methods=['POST'])
def process():
    if request.form['action'] == 'add':
        session['visits'] += 1
        return redirect("/")
    if request.form['action'] == 'reset':
        del session['visits']
        return redirect("/")

if __name__ == "__main__":
    app.run(debug=True)