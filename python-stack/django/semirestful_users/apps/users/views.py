from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User, UserManager

def index(request):
    context = {
        "users": User.objects.all()
    }
    return render(request, 'users/index.html', context)

def new(request):
    return render(request, 'users/new.html')

def create(request):
    if request.method == "POST":
        errors = User.objects.basic_validator(request.POST)
        if len(errors):
            for message in errors:
                messages.error(request, message)
            return redirect('/users/new')
    else:
        new_user = User.objects.create(
            first_name = request.POST['first_name'], 
            last_name = request.POST['last_name'],
            email = request.POST['email'])
        new_user.save()
        return redirect('/users/'+str(new_user.id))

def show(request, id):
    context = {
        "user" : User.objects.get(id=id)
    }
    return render(request, 'users/show.html', context)

def edit(request, id):
    context = {
        "user" : User.objects.get(id=id)
    }

    return render(request, 'users/edit.html', context)

def update(request, id):
    if request.method == "POST":
        edit_user = User.objects.get(id=id)
        errors = User.objects.basic_validator(request.POST)
        if len(errors):
            for message in errors:
                messages.error(request, message)
            return redirect('/users/'+str(edit_user.id)+'/edit')
        else:
            edit_user.first_name = request.POST['first_name']
            edit_user.last_name = request.POST['last_name']
            edit_user.email = request.POST['email']
            edit_user.save()
            return redirect('/users/'+str(edit_user.id))

def destroy(request, id):
    User.objects.get(id=id).delete()

    return redirect('/users')