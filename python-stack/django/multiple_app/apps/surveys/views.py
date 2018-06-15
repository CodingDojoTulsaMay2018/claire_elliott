from django.http import HttpResponse
from django.shortcuts import render, redirect

def index(request):
    return HttpResponse("Placeholder to later display all surveys created")

def new(request):
    return HttpResponse("Placeholder for users to add a new survey")
