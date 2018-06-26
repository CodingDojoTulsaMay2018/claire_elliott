from django.db import models

class Post(models.Model):
    message = models.TextField()
    created_at = models.DateField(auto_now_add=True)