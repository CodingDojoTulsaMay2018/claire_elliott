from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^create$', views.create),
    url(r'^login$', views.login),
    url(r'^dashboard$', views.dashboard),
    url(r'^post$', views.post),
    url(r'^comment$', views.comment),
    url(r'^logout$', views.logout)
]