from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'login$', views.login),
    url(r'^process$', views.process),
    url(r'^register$', views.register),
    url(r'^create$', views.create),
    url(r'^dashboard$', views.dashboard),
    url(r'^post$', views.post),
    url(r'^comment$', views.comment),
    url(r'^users/show/(?P<id>\d+)$', views.show),
    url(r'^users/edit/(?P<id>\d+)$', views.edit),
    url(r'^update/(?P<id>\d+)$', views.update),
    url(r'^password/(?P<id>\d+)$', views.password),
    url(r'^users/destroy/(?P<id>\d+)$', views.destroy),
    url(r'^logout$', views.logout)
]