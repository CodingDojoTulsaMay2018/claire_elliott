from django.conf.urls import url, include

urlpatterns = [
    url(r'^courses/', include('apps.courses.urls')),
    url(r'^amadon/', include('apps.amadon.urls')),
    url(r'^dashboard/', include('apps.login_registration.urls')),
    url(r'^wall/', include('apps.the_wall.urls')),
    url(r'^leads/', include('apps.searches.urls')),
    url(r'^posts/', include('apps.posts.urls')),
    url(r'^searches/', include('apps.searches.urls'))
]
