from __future__ import unicode_literals
from django.db import models
import re, bcrypt

EMAIL_REGEX = re.compile('^[_a-z0-9-]+(.[_a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)(.[a-z]{2,4})$')

class UserManager(models.Manager):
    def register_validation(self, postData):
        errors = []
        if len(postData['first_name']) < 2 :
            errors.append("A valid first name is required")
        if not postData['first_name'].isalpha():
            errors.append("First name cannot contain numbers or special characters")
        if len(postData['last_name']) < 2 :
            errors.append("A valid last name is required")
        if not postData['last_name'].isalpha():
            errors.append("First name cannot contain numbers or special characters")
        if postData['initial_pw'] != postData['confirm_pw']:
            errors.append("Passwords do not match")
        if len(postData['initial_pw']) < 8 or len(postData['confirm_pw']) < 8:
            errors.append("Password must be more than 8 characters")
        if not re.match(EMAIL_REGEX, postData['email']):
            errors.append("A valid email address is required")
        if User.objects.filter(email=postData['email']).exists():
            errors.append("This email address has already been registered")
        return errors

    def edit_validation(self, postData):
        errors = []
        if len(postData['first_name']) < 2 :
            errors.append("A valid first name is required")
        if not postData['first_name'].isalpha():
            errors.append("First name cannot contain numbers or special characters")
        if len(postData['last_name']) < 2 :
            errors.append("A valid last name is required")
        if not postData['last_name'].isalpha():
            errors.append("First name cannot contain numbers or special characters")
        if not re.match(EMAIL_REGEX, postData['email']):
            errors.append("A valid email address is required")
        return errors
    
    def password_validation(self, postData):
        errors = []
        if postData['initial_pw'] != postData['confirm_pw']:
            errors.append("Passwords do not match")
        if len(postData['initial_pw']) < 8 or len(postData['confirm_pw']) < 8:
            errors.append("Password must be more than 8 characters")
        return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255, unique=True)
    password = models.CharField(max_length=255)
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)
    level = models.IntegerField()
    description = models.TextField(blank=True,null=True,default='')

    objects = UserManager()

class Post(models.Model):
    message = models.TextField()
    posted_by = models.ForeignKey(User, on_delete=models.CASCADE, related_name="has_posts")
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)
    posted_to = models.ForeignKey(User, on_delete=models.CASCADE, related_name="posts_for")

class Comment(models.Model):
    comment = models.TextField(max_length=400)
    posted_under = models.ForeignKey(Post, on_delete=models.CASCADE, related_name="comments_made")
    commented_by = models.ForeignKey(User, on_delete=models.CASCADE, related_name="has_comments")
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)