from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string

def index(request):
    if 'counter' not in request.session:
        request.session['counter'] = 0
    return render(request, 'random_words/index.html',context=request.session)

def generate(request):
    if request.method == "POST":
        request.session['counter'] += 1
        request.session['word'] = get_random_string(length=10)
    return redirect('/random')

def reset(request):
    request.session.flush()
    return redirect('/random')