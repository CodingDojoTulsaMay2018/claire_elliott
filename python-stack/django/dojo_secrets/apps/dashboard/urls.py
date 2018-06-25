from django.conf.urls import url, include
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^register$', views.register),
    url(r'^login$', views.login),
    url(r'^secrets$', views.dashboard),
    url(r'^post$', views.post),
    url(r'^secrets/popular$', views.popular_secrets),
    url(r'^like$', views.like),
    url(r'^destroy/(?P<id>\d+)$', views.destroy),
    url(r'^logout$', views.logout)
]