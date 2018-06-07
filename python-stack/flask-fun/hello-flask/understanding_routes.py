from flask import Flask
# Create a server file that generates 5 different http responses for the following 5 url requests:

# localhost:5000 - have it say "Hello World!" - Hint: If you have only one route that your server is listening for, it must be your root route ("/")
# localhost:5000/dojo - have it say "Dojo!"
# localhost:5000/say/flask - have it say "Hi Flask".  Have function say() handle this routing request.
# localhost:5000/say/michael - have it say "Hi Michael" (have the same function say() handle this routing request)
# localhost:5000/say/john - have it say "Hi John!" (have the same function say() handle this routing request)
# localhost:5000/repeat/35/hello - have it say "hello" 35 times! - You will need to convert a string "35" to an integer 35.  To do this use int().  For example int("35") returns 35.  If the user request localhost:5000/repeat/80/hello, it should say "hello" 80 times.
# localhost:5000/repeat/99/dogs - have it say "dogs" 99 times! (have this be handled by the same route function as #6)

app = Flask(__name__)

@app.route('/')
def hello():
    return "Hello world!"

@app.route('/dojo')
def dojo():
    return "Dojo!"

@app.route('/say/<name>')
def say(name):
    return "Hi, " + name.capitalize()

@app.route('/<num>/<word>')
def repeat(num,word):
    return (word + " ") * int(num)
 

app.run(debug=True)