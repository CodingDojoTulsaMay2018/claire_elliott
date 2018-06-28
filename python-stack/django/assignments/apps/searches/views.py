from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from .models import Lead
from django.db.models import Q
from django.core import serializers
from datetime import datetime
import json
def index(request):
    return render(request, 'searches/index.html')
# Create your views here.
def all_json(request):
    leads = Lead.objects.all()
    return HttpResponse(serializers.serialize("json", leads), content_type='application/json')
def all_html(request):
    return render(request, 'searches/all.html', { "leads": Lead.objects.all() })

def find(request):
    print(request.POST['name_contains'])
    leads = Lead.objects.filter(Q(first_name__contains=request.POST['name_contains'])|Q(last_name__contains=request.POST['name_contains']))
    if request.POST['date_start']:
        print(request.POST['date_start'])
        date_start = datetime.strptime(request.POST['date_start'], '%Y-%m-%d')
        leads = leads.filter(created_at__gte=date_start)
    if request.POST['date_end']:
        print(request.POST['date_end'])
        date_end = datetime.strptime(request.POST['date_end'], '%Y-%m-%d')
        leads = leads.filter(created_at__lte=date_end)
    context = {
        "leads" : leads
    }

    return render(request, 'searches/all.html', context)