from __future__ import unicode_literals
from django.db import models

class UserManager(models.Manager):
    def basic_validator(self, postData):
        errors = []
        if len(postData['first_name']) < 2 or len(postData['last_name']) < 2:
            errors.append("Please enter a valid name")
        if len(postData['email']) < 3:
            errors.append("Please enter a valid email address")
        return errors


class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.EmailField(max_length=255)
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)

    objects = UserManager()