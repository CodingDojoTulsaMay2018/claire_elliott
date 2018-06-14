from django.shortcuts import render, redirect
from random import randint
from time import localtime, strftime

def index(request):
    if 'log' not in request.session:
        request.session['log'] = []
    if 'gold' not in request.session or request.session['gold'] < 0:
        request.session['gold'] = 0
    context = {
        "log" : request.session['log']
    }
    return render(request, 'processes/index.html',context)

def gold(request):
    if request.method == "POST":
        if request.POST['action'] == "farm":
            request.session['action'] = "farming"
            request.session['earnings'] = randint(10,20)
            request.session['gold'] += request.session['earnings']
            request.session['time'] = strftime("%I:%M %p", localtime())

            temp_list = request.session['log']
            temp_list.append('You earned ' + str(request.session["earnings"]) + ' from ' + request.session['action'] + ' at ' + request.session['time'])
            request.session['log'] = temp_list
            return redirect('/')

        elif request.POST['action'] == "cave":
            request.session['action'] = "the cave"
            request.session['earnings'] = randint(5,10)
            request.session['gold'] += request.session['earnings']
            request.session['time'] = strftime("%I:%M %p", localtime())

            temp_list = request.session['log']
            temp_list.append('You earned ' + str(request.session["earnings"]) + ' from ' + request.session['action'] + ' at ' + request.session['time'])
            request.session['log'] = temp_list
            return redirect('/')

        elif request.POST['action'] == "house":
            request.session['action'] = "the couch"
            request.session['earnings'] = randint(5,10)
            request.session['gold'] += request.session['earnings']
            request.session['time'] = strftime("%I:%M %p", localtime())

            temp_list = request.session['log']
            temp_list.append('You earned ' + str(request.session["earnings"]) + ' from ' + request.session['action'] + ' at ' + request.session['time'])
            request.session['log'] = temp_list
            return redirect('/')

        elif request.POST['action'] == "casino" and request.session['gold'] == 0:
            temp_list = request.session['log']
            temp_list.append('Whoa, tiger! Find some gold first before you try and lose it!')
            request.session['log'] = temp_list
            return redirect('/')

        else:
            return redirect('/casino')
            
def casino(request):   
    request.session['action'] = "the casino"
    chance = randint(0,1)
    if chance:
        request.session['earnings'] = randint(1,50)
        request.session['gold'] += request.session['earnings']
        request.session['time'] = strftime("%I:%M %p", localtime())

        temp_list = request.session['log']
        temp_list.append('You earned ' + str(request.session["earnings"]) + ' from ' + request.session['action'] + ' at ' + request.session['time'])
        request.session['log'] = temp_list
    else:
        request.session['earnings'] = randint(1,50)
        if not request.session['earnings'] > request.session['gold']:
            request.session['gold'] -= request.session['earnings']
            request.session['time'] = strftime("%I:%M %p", localtime())

            temp_list = request.session['log']
            temp_list.append('You lost ' + str(request.session["earnings"]) + ' from ' + request.session['action'] + ' at ' + request.session['time'] +'. Ouch!')
            request.session['log'] = temp_list
        else:
            temp_list = request.session['log']
            temp_list.append('Shoot! You lost all your money at ' + request.session['time'])
            request.session['log'] = temp_list
    return redirect('/')

def clear(request):
    request.session.flush()
    return redirect('/')