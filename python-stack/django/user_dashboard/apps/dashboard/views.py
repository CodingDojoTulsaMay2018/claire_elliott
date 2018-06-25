from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User, Comment, Post, UserManager
import bcrypt

def index(request):
    return render(request, 'dashboard/index.html')

def register(request):
    return render(request, 'dashboard/register.html')

def create(request):
    errors = User.objects.register_validation(request.POST)
    if len(errors):
        for message in errors:
            messages.error(request, message)
        return redirect('/register')
    else:
        if not User.objects.all():
            new_user = User.objects.create(
                first_name = request.POST['first_name'],
                last_name = request.POST['last_name'],
                email = request.POST['email'],
                password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt()),
                level = 9
            )
            request.session['email'] = request.POST['email']
            request.session['welcome_name'] = request.POST['first_name']
        else:
            new_user = User.objects.create(
                first_name = request.POST['first_name'],
                last_name = request.POST['last_name'],
                email = request.POST['email'],
                password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt()),
                level = 0
            )
            request.session['email'] = request.POST['email']
            request.session['welcome_name'] = request.POST['first_name']
        return redirect('/dashboard')

def login(request):
    return render(request,'dashboard/login.html')

def process(request):
    if User.objects.filter(email=request.POST['email']):
        user = User.objects.get(email=request.POST['email'])
        request.session['email'] = request.POST['email']
        if bcrypt.checkpw(request.POST['password'].encode(), user.password.encode()):
            request.session['welcome_name'] = user.first_name
            return redirect('/dashboard')

    messages.error(request, "Email and password do not match")
    return redirect('/login')

def dashboard(request):
    if 'email' not in request.session:
        return redirect('/')
    else:
        context = {
            "this_user" : User.objects.get(email=request.session['email']),
            "users" : User.objects.all(),
            "posts" : Post.objects.all(),
            "comments" : Comment.objects.all()
        }
        return render(request, 'dashboard/dashboard.html', context)

def show(request, id):
    if 'email' not in request.session:
        return redirect('/')
    else:
        context = {
            "profile" : User.objects.get(id=id),
            "posts" : Post.objects.all(),
            "comments" : Comment.objects.all(),
            "this_user" : User.objects.get(email=request.session['email'])
        }
        return render(request, 'dashboard/profile.html', context)

def post(request):
    profile = request.POST['user_id']
    user = User.objects.get(email=request.session['email'])
    new_post = Post.objects.create(
        message = request.POST['post'],
        posted_by = user,
        posted_to = User.objects.get(id=request.POST['user_id'])
    )

    return redirect('/users/show/'+str(profile))

def comment(request):
    profile = request.POST['user_id']
    user = User.objects.get(email=request.session['email'])
    new_comment = Comment.objects.create(
        comment = request.POST['comment'],
        posted_under = Post.objects.get(id=request.POST['post_id']),
        commented_by = user
    )
    return redirect('/users/show/'+str(profile))

def edit(request, id):
    if 'email' not in request.session:
        return redirect('/')
    elif User.objects.get(email=request.session['email']) != 9 and User.objects.get(email=request.session['email']) != User.objects.get(id=id):
        return redirect('/dashboard')
    else:
        context = {
            "this_user" : User.objects.get(email=request.session['email']),
            "user" : User.objects.get(id=id)
        }
        return render(request, 'dashboard/edit.html', context)

def update(request, id):
        edit_user = User.objects.get(id=id)
        this_user = User.objects.get(email=request.session['email'])
        errors = User.objects.edit_validation(request.POST)
        if len(errors):
            for message in errors:
                messages.error(request, message)
            return redirect('/users/edit/'+str(id))
        else:
            edit_user.first_name = request.POST['first_name']
            request.session['welcome_name'] = request.POST['first_name']
            edit_user.last_name = request.POST['last_name']
            if this_user.email == request.session['email']:
                edit_user.email = request.POST['email']
                request.session['email'] = request.POST['email']
            else:
                edit_user.email = request.POST['email']
            if this_user.level != 9 or this_user.id == edit_user.id:
                edit_user.description = request.POST['description']
            if 'user_level' in request.POST:
                edit_user.level = request.POST['user_level']
            edit_user.save()
            return redirect('/users/show/'+str(id))

def password(request, id):
    edit_user = User.objects.get(id=id)
    errors = User.objects.password_validation(request.POST)
    if len(errors):
        for message in errors:
            messages.error(request, message)
        return redirect('/users/edit/'+str(id))
    else:
        edit_user.password = bcrypt.hashpw(request.POST['confirm_pw'].encode(), bcrypt.gensalt())
        edit_user.save()
        return redirect('/users/show/'+str(id))

def destroy(request, id):
    if 'email' not in request.session:
        print("email not in session")
        return redirect('/')
    else:
        print(User.objects.get(id=id).first_name)
        delete_user = User.objects.get(id=id)
        delete_user.delete()
        return redirect('/dashboard')
    
def logout(request):
    request.session.clear()
    return redirect('/')