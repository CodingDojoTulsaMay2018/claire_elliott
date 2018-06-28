from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User
import bcrypt, datetime
from django.urls import reverse

def index(request):
    return render(request, 'login_registration/index.html')

def register(request):
    errors = User.objects.register_validation(request.POST)
    if len(errors):
        for key, value in errors.items():
            messages.error(request, value, extra_tags=key)
        return redirect(reverse('login_regs:index'))
    else:
        new_user = User.objects.create(
            username = request.POST['username'],
            email = request.POST['email'],
            gender = request.POST['gender'],
            password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt()),
            birthdate = datetime.datetime.strptime(request.POST['birthdate'], '%Y-%m-%d')
        )
        request.session['username'] = request.POST['username']
        return redirect(reverse('dashboard:index'))

def login(request):
    if User.objects.filter(username=request.POST['username']):
        user = User.objects.get(username=request.POST['username'])
        request.session['username'] = request.POST['username']
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            return redirect(reverse('dashboard:index'))

    messages.error(request, "Username and password do not match", extra_tags="login")
    return redirect(reverse('login_regs:index'))