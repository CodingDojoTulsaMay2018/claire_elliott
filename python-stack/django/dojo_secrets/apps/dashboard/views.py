from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Secret, User, UserManager
import bcrypt
from django.db.models import Count


def index(request):
    if 'email' in request.session:
        return redirect('/secrets')
    else:
        return render(request, 'dashboard/index.html')

def register(request):
    errors = User.objects.register_validation(request.POST)
    if len(errors):
        for message in errors:
            messages.error(request, message)
        return redirect('/register')
    else:
        new_user = User.objects.create(
            first_name = request.POST['first_name'],
            last_name = request.POST['last_name'],
            email = request.POST['email'],
            password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt()),
        )
        request.session['email'] = request.POST['email']
        request.session['welcome_name'] = request.POST['first_name']

        return redirect('/secrets')

def login(request):
    if User.objects.filter(email=request.POST['email']):
        user = User.objects.get(email=request.POST['email'])
        request.session['email'] = request.POST['email']
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            request.session['welcome_name'] = user.first_name
            return redirect('/secrets')
    messages.error(request, "Email and password do not match")
    return redirect('/')

def dashboard(request):
    if 'email' not in request.session:
        return redirect('/')
    else:
        context = {
            "this_user" : User.objects.get(email=request.session['email']),
            "secrets" : Secret.objects.all()
        }
        return render(request, 'dashboard/dashboard.html', context)

def post(request):
    new_secret = Secret.objects.create(
        message = request.POST['secret'],
        posted_by = User.objects.get(id=request.POST['poster'])
    )
    return redirect('/secrets')

def popular_secrets(request):
    if not request.session:
        return redirect('/')
    else:
        context = {
            "this_user" : User.objects.get(email=request.session['email']),
            "secrets" : Secret.objects.all(),
            "popular" : Secret.objects.annotate(num_likes=Count('liked_by')).order_by('-num_likes')
        }
        return render(request, 'dashboard/popular.html', context)

def like(request):
    this_user = User.objects.get(email=request.session['email'])
    this_secret = Secret.objects.get(id=request.POST['secret_id'])
    this_secret.liked_by.add(this_user)
    this_secret.save()
    return redirect('/secrets/popular')

def destroy(request,id):
    this_secret = Secret.objects.get(id=id)
    this_user = User.objects.get(email=request.session['email'])
    if this_user.id == this_secret.posted_by.id:
        destroy_secret = Secret.objects.get(id=id)
        destroy_secret.delete()
    return redirect('/')

def logout(request):
    request.session.clear()
    return redirect('/')