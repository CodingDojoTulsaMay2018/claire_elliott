from django.conf.urls import url, include
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^gold$', views.gold),
    url(r'^casino$', views.casino),
    url(r'^clear$', views.clear)
]