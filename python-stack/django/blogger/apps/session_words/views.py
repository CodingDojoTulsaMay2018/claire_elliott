from django.shortcuts import render, redirect
from time import localtime, strftime

def index(request):
    if 'inputs' not in request.session:
        request.session['inputs'] = []
    context = {
        "inputs" : request.session['inputs'],
    }
    return render(request, 'session_words/index.html', context)

def generate(request):
    if request.method == "POST":
        request.session['word'] = request.POST['new-word']
        request.session['color'] = request.POST.get('color', "black")
        request.session['bold'] = request.POST.get('bold', None)
        request.session['time'] = strftime("%b %d, %Y at %I:%M %p", localtime())

    temp_list = request.session['inputs']
    temp_list.append({"word" : request.session['word'], "color" : request.session['color'], "bold" : request.session['bold'], "time" : request.session['time']})
    request.session['inputs'] = temp_list

    return redirect('/session_words')

def reset(request):
    request.session.flush()
    return redirect('/session_words')