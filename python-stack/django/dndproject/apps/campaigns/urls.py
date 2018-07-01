from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name="index"),
    url(r'^(?P<id>\d+)$', views.dashboard, name="dashboard"),
    url(r'^load_locations', views.load_locations, name="load_locations"),
    url(r'^load_characters', views.load_characters, name="load_characters"),
    url(r'^load_notes', views.load_notes, name="load_notes"),
    url(r'^snippet.html', views.all_notes, name="all_notes"),
    url(r'^add_note', views.add_note, name="add_note"),
    url(r'^destroy/(?P<id>\d+)$', views.destroy_note, name="destroy_note"),
]