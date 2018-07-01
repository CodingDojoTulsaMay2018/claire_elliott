from django.shortcuts import render
from .models import *

def index(request):
    return render(request, 'campaigns/index.html')

def dashboard(request, id):
    context = {
        "this_campaign" : Campaign.objects.get(id=id)
    }
    return render(request, 'campaigns/dashboard.html', context)

def load_locations(request):
    return render(request, 'campaigns/locations.html', { "locations": Location.objects.all() })

def load_characters(request):
    return render(request, 'campaigns/characters.html')

def load_notes(request):
    return render(request, 'campaigns/notes.html')

def all_notes(request):
    return render(request, 'campaigns/snippet.html', { "my_notes": Note.objects.all() })

def add_note(request):
    Note.objects.create(message = request.POST['message'], added_by = User.objects.get(username=request.session['username']), campaign = Campaign.objects.get(id=1))
    return render(request, 'campaigns/snippet.html', { "my_notes": Note.objects.all() })

def destroy_note(request,id):
    delete_note = Note.objects.get(id=id)
    delete_note.delete()
    return render(request, 'campaigns/snippet.html', { "my_notes": Note.objects.all() })