from flask import Flask, render_template, request
import time, datetime

app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/checkout', methods=['POST'])
def checkout():
    order_info = {
        'fname' : request.form['first_name'],
        'lname' : request.form['last_name'],
        'id' : request.form['student_id'],
        'cats' : int(request.form['cat']),
        'dogs' : int(request.form['dog']),
        'birds' : int(request.form['bird']),
        'time' :datetime.datetime.now().strftime("%A %B, %d %Y at %H:%M %p")
        }

    return render_template('checkout.html', order = order_info)

if __name__ == "__main__":
    app.run(debug=True)