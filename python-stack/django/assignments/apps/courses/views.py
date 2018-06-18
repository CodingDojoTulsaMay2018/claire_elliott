from django.shortcuts import render, redirect
from django.contrib import messages
from .models import *

def index(request):
    context = {
        "courses" : Course.objects.all()
    }
    return render(request, 'courses/index.html', context)

def create(request):
    if request.method == "POST":
        errors = Course.objects.basic_validator(request.POST)
        if len(errors):
            for message in errors:
                messages.error(request, message)
        else:
            new_course = Course.objects.create(name=request.POST['course_name'], description=request.POST['description'])
            new_course.save()
        return redirect('/courses')

def confirm(request,id):
    context = {
        "course" : Course.objects.get(id=id)
    }
    return render(request, 'courses/confirm.html', context)

def destroy(request, id):
    destroy_course = Course.objects.get(id=id)
    destroy_course.delete()
    return redirect('/courses')
