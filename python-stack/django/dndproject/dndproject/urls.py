from django.conf.urls import url, include

urlpatterns = [
    url(r'^', include('apps.login_registration.urls', namespace='login_regs')),
    url(r'^dashboard/', include('apps.dashboard.urls', namespace='dashboard')),
    url(r'^campaigns/', include('apps.campaigns.urls', namespace='campaigns')),
    url(r'^characters/', include('apps.characters.urls', namespace='characters')),
]
