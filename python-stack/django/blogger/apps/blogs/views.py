from django.http import HttpResponse
from django.shortcuts import render, redirect

def index(request):
    return HttpResponse("Placeholder to later display all the list of blogs")

def new(request):
    return HttpResponse("Placeholder to display a new form to create a new blog")

def create(request):
    return redirect('/')

def show(request,number):
    return HttpResponse("Placeholder to display blog " + number)

def edit(request,number):
    return HttpResponse("Placeholder to edit blog " + number)

def destroy(request, number):
    return redirect('/')