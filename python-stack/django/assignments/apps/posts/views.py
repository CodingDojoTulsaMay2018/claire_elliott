from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from .models import Post
from django.core import serializers
import json

def index(request):
    return render(request, 'posts/index.html')

def all_json(request):
    posts = Post.objects.all()
    return HttpResponse(serializers.serialize("json", posts), content_type='application/json')
def all_html(request):
    return render(request, 'posts/snippet.html', { "posts": Post.objects.all() })

def create(request):
    Post.objects.create(message = request.POST['message'])
    return render(request, 'posts/snippet.html', { "posts": Post.objects.all() })