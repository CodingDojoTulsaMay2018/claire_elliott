from django.conf.urls import url, include

urlpatterns = [
    url(r'^', include('apps.login_registration.urls', namespace='login_regs')),
    url(r'^dashboard/', include('apps.dashboard.urls', namespace='dashboard')),
]
