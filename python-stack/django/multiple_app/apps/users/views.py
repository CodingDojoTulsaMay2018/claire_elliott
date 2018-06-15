from django.http import HttpResponse
from django.shortcuts import render, redirect

def index(request):
    return HttpResponse("Placeholder to later display all the list of users")

def register(request):
    return HttpResponse("Placeholder for users to create a new user record")

def login(request):
    return HttpResponse("Placeholder for users to login")