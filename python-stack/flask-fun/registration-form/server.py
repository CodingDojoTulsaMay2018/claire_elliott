from flask import Flask, flash, redirect, render_template, request
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = "MakinPancakes"

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def process():
    trigger = 0
    if not request.form['fname'].isalpha() or not request.form['lname'].isalpha():
        flash("First and last name cannot contain numbers.", "nameAlert")
        trigger = 1
    if not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid email address", "emailAlert")
        trigger = 1
    if request.form['initial_password'] != request.form['confirm_password']:
        flash("Passwords do not match.", "passwordAlert")
        trigger = 1
    if len(request.form['initial_password']) < 8:
        flash("Password must be more than 8 characters long.", "lengthAlert")
        trigger = 1
    for value in request.form.values():
        if not len(value):
            flash("All fields must be filled in.", "blankAlert")
            break
    if trigger == 1:
        return redirect('/')
    else:
        flash("Input successful!", "successAlert")
        return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)