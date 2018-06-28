from __future__ import unicode_literals
from django.db import models
import re, bcrypt

EMAIL_REGEX = re.compile('^[_a-z0-9-]+(.[_a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)(.[a-z]{2,4})$')

class UserManager(models.Manager):
    def register_validation(self, postData):
        errors = {}
        if postData['initial_pw'] != postData['confirm_pw']:
            errors['register password match'] = "Passwords do not match"
        if len(postData['initial_pw']) < 8 or len(postData['confirm_pw']) < 8:
            errors['register password length'] = "Password must be at least 8 characters"
        if User.objects.filter(email=postData['email']).exists():
            errors['register email dupe'] = "Email has already been registered"
        if User.objects.filter(username=postData['username']).exists():
            errors['register username dupe'] = "Username has already been registered"
        if len(postData['username']) < 3 or len(postData['username']) > 30:
            errors['register username length'] = "Username must be at least 3 characters and no more than 30"
        if not postData['username'].isalnum() or not postData['username'].islower():
            errors['register username string'] = "Username can only contain numbers and lowercase letters"
        if not postData['birthdate']:
            errors['register date blank'] = "Birthdate cannot be blank"
        return errors

class User(models.Model):
    username = models.CharField(max_length=30, unique=True)
    email = models.CharField(max_length=255, unique=True)
    password = models.CharField(max_length=255)
    gender = models.CharField(max_length=15,default="Not Stating")
    birthdate = models.DateField(auto_now=False)
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)

    objects = UserManager()

    def __repr__(self):
        return "<User {}: {}>".format(self.id, self.username)