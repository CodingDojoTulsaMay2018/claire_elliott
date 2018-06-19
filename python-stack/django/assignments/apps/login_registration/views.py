from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User, UserManager
import bcrypt

def index(request):
    return render(request, 'login_registration/index.html')

def create(request):
    if request.method == 'POST':
        errors = User.objects.register_validation(request.POST)
        if len(errors):
            for message in errors:
                messages.error(request, message)
            return redirect('/dashboard')
        else:
            new_user = User.objects.create(
                first_name = request.POST['first_name'],
                last_name = request.POST['last_name'],
                email = request.POST['email'],
                password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt())
            )
            request.session['welcome_name'] = request.POST['first_name']
            request.session['session'] = "registered"
            return redirect('/dashboard/success')

def login(request):
    if User.objects.filter(email=request.POST['email']):
        user = User.objects.get(email=request.POST['email'])
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            request.session['welcome_name'] = user.first_name
            request.session['session'] = "logged in"
            return redirect('/dashboard/success')

    messages.error(request, "Email and password do not match")
    return redirect('/dashboard')

def success(request):
    return render(request, 'login_registration/success.html')