from django.db import models

class Course(models.Model):
    created_at = models.DateTimeField(auto_now_add=True) # decided by the timezone in settings.py
    title = models.CharField(max_length=255)
    description = models.TextField()

    def __str__(self):
        return self.title