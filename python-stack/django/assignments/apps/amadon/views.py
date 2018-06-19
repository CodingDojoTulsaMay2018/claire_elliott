from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Item
import math

def index(request):
    if 'overall_total' not in request.session:
        request.session['overall_total'] = 0.0
        request.session['overall_quantity'] = 0
    context = {
        "items" : Item.objects.all()
    }
    return render(request, 'amadon/index.html', context)

def buy(request):
    if request.method == 'POST':
        total_purchase = 0.0
        total_quantity = 0
        count = Item.objects.all().count()
        for i in range(1,count):
            item = Item.objects.get(id=i)
            total_quantity += int(request.POST['quantity_id_'+str(i)])
            total_purchase += float(request.POST['quantity_id_'+str(i)]) * item.price
        request.session['current_total'] = total_purchase
        temp1 = float(request.session['overall_total'])
        total_purchase += temp1
        request.session['overall_total'] = float(total_purchase)
        request.session['overall_quantity'] = int(total_quantity)
    return redirect('/amadon/checkout')

def checkout(request):
    return render(request, 'amadon/checkout.html')