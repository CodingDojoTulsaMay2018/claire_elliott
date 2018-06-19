from __future__ import unicode_literals
from django.db import models

class Item(models.Model):
    name = models.CharField(max_length=100)
    price = models.FloatField()
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)