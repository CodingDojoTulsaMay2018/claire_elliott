from django.shortcuts import render, redirect

def index(request):
    return render(request, 'surveys/index.html')

def process(request):
    if request.method == "POST":
        request.session['fname'] = request.POST['fname']
        request.session['lname'] = request.POST['lname']
        request.session['meaning'] = request.POST['meaning']
        request.session['toxin'] = request.POST['toxin']
        request.session['deaths'] = request.POST['deaths']
        request.session['country'] = request.POST['country']

    return redirect('/results')

def results(request):
    return render(request, 'surveys/results.html')