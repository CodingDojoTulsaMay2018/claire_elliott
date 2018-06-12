from flask import Flask, render_template, session, redirect, request
from mysqlconnection import connectToMySQL

app = Flask(__name__)

mysql = connectToMySQL('friendsdb')

@app.route('/')
def index():
    all_friends = mysql.query_db("SELECT * FROM friends")
    print("Fetched all friends", all_friends)
    return render_template('index.html', friends = all_friends)

@app.route('/create_friend', methods=['POST'])
def create():
    query = "INSERT INTO friends (first_name, last_name, occupation, created_at, updated_at) VALUES (%(first_name)s, %(last_name)s, %(occupation)s, NOW(), NOW());"
    data = {
             'first_name': request.form['fname'],
             'last_name':  request.form['lname'],
             'occupation': request.form['occupation']
           }
    mysql.query_db(query, data)
    return redirect('/')

if __name__ == "__main__":
    app.run(debug=True)