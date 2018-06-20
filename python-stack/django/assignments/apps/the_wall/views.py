from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Post, Comment, User, UserManager
import bcrypt

def index(request):
    return render(request, 'the_wall/index.html')

def create(request):
    errors = User.objects.register_validation(request.POST)
    if len(errors):
        for message in errors:
            messages.error(request, message)
        return redirect('/wall')
    else:
        new_user = User.objects.create(
            first_name = request.POST['first_name'],
            last_name = request.POST['last_name'],
            email = request.POST['email'],
            password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt())
        )
        request.session['email'] = request.POST['email']
        request.session['welcome_name'] = request.POST['first_name']
        request.session['session'] = "registered"
        return redirect('/wall/dashboard')

def login(request):
    if User.objects.filter(email=request.POST['email']):
        user = User.objects.get(email=request.POST['email'])
        request.session['email'] = request.POST['email']
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            request.session['welcome_name'] = user.first_name
            request.session['session'] = "logged in"
            return redirect('/wall/dashboard')

    messages.error(request, "Email and password do not match")
    return redirect('/wall')

def dashboard(request):
    context = {
        "posts" : Post.objects.all(),
        "comments" : Comment.objects.all()
    }
    return render(request, 'the_wall/dashboard.html', context)

def post(request):
    user = User.objects.get(email=request.session['email'])
    new_post = Post.objects.create(
        message = request.POST['post'],
        posted_by = user
    )

    return redirect('/wall/dashboard')

def comment(request):
    user = User.objects.get(email=request.session['email'])
    new_comment = Comment.objects.create(
        comment = request.POST['comment'],
        posted_under = Post.objects.get(id=request.POST['post_id']),
        commented_by = user
    )
    return redirect('/wall/dashboard')

def logout(request):
    request.session.clear()

    return redirect('/wall')