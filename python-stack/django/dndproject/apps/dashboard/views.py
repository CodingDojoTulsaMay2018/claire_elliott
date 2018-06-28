from django.shortcuts import render, redirect
from django.urls import reverse

def index(request):
    return render(request, 'dashboard/index.html')

def logout(request):
    request.session.clear()
    return redirect(reverse('login_regs:index'))